using MySchool.Command.School.Handlers;
using MySchool.ReadModel.School.Handlers;

namespace MySchool.Api.EndPoints.School
{
    public class SchoolGetById
    {
        public static string Template => "v1/school/{Id:int}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => SchoolReadHandlers.ActionGetById;
    }
}
