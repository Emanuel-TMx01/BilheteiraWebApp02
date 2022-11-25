using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }

        //Implmentação da relação: Um filme tem Muitos Bilhetes:
        public ICollection<Bilhete> Bilhetes { get; set; } //Esta prop. é chamade de Prorpiedade de Navegação.
    }
}
