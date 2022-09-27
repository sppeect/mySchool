using MySchool.Command.Users.Handlers;
using MySchool.ReadModel.Users.Handlers;

namespace MySchool.Api.EndPoints.Users
{
    public class UsersPost
    {
        public static string Template => "v1/users";
        public static string[] Methods => new string[] {HttpMethod.Post.ToString() };
        public static Delegate Handle => UserHandlers.ActionPost;
    }
}
