using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
   public class Kolicina
    {
        public Kolicina(long orderId,  long productId, int kolicinaProizvoda)
        {
            OrderId = orderId;
            
            ProductId = productId;
            
            KolicinaProizvoda = kolicinaProizvoda;
        }

        public long OrderId { get; set; }
        public OrderModel Order { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int KolicinaProizvoda { get; set; }
    }
}
