using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.RepositoriesInterface
{
    public interface IUserRepository
    {
        List<UserModel> GetUsers();
        UserModel GetById(long id);
        UserModel GetByKorisnickoIme(string korisnickoime);
        void AddUser(UserModel newUser);
        UserModel UpdateUser(long id,UserModel newUser);
        void DeleteUser(UserModel id);
    }
}
