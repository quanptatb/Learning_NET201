using Lab06.Models;

namespace Lab06.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        void AddUser(string name);
    }
}