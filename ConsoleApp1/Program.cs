using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;


//      Install-Package Microsoft.EntityFrameworkCore -Version ...
//      Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version ...
//      Install-Package Microsoft.EntityFrameworkCore.Tools -Version ...
//      Vou usar -Version 6.0.10 para .NET 6
//      Add-Migration Versao01...02...
//      Remove-Migration
//      Update-Database

namespace ConsoleApp1
{
    /// <summary>
    /// App Billheteira, em que um bilhete tem as propriedades Filme, Desconto e Cliente.
    /// 
    /// Bilhete:
    /// -Id
    /// - Data  -> data de compra do Bilhete
    /// - Stock -> numero  de Bilhetes possiveis para compra
    /// 
    /// 1-M Filme:
    /// - Id
    /// - Nome
    /// - Genero
    /// 
    /// 1-M Desconto:
    /// - Id
    /// - Descricao -> Tipo de desconto
    /// - Preco
    /// 
    /// 1-M Clinte:
    /// - Id
    /// - Nome
    /// </summary>  
    public class Program
    {
        static void Main(string[] args)
        {
            Crud crud = new Crud(); 
            Bilhete bilhete = new Bilhete();
            Cliente cliente= new Cliente();
            Desconto desconto = new Desconto();
            Filme filme = new Filme();

            string objString;
            int objInt;
            string resposta;

            Console.WriteLine("Exer Bilheteira com SQL");
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("MenuSQL Bilheteira:\n[1]Inserir Bilhete\n[2]Mostrar um só Bilhete\n[3]Apagar Bilhete\n[4]Mostrar todos Bilhetes\n[5]Update Bilhete\n[6]Inserir Cliente\n[7]Apagar Cliente\n[8]Mostrar todos Clientes\n[0]Se desejar terminar.");
                Console.WriteLine("-------------------------------------------------------");
                resposta = Console.ReadLine();

                switch (resposta)
                {
                    case "1":
                        bilhete.DataRegisto = DateTime.Now;

                        Console.WriteLine("Inserir Bilhete");
                        Console.WriteLine("---------------");

                        Console.WriteLine("Clientes:--------------------");
                        crud.GetTodosClientes();
                        Console.Write($"\nColoque o Id[?] do cliente:");
                        objInt = int.Parse(Console.ReadLine());
                        bilhete.ClienteId = objInt;

                        Console.WriteLine("Genero de Filme:--------------------");
                        crud.GetTodosFilmes();
                        Console.Write($"\nFilme [1]Alien [2]Carros [3]Vida:");
                        objInt = int.Parse(Console.ReadLine());
                        bilhete.FilmeId = objInt;
                                  
                        Console.WriteLine("Descricao de desconto:------------------------");
                        crud.GetTodosDescontos();
                        Console.Write($"\nDesconto [1]Adulto [2]Estudante [3]Criança:");                       
                        objInt = int.Parse(Console.ReadLine());
                        bilhete.DescontoId = objInt;

                  //    Console.WriteLine($"Preco do Bilhete: {desconto.Preco}");
                                   
                        crud.InsertBilhete(bilhete);       // da erro o inserir o bilhete             
                        bilhete = new Bilhete();                            
                        break;

                    case "2":
                        Console.WriteLine($"Procurar um Bilhete por Id"); // da erro má leitura implementada (crud) a partir do seeding da database
                        Console.WriteLine("---------------------------");
                        Console.Write($"\nColoque o Id do Bilhete: ");
                        objInt = int.Parse(Console.ReadLine());
                        crud.GetBilhete(objInt);
                        break;

                    case "3":
                        Console.WriteLine($"Apagar Bilhete por Id"); 
                        Console.WriteLine("----------------------");
                        crud.GetTodosBilhetes();
                        Console.Write($"\n Coloque o Id do Bilhete: ");
                        objInt = int.Parse(Console.ReadLine());
                        crud.DeleteBilhete(objInt);
                        break;

                    case "4":
                        Console.WriteLine($"Mostrar todos os Bilhetes"); 
                        Console.WriteLine("--------------------------");
                        crud.GetTodosBilhetes();
                      //  resposta = null;
                      //  Console.WriteLine("TESTE="+resposta);
                        break;

                    case "5":
                        Console.WriteLine($"Atualizar Bilhete"); // da erro má leitura implementada (crud) a partir do seeding da database
                        Console.WriteLine("---------------------------------------------");
                        crud.GetTodosBilhetes();
                        Console.Write($"\nColoque o Id do Bilhete que deseja atualizar: ");
                        objInt = int.Parse(Console.ReadLine());
                        crud.UpdateBilhete(objInt);
                        break;

                    case "6":
                        Console.WriteLine("Inserir Cliente");
                        Console.WriteLine("---------------");
                        Console.Write($"Nome do Cliente: ");
                        objString = Console.ReadLine();
                        cliente.Nome = objString;
                        //bilhete.ClienteId = cliente.Id;
                        crud.InsertCliente(cliente);
                        cliente = new Cliente();
                        break;

                    case "7":
                        Console.WriteLine($"Apagar Cliente por Id");                     
                        Console.WriteLine("----------------------");
                        crud.GetTodosClientes();
                        Console.Write($"Coleque o Id do cliente: ");
                        objInt = int.Parse(Console.ReadLine());
                        crud.DeleteCliente(objInt);
                        break;

                    case "8":
                        Console.WriteLine($"Mostrar todos os Clientes");
                        Console.WriteLine("--------------------------");
                        crud.GetTodosClientes();
                        break;

                    case "0":
                        Console.WriteLine("----------------");
                        Console.WriteLine("Fim do Programa!");
                        break;

                    default:
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Não selecionou uma opção correta.");
                        break;
                }

                if (resposta == "0")
                {
                    break;
                }
            }
        }
    }
}
