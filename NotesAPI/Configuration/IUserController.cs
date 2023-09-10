using NotesAPI.Models;

namespace NotesAPI.Configuration
{
    public interface IUserController : IController<User>
    {
        bool Authorization(string username, string password);
    }
}
