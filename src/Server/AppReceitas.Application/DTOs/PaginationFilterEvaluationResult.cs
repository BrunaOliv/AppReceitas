namespace AppReceitas.Application.DTOs
{
    public class PaginationFilterEvaluationResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Data { get; set; }
    }
}
