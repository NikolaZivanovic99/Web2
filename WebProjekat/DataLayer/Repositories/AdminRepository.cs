using DataLayer.Infrastructure;
using DataLayer.Model;
using DataLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        UserDbContext _userDbContext;

        public AdminRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void AddAdmin(Admin newUser)
        {
            _userDbContext.Admini.Add(newUser);
            _userDbContext.SaveChanges();
        }

        public void DeleteAdmin(Admin id)
        {
            _userDbContext.Admini.Remove(id);
            _userDbContext.SaveChanges();
        }

        public List<Admin> GetAdmins()
        {
            List<Admin> admini = _userDbContext.Admini.ToList();
            return admini;
        }

        public Admin GetById(long id)
        {
            return _userDbContext.Admini.Find(id);
        }

        public Admin GetByKorisnickoIme(string korisnickoime)
        {
            Admin admin = _userDbContext.Admini.Where(x => x.KorisnickoIme == korisnickoime).FirstOrDefault();
            return admin;
        }

        public Admin UpdateAdmin(long id, Admin newUser)
        {

            Admin admin = _userDbContext.Admini.Find(id);
            admin.KorisnickoIme = newUser.KorisnickoIme;
            admin.Lozinka = newUser.Lozinka;
            admin.PunoIme = newUser.PunoIme;
            admin.DatumRodjenja = newUser.DatumRodjenja;
            admin.Adresa = newUser.Adresa;
            admin.Slika = newUser.Slika;
            

            _userDbContext.SaveChanges();
            return newUser;
        }
    }
}
