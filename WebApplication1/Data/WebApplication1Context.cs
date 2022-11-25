using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<ClassLibrary1.Bilhete> Bilhete { get; set; } = default!;

        public DbSet<ClassLibrary1.Cliente> Cliente { get; set; }

        public DbSet<ClassLibrary1.Desconto> Desconto { get; set; }

        public DbSet<ClassLibrary1.Filme> Filme { get; set; }

        //MÉTODO QUE PERMITE FAZER O SEEDING DA BD:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Bilhete>().HasData(
                new Bilhete() { Id = 1, DataRegisto = DateTime.Now, ClienteId = 1, FilmeId = 3, DescontoId = 2 },
                new Bilhete() { Id = 2, DataRegisto = DateTime.Now, ClienteId = 2, FilmeId = 1, DescontoId = 1 },
                new Bilhete() { Id = 3, DataRegisto = DateTime.Now, ClienteId = 3, FilmeId = 2, DescontoId = 3 }
                );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente() { Id = 1, Nome = "Ana" },
                new Cliente() { Id = 2, Nome = "Bruno" },
                new Cliente() { Id = 3, Nome = "Rui" }
                );

            modelBuilder.Entity<Filme>().HasData(
                new Filme() { Id = 1, Nome = "Alien", Genero = "Ficçao" },
                new Filme() { Id = 2, Nome = "Carros", Genero = "Corrida" },
                new Filme() { Id = 3, Nome = "Vida", Genero = "Romance" }
                );

            modelBuilder.Entity<Desconto>().HasData(
                new Desconto() { Id = 1, Descricao = "Adulto", Preco = 8 },
                new Desconto() { Id = 2, Descricao = "Estudante", Preco = 6 },
                new Desconto() { Id = 3, Descricao = "Criança", Preco = 4 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
