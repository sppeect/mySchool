using MySchool.ReadModel.Teacher.Handlers;

namespace MySchool.Api.EndPoints.Teacher
{
    public class TeacherGetById
    {
        public static string Template => "v1/teacher/{Id:int}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => TeacherReadHandlers.ActionGetById;
    }
}
