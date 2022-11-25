using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Crud
    {
        public MeuContexto ctx = new MeuContexto();

        /* Exemplo da Aula
        foreach (var p in bd.Produtos.Include(produto=>produto.Subcategoria).ThenInclude(subcategoria => subcategoria.Categoria))
            {
                Console.WriteLine($"Id: {p.Id}, Nome: {p.Nome}, E TEM A SUBCATEGORIA: {p.Subcategoria.Nome} E TEM A CATEGORIA {p.Subcategoria.Categoria.Nome}");
            }
        */
        // var queryregisto = bd.Produtos.Find(id);


        //Delete um registo da BD-----------------------------------------------------------------------------------------------------------------------------------------------------

        public Bilhete? DeleteBilhete(int id) //APAGAR Bilhete NA BD 
        {
            Bilhete aApagar = ctx.Bilhetes.Find(id);
            ctx.Bilhetes.Remove(aApagar);
            ctx.SaveChanges();
            return null;
        }

        public Cliente? DeleteCliente(int id) //APAGAR Cliente NA BD 
        {
            Cliente aApagar = ctx.Clientes.Find(id);
            ctx.Clientes.Remove(aApagar);
            ctx.SaveChanges();
            return null;
        }

        //Mostrar um Registo da BD----------------------------------------------------------------------------------------------------------------------------------------------------

        public Bilhete? GetBilhete(int id)//Ler um SÓ Bilhete DA BD: xxxxxxx  má leitura implementada a partir do seeding da database
        {
            Bilhete procurado = ctx.Bilhetes.Include(bilhete => bilhete.Cliente).Include(bilhete => bilhete.Desconto).Include(bilhete => bilhete.Filme).First(b=>b.Id==id);
            Console.WriteLine($"O Bilhete procurado pelo Id[{id}] é descrito como:");
            Console.WriteLine($"Id do Bilhete: {procurado.Id}, Nome do Cliente: {procurado.Cliente.Nome}, Filme: {procurado.Filme.Nome}"); //erro deve ser esta linha
            return null;
        }

        //Mostrar varios registos da BD-----------------------------------------------------------------------------------------------------------------------------------------------

        public IList<Bilhete>? GetTodosBilhetes()//LER Todos Bilhetes DA BD:
        {
            foreach (var a in ctx.Bilhetes.Include(bilhete=>bilhete.Cliente).Include(bilhete=>bilhete.Desconto).Include(bilhete=>bilhete.Filme))
            {
                Console.WriteLine($"Id do Bilhete: {a.Id}, Nome do Cliente: {a.Cliente.Nome}, Desconto: {a.Desconto.Descricao}, Preco: {a.Desconto.Preco}, Filme: {a.Filme.Nome} ");
            }
            return null;
        }

        public IList<Cliente>? GetTodosClientes()//LER Todos Clientes DA BD:
        {
            foreach (var a in ctx.Clientes)
            {
                Console.WriteLine($"Id: {a.Id}, Nome: {a.Nome}");
            }
            return null;
        }

        public IList<Desconto>? GetTodosDescontos()//LER Todos Descontos DA BD:
        {
            foreach (var a in ctx.Descontos)
            {
                Console.WriteLine($"Id: {a.Id}, Descricao: {a.Descricao}, Preco: {a.Preco}");
            }
            return null;
        }

        public IList<Filme>? GetTodosFilmes()//LER Todos Filmes DA BD:
        {
            foreach (var a in ctx.Filmes)
            {
                Console.WriteLine($"Id: {a.Id}, Nome do Filme: {a.Nome}, Genero: {a.Genero}");
            }
            return null;
        }

        //inserir registos na BD-------------------------------------------------------------------------------------------------------------------------------------------------------

        public Bilhete? InsertBilhete(Bilhete bilhete)//inserir Bilhete 
        {
            ctx.Bilhetes.Add(bilhete);
            ctx.SaveChanges();
            return null;
        }

        public Cliente? InsertCliente(Cliente cliente)//inserir cliente
        {
            ctx.Clientes.Add(cliente);
            ctx.SaveChanges();
            return null;
        }

        //Update registo na BD---------------------------------------------------------------------------------------------------------------------------------------------------------

        public Bilhete? UpdateBilhete(int id)//Update tipo de filme xxxxxx  má leitura implementada a partir do seeding da database
        {
            Bilhete procurado = ctx.Bilhetes.Include(bilhete => bilhete.Filme).First(b => b.Id == id);
            Console.Write($"Mudar o Filme: Alien[1], Carros[2], Vida[3]: ");
            int IDfilme =int.Parse(Console.ReadLine());          
            procurado.FilmeId = IDfilme;
            ctx.SaveChanges();
            Console.Write($"O Bilhete com Id {procurado.Id} ficou com o Filme: ");
         
            Console.WriteLine($"{procurado.Filme.Nome}, Genero: {procurado.Filme.Genero}"); // xxxxxx erro deve ser esta linha
            return null;
        }
    }
}
