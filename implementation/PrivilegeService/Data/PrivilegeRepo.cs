using PrivilegeService.Dto;
using PrivilegeService.Models;

namespace PrivilegeService.Data
{
    public class PrivilegeRepo : IPrivilegeRepo
    {
        private PrivilegeDataContext _context;

        public PrivilegeRepo(PrivilegeDataContext context)
        {
            _context = context;
        }

        public void CreateUser(Privilege privilege)
        {
            _context.Users.Add(privilege);
        }

        public IEnumerable<Privilege> GetUsers()
        {
            return _context.Users.ToList();
        }

        public Privilege LogIn(string username, string password)
        {
            var userList = _context.Users.ToList();
            
            foreach(Privilege user in userList)
            {
                if ((user.Email == username || user.Username == username) && user.Password == password)
                    return user;
            }
            return null;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}