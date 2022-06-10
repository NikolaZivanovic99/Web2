using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public DbSet<UserModel> Korisnici { get; set; }
        public DbSet<Product> Proizvodi { get; set; }
        public DbSet<OrderModel> Porudzbine { get; set; }
        public DbSet<Dostavljac> Dostavljaci { get; set; }
        public DbSet<Admin> Admini { get; set; }

        public UserDbContext(DbContextOptions options) : base(options) 
        {
        
        }

  

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }
    }
}
