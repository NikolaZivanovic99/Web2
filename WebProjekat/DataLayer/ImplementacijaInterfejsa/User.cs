using DataLayer.Infrastructure;
using DataLayer.Interfejsi;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ImplementacijaInterfejsa
{
    public class User : IUserInterfejs
    {
        UserDbContext _userDbContext;

        public User(UserDbContext userDbContext) 
        {
            _userDbContext = userDbContext;
        }
        public UserModel AddStudent(UserModel newStud)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(long id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(long id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetStudents()
        {
            return _userDbContext.Korisnici.ToList();
        }

        public UserModel UpdateStudent(long id, UserModel newStudData)
        {
            throw new NotImplementedException();
        }
    }
}
