using API_FAUNA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FAUNA.Data
{
    public class FaunaContext : DbContext
    {
        public FaunaContext(DbContextOptions<FaunaContext> options)
          : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }
        public DbSet<Especie> Especies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Especie>()
                .HasKey("Id");
        }
    }
}
