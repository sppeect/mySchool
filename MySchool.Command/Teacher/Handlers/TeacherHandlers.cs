using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.Command.Teacher.Request;
using MySchool.Domain.Entities.Teacher;
using MySchool.Domain.ValueObjects;
using MySchool.Infraestruture.Data;

namespace MySchool.Command.Teacher.Handlers
{
    public class TeacherHandlers
    {
        public static async Task<IResult> ActionPost(TeacherRequest teacherRequest, ApplicationDbContext context)
        {
            var exist = context.Teachers.Where(a => a.Document.Number == teacherRequest.Document && a.DeletedOn == null).FirstOrDefault();
            if (exist != null)
                return Results.BadRequest("Professor com documento já cadastrado" + exist.Name.FullName);

            var name = new Name(teacherRequest.FirstName, teacherRequest.LastName);
            if (!name.IsValid)
                return Results.BadRequest("Nome Invalido" + name);

            var document = new Document(teacherRequest.Document, teacherRequest.DocumentType);
            if (!document.IsValid)
                return Results.BadRequest("O Documento está invalido" + document.Number.Length);

            var email = new Email(teacherRequest.Email);
            if (!email.IsValid)
                return Results.BadRequest("O Email está invalido");

            var teacher = new Teachers(name, document, email);

            await context.Teachers.AddAsync(teacher);
            await context.SaveChangesAsync();

            return Results.Created($"/teacher/{teacher.Id}", teacher.Id);

        }
        public static async Task<IResult> ActionPut([FromRoute] int Id, TeacherRequest teacherRequest, ApplicationDbContext context)
        {
            var teacher = context.Teachers.Where(a => a.Id == Id && a.DeletedOn == null).FirstOrDefault();
            if (teacher == null)
                return Results.BadRequest("Professor com Id:" + Id + ", não encontrado");


            var name = new Name(teacherRequest.FirstName, teacherRequest.LastName);
            if (!name.IsValid)
                return Results.BadRequest("Nome Invalido" + name);

            var document = new Document(teacherRequest.Document, teacherRequest.DocumentType);
            if (!document.IsValid)
                return Results.BadRequest("O Documento está invalido" + document.Number.Length);

            var email = new Email(teacherRequest.Email);
            if (!email.IsValid)
                return Results.BadRequest("O Email está invalido");

            teacher.Update(name, document, email);
            await context.SaveChangesAsync();

            return Results.Ok("Professor Atualizado com Sucesso!");


        }
        public static async Task<IResult> ActionDelete([FromRoute] int Id, ApplicationDbContext context)
        {
            var teacher = context.Teachers.Where(a => a.Id == Id && a.DeletedOn == null).FirstOrDefault();
            if (teacher == null)
                return Results.BadRequest("Professor com Id:" + Id + ", não encontrado");

            teacher.Delete();
            await context.SaveChangesAsync();

            return Results.Ok("Professor:" + teacher.Name.FullName + "deletado com sucesso");
        }

    }
}
