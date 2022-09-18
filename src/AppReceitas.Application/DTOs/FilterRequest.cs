using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.DTOs
{
    public class FilterRequest
    {
        public string? NameRecipe { get; set; }
        public string? Categoria { get; set; }
        public string? Nivel { get; set; }
    }
}
