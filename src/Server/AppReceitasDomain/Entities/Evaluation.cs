using AppReceitas.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Entities
{
    public class Evaluation: Entity
    {
        public int Grade { get; private set; }
        public string? Comment { get; private set; }
        public Recipes Recipe { get; private set; }
        public int RecipeId { get; private set; }

        public Evaluation(int id, int grade)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value.");
            Id = id;
            ValidateDomain(grade, null);
        }

        public Evaluation(int id, int grade, string comment)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value.");
            Id = id;
            ValidateDomain(grade, comment);
        }

        private void ValidateDomain(int grade, string? comment)
        {
            DomainExceptionValidation.When(grade < 0, "Invalid Grade.");
            DomainExceptionValidation.When(grade > 5, "Invalid Grade.");
            DomainExceptionValidation.When(comment.Length < 3, "Invalid comment, minimum 3 caracters.");

            Grade = grade;
            Comment = comment;
        }
    }
}
