using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Infrastructure.Configuration
{
    public class KolicinaConfiguration : IEntityTypeConfiguration<Kolicina>
    {
        public void Configure(EntityTypeBuilder<Kolicina> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.OrderId });

            
        }
    }
}
