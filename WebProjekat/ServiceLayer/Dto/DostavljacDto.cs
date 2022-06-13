using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
   public class DostavljacDto
    {
        public DostavljacDto(long id, string korisnickoIme,string punoIme, DateTime datumRodjenja, string adresa, byte[] slika)
        {
            Id = id;
            KorisnickoIme = korisnickoIme;
            PunoIme = punoIme;
            DatumRodjenja = datumRodjenja;
            Adresa = adresa;
            Slika = slika;
        }

        public long Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string PunoIme { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[] Slika { get; set; }
        public List<OrderModel> Dostave { get; set; }
    }
}
