using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Entities
{
    public class Receitas
    {
        public string Name { get; private set; }
        public string Ingredientes { get; private set; }
        public string ModoDePreparo { get; private set; }
        public string  Imagem { get; private set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
