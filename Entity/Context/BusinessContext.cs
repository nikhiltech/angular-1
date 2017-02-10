using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entity.Model;

namespace Entity.Context
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("BusinessContext")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Developer> Developers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}