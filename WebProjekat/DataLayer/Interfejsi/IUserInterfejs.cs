using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfejsi
{
  public interface IUserInterfejs
    {
        List<UserModel> GetStudents();
        UserModel GetById(long id);
        UserModel AddStudent(UserModel newStud);
        UserModel UpdateStudent(long id, UserModel newStudData);
        void DeleteStudent(long id);
    }
}
