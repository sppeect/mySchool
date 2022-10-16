using MySchool.Command.Teacher.Handlers;

namespace MySchool.Api.EndPoints.Teacher
{
    public class TeacherPut
    {
        public static string Template => "v1/teacher/{Id:int}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => TeacherHandlers.ActionPut;
    }
}
