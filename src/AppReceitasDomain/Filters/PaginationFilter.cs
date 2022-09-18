using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Filters
{
    public class PaginationFilter<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }
        public List<T> Data { get; set; }
        public Filter? Filter { get; set; }
    }
}
