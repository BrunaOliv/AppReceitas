using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Application.DTOs
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        public CategoryDTO? Category { get; set; }
        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}
