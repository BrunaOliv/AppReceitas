using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Filters
{
    public class Filter
    {
        public string? NameRecipe { get; set; }
        public string? Category { get; set; }
        public string? Level { get; set; }
    }
}
