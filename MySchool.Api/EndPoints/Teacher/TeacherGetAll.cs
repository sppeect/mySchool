using MySchool.ReadModel.Teacher.Handlers;

namespace MySchool.Api.EndPoints.Teacher
{
    public class TeacherGetAll
    {
        public static string Template => "v1/teacher";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => TeacherReadHandlers.ActionGetAll;
    }
}
