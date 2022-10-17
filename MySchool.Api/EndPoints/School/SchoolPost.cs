using MySchool.Command.School.Handlers;
using MySchool.Command.Users.Handlers;
using MySchool.ReadModel.Users.Handlers;

namespace MySchool.Api.EndPoints.School
{
    public class SchoolPost
    {
        public static string Template => "v1/school";
        public static string[] Methods => new string[] {HttpMethod.Post.ToString() };
        public static Delegate Handle => SchoolHandlers.SchoolPost;
    }
}
