using AppReceitas.Domain.Validation;

namespace AppReceitas.Domain.Entities
{
    public class Evaluation : Entity
    {
        public int Grade { get; private set; }
        public string? Comment { get; private set; }
        public Recipes Recipe { get; private set; }
        public int RecipeId { get; private set; }

        public Evaluation(int id, int grade)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value.");
            Id = id;
            ValidateDomain(grade);
        }

        public Evaluation(int id, int grade, string comment)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value.");
            Id = id;
            ValidateDomain(grade);
            Comment = comment;
        }

        private void ValidateDomain(int grade)
        {
            DomainExceptionValidation.When(grade < 0, "Invalid Grade.");
            DomainExceptionValidation.When(grade > 5, "Invalid Grade.");

            Grade = grade;
        }
    }
}
