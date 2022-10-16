using MySchool.Command.Teacher.Handlers;

namespace MySchool.Api.EndPoints.Teacher
{
    public class TeacherDelete
    {
        public static string Template => "v1/teacher/{Id:int}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => TeacherHandlers.ActionDelete;
    }
}
