using MySchool.Command.Teacher.Handlers;

namespace MySchool.Api.EndPoints.Teacher
{
    public class TeacherPost
    {
        public static string Template => "v1/teacher";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => TeacherHandlers.ActionPost;
    }
}
