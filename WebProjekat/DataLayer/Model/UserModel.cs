using DataLayer.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
   public class UserModel
    {
        public UserModel(long id, string korisnickoIme, string lozinka, string punoIme, DateTime datumRodjenja, string adresa, byte[] slika)
        {
            Id = id;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            PunoIme = punoIme;
            DatumRodjenja = datumRodjenja;
            Adresa = adresa;
            Slika = slika;
            Porudzbine = new List<OrderModel>();
        }

        public long Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string  Lozinka { get; set; }
        public string PunoIme { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[] Slika { get; set; }
        public List<OrderModel> Porudzbine { get; set; }
        

            
    }
}
