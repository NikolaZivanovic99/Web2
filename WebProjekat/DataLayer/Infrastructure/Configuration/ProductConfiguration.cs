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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.ImeProizvoda).HasMaxLength(50);
            builder.HasIndex(x => x.ImeProizvoda).IsUnique();

            builder.Property(x => x.Cena).HasPrecision(8,2);

            builder.Property(x => x.Sastojci).HasMaxLength(100);

        }
    }
}
