namespace AppReceitas.Application.DTOs
{
    public class PaginationFilterEvaluationRequest
    {
        private int DEFAULT_PAGE_SIZE = 10;
        public PaginationFilterEvaluationRequest()
        {
            PageIndex = 0;
            PageSize = DEFAULT_PAGE_SIZE;
        }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public FilterEvaluationDTO? FilterEvaluation { get; set; }
    }
}
