using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MeuContexto : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Desconto> Descontos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Bilhete> Bilhetes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\mssqllocaldb; DATABASE=Bilheteira; TRUSTED_CONNECTION=TRUE;");

            base.OnConfiguring(optionsBuilder);
        }

        //MÉTODO QUE PERMITE FAZER O SEEDING DA BD:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Bilhete>().HasData(
                new Bilhete() { Id = 1, DataRegisto = DateTime.Now, ClienteId = 1, FilmeId = 3, DescontoId = 2},
                new Bilhete() { Id = 2, DataRegisto = DateTime.Now, ClienteId = 2, FilmeId = 1, DescontoId = 1},
                new Bilhete() { Id = 3, DataRegisto = DateTime.Now, ClienteId = 3, FilmeId = 2, DescontoId = 3}
                );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente() { Id = 1, Nome = "Ana"},
                new Cliente() { Id = 2, Nome = "Bruno"},
                new Cliente() { Id = 3, Nome = "Rui" }
                );

            modelBuilder.Entity<Filme>().HasData(
                new Filme() { Id = 1, Nome = "Alien", Genero = "Ficçao"},
                new Filme() { Id = 2, Nome = "Carros", Genero = "Corrida"},
                new Filme() { Id = 3, Nome = "Vida", Genero = "Romance"}
                );

            modelBuilder.Entity<Desconto>().HasData(
                new Desconto() { Id = 1, Descricao = "Adulto", Preco = 8},
                new Desconto() { Id = 2, Descricao = "Estudante", Preco = 6},
                new Desconto() { Id = 3, Descricao = "Criança", Preco = 4}
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
