using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosDeCarros
{
    class Carro
    {
        
        public string Marca { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Nome { get { return Marca + " - " + Ano + " - " + Cor; } }
        public Guid ID { get; set; }
        

    }
}
