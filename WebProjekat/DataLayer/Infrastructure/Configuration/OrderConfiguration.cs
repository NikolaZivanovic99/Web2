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
    public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Adresa).HasMaxLength(50);
            builder.Property(x => x.Komentar).HasMaxLength(100);
            builder.Property(x => x.Cena).HasPrecision(8, 2);
        }
    }
}
