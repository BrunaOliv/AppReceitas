namespace AppReceitas.Application.DTOs
{
    public class PaginationFilterResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Data { get; set; }
    }
}
