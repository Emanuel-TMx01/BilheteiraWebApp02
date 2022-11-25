using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Desconto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        //Implmentação da relação: Um Desconto tem Muitos Bilhetes:
        public ICollection<Bilhete> Bilhetes { get; set; } //Esta prop. é chamade de Prorpiedade de Navegação
    }
}
