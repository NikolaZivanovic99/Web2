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
    public class UserRepository : IUserRepository
    {
        UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public void AddUser(UserModel newUser)
        {
            _userDbContext.Korisnici.Add(newUser);
            _userDbContext.SaveChanges();
        }

        public void DeleteUser(UserModel user)
        {
            _userDbContext.Korisnici.Remove(user);
            _userDbContext.SaveChanges();
        }

        public UserModel GetById(long id)
        {
            return _userDbContext.Korisnici.Find(id);
        }

        public UserModel GetByKorisnickoIme(string korisnickoime)
        {
            UserModel user = _userDbContext.Korisnici.Where(x => x.KorisnickoIme == korisnickoime).FirstOrDefault();
            return user;
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> userModels = _userDbContext.Korisnici.ToList();
            return userModels;
        }

        public UserModel UpdateUser(long id, UserModel user) 
        {
            UserModel userModel = _userDbContext.Korisnici.Find(id);
            userModel.KorisnickoIme = user.KorisnickoIme;
            userModel.Lozinka = user.Lozinka;
            userModel.PunoIme = user.PunoIme;
            userModel.DatumRodjenja = user.DatumRodjenja;
            userModel.Adresa = user.Adresa;
            userModel.Slika = user.Slika;
            userModel.Porudzbine = user.Porudzbine;
            
            _userDbContext.SaveChanges();
            return user;
        }
    }
}
