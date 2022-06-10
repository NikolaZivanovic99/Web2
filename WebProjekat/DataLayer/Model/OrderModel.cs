using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
   public class OrderModel
    {
        public OrderModel(long id, string adresa, string komentar, decimal cena, long? dostavljacId, long? korisnikId)
        {
            Id = id;
            Adresa = adresa;
            Komentar = komentar;
            Cena = cena;
            DostavljacId = dostavljacId;
            KorisnikId = korisnikId;
           
        }

        public long Id { get; set; }
        public string Adresa { get; set; }
        public string Komentar { get; set; }
        public decimal Cena { get; set; }

        public long? DostavljacId { get; set; }
        public Dostavljac Dostavljac { get; set; }

        public long? KorisnikId { get; set; }
        public UserModel Korisnik { get; set; }
        public List<Kolicina> Kolicine { get; set; }

    }
}
