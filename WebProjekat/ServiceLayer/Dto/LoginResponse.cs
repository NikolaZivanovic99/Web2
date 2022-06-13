using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
   public class LoginResponse
    {
        public long Id { get; set; }
        public string PunoIme { get; set; }
        public string KorisnickoIme { get; set; }
        public string Token { get; set; }

        public LoginResponse() { }

        public LoginResponse(UserDto user, string token)
        {
            Id = user.Id;
            PunoIme = user.PunoIme;
            KorisnickoIme = user.KorisnickoIme;
            Token = token;
        }
        public LoginResponse(AdminDto admin, string token) 
        {
            Id = admin.Id;
            PunoIme = admin.PunoIme;
            KorisnickoIme = admin.KorisnickoIme;
            Token = token;
        }
    }
}
