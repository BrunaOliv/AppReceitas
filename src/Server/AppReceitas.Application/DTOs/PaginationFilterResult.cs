using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.DTOs
{
    public class PaginationFilterResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Data { get; set; }
    }
}
