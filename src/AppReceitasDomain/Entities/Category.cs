using AppReceitas.Domain.Validation;

namespace AppReceitas.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Recipes> Recipes{ get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value.");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name, minimum 3 caracters.");

            Name = name;
        }
    }
}
