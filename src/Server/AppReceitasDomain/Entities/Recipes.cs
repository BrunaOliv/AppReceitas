using AppReceitas.Domain.Validation;

namespace AppReceitas.Domain.Entities
{
    public class Recipes : Entity
    {
        public string Name { get; private set; }
        public string Ingredients { get; private set; }
        public string PreparationMode { get; private set; }
        public string Image { get; private set; }

        public Recipes(string name, string ingredients, string preparationMode, string image)
        {
            ValidateDomain(name, ingredients, preparationMode, image);
        }
        public Recipes(int id, string name, string ingredients, string preparationMode, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value.");
            Id = id;
            ValidateDomain(name, ingredients, preparationMode, image);
        }

        public void Update(string name, string ingredients, string preparationMode, string image, int categoryId, int levelId)
        {
            ValidateDomain(name, ingredients, preparationMode, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string ingredients, string preparationMode, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name, minimum 3 caracters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(ingredients), "Invalid Ingredients.");
            DomainExceptionValidation.When(ingredients.Length < 5, "Invalid Ingredients, minimum 5 caracters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(preparationMode), "Invalid preparation mode.");
            DomainExceptionValidation.When(preparationMode.Length < 5, "Invalid preparation mode, minimum 5 caracters.");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image, maximum 250 caracters.");

            Name = name;
            Ingredients = ingredients;
            PreparationMode = preparationMode;
            Image = image;

        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
