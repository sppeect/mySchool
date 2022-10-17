using MySchool.Command.School.Handlers;

namespace MySchool.Api.EndPoints.School
{
    public class SchoolDelete
    {
        public static string Template => "v1/school/{Id:int}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => SchoolHandlers.SchoolDelete;
    }
}
