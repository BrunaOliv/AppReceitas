using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Entities
{
    public class Categoria
    {
        public string Name { get; set; }

        public ICollection<Receitas> Receitas{ get; set; }
    }
}
