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
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.KorisnickoIme).HasMaxLength(30);
            builder.HasIndex(x => x.KorisnickoIme).IsUnique();

            builder.Property(x => x.Lozinka).HasMaxLength(250);

            builder.Property(x => x.PunoIme).HasMaxLength(50);

            builder.Property(x => x.DatumRodjenja);

            builder.Property(x => x.Adresa).HasMaxLength(50);


            builder.Property(x => x.Slika);

            
                   
            
           

        }
    }
}
