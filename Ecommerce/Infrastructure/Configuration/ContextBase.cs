using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<CompraUsuario> CompraUsuario { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


        private string GetStringConectionConfig()
        {
            string strCon = "Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=Ecommerce;Data Source=DESKTOP-O640JHU\\SQLEXPRESS";
            return strCon;
        }


    }
}
