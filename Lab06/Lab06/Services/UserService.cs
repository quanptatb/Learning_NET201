using Lab06.Data;
using Lab06.Models;

namespace Lab06.Services
{
    public class UserService : IUserService
    {
        private readonly SchoolContext _context;

        // Vì UserService là Scoped, nó có thể inject DbContext (cũng là Scoped)
        public UserService(SchoolContext context)
        {
            _context = context;
        }

        public void AddUser(string name)
        {
            var user = new User { Name = name };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}