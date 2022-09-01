using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Entities
{
    public class Receitas
    {
        public string Name { get; set; }
        public string Ingredientes { get; set; }
        public string ModoDePreparo { get; set; }
        public string  Imagem { get; set; }
        public Categoria Categoria { get; set; }
    }
}
