using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.RepositoriesInterface
{
    public interface IAdminRepository
    {
        List<Admin> GetAdmins();
        Admin GetById(long id);
        Admin GetByKorisnickoIme(string korisnickoime);
        void AddAdmin(Admin newUser);
        Admin UpdateAdmin(long id, Admin newUser);
        void DeleteAdmin(Admin id);
    }
}
