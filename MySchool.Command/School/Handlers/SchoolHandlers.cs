using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.Command.School.Request;
using MySchool.Domain.Entities.School;
using MySchool.Domain.ValueObjects;
using MySchool.Infraestruture.Data;

namespace MySchool.Command.School.Handlers
{
    public class SchoolHandlers
    {
        public static async Task<IResult> ActionPost(SchoolRequest schoolRequest, ApplicationDbContext context)
        {
            var schoolExist = context.Schools.Where(x => x.Name == schoolRequest.Name && x.DeletedOn == null).FirstOrDefault();

            if (schoolExist != null)
                return Results.BadRequest("Já existe uma escola com este nome." + schoolExist.Name);

            var address = new Address(schoolRequest.Street, schoolRequest.Number, schoolRequest.Neighborhood, schoolRequest.City, schoolRequest.State, schoolRequest.Country, schoolRequest.ZipCode);
            if (!address.IsValid)
                return Results.BadRequest("O endereço está incorreto ou com formato não apropriado." + address.Notifications);

            var document = new Document(schoolRequest.Document, schoolRequest.DocumentType);
            if (!document.IsValid)
                return Results.BadRequest("O Documento está invalido" + document.Number.Length);

            var Email = new Email(schoolRequest.Email);
            if (!Email.IsValid)
                return Results.BadRequest("O Email está invalido");


            var school = new Schools(schoolRequest.Name, address, Email, schoolRequest.Phone, document);

            await context.Schools.AddAsync(school);
            await context.SaveChangesAsync();

            return Results.Created($"/schools/{school.Id}", school.Id);

        }
        public static async Task<IResult> ActionPut([FromRoute] int Id, SchoolRequest schoolRequest, ApplicationDbContext context)
        {
            var schoolExist = context.Schools.Where(x => x.Id == Id && x.DeletedOn == null).FirstOrDefault();

            if (schoolExist == null)
                return Results.BadRequest("Não existe escola cadastrada com esse ID");

            var address = new Address(schoolRequest.Street, schoolRequest.Number, schoolRequest.Neighborhood, schoolRequest.City, schoolRequest.State, schoolRequest.Country, schoolRequest.ZipCode);
            if (!address.IsValid)
                return Results.BadRequest("O endereço está incorreto ou com formato não apropriado." + address.Notifications);

            var document = new Document(schoolRequest.Document, schoolRequest.DocumentType);
            if (!document.IsValid)
                return Results.BadRequest("O Documento está invalido" + document.Number.Length);

            var Email = new Email(schoolRequest.Email);
            if (!Email.IsValid)
                return Results.BadRequest("O Email está invalido");

            schoolExist.Update(schoolRequest.Name, address, Email, schoolRequest.Phone, document);
            await context.SaveChangesAsync();

            return Results.Ok("Escola Atualizada com Sucesso!");

        }
        public static async Task<IResult> ActionDelete([FromRoute] int Id, ApplicationDbContext context)
        {
            var schoolExist = context.Schools.Where(x => x.Id == Id && x.DeletedOn == null).FirstOrDefault();

            if (schoolExist == null)
                return Results.BadRequest("Não existe escola cadastrada com esse ID");

            schoolExist.Delete();
            await context.SaveChangesAsync();

            return Results.Ok("Escola deletada com Sucesso!");

        }

    }
}
