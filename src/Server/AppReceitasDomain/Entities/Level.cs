using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Entities
{
    public  class Level : Entity
    {
        public string Name { get; private set; }
        public ICollection<Recipes> Recipes { get; private set; }

        public Level(int id, string name)
        {
            Id = id;   
            Name = name;
        }
    }
}
