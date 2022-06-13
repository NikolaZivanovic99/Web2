using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
   public class LoginRequest
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public LoginRequest() { }

        public LoginRequest(string korisnickoime, string lozinka)
        {
            KorisnickoIme = korisnickoime;
            Lozinka = lozinka;
        }
    }
}
