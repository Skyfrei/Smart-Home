using PrivilegeService.Dto;
using PrivilegeService.Models;

namespace PrivilegeService.Data
{
    public interface IPrivilegeRepo
    {
        bool SaveChanges();

        void CreateUser(Privilege privilege);
        IEnumerable<Privilege> GetUsers();
        Privilege LogIn(string username, string password);
    }
}