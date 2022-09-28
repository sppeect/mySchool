using MySchool.Command.School.Handlers;

namespace MySchool.Api.EndPoints.School
{
    public class SchoolPut
    {
        public static string Template => "v1/school/{Id:int}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => SchoolHandlers.ActionPut;
    }
}
