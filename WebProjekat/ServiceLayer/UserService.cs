using DataLayer.Interfejsi;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService 
    {
        IUserInterfejs _userInterfejs;

        public UserService(IUserInterfejs userInterfejs) 
        {
            _userInterfejs = userInterfejs;
        }

        public List<UserModel> GetStudents()
        {
            List<UserModel> userModels = _userInterfejs.GetStudents();
            return userModels;
        }
    }
}
