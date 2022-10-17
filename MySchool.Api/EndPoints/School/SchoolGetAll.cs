using MySchool.ReadModel.School.Handlers;

namespace MySchool.Api.EndPoints.School
{
    public class SchoolGetAll
    {
        public static string Template => "v1/school";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => SchoolReadHandlers.SchoolGetAll;
    }
}
