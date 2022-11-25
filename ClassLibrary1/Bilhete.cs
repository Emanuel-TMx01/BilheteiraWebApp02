using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Bilhete
    {
        public int Id { get; set; }
        public int Stock { get; set; } = 35; //a sala de cinema tem 35 lugares
        public DateTime DataRegisto { get; set; }

        //Implementação da relação: 1 Bilhete tem 1 Filme:
        public int FilmeId { get; set; } //Esta prop. vai de facto ser a coluna Foreign Key (FK) criada na BD.
        public Filme Filme { get; set; } //Esta prop. é chamada de Propriedade de Navegação.

        //Implementação da relação: 1 Bilhete tem 1 Desconto:
        public int DescontoId { get; set; } //Esta prop. vai de facto ser a coluna Foreign Key (FK) criada na BD.
        public Desconto Desconto { get; set; } //Esta prop. é chamada de Propriedade de Navegação. 

        //Implementação da relação: 1 Bilhete tem 1 Cliente:
        public int ClienteId { get; set; } //Esta prop. vai de facto ser a coluna Foreign Key (FK) criada na BD.
        public Cliente Cliente { get; set; } //Esta prop. é chamada de Propriedade de Navegação. 

    }
}