using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.DTOs
{
    public class PaginationFilterRequest
    {
        private int DEFAULT_PAGE_SIZE = 20;
        public PaginationFilterRequest()
        {
            PageIndex = 0;
            PageSize = DEFAULT_PAGE_SIZE;
        }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public FilterRequest? Filter { get; set; }
    }
}
