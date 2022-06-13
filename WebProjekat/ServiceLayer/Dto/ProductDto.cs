using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
   public class ProductDto
    {
        public ProductDto(long id, string imeProizvoda, decimal cena, string sastojci)
        {
            Id = id;
            ImeProizvoda = imeProizvoda;
            Cena = cena;
            Sastojci = sastojci;
        }

        public long Id { get; set; }
        public string ImeProizvoda { get; set; }
        public decimal Cena { get; set; }
        public string Sastojci { get; set; }

        public List<Kolicina> Kolicine { get; set; }
    }
}
