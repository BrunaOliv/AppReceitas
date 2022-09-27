using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppReceitas.Application.DTOs
{
    public class RecipeDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Ingredients is required.")]
        [MinLength(5)]
        [DisplayName("Ingredients")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "The PreparationMode is required.")]
        [MinLength(5)]
        [DisplayName("PreparationMode")]
        public string PreparationMode { get; set; }

        [MaxLength(250)]
        [DisplayName("Image")]
        public string? Image { get; set; }

        public CategoryDTO? Category { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }
        public LevelDTO? Level { get; set; }
        public int LevelId { get; set; }
    }
}
