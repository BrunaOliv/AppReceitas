using ProductCatalog.Domain.Entities.Validation;

namespace ProductCatalog.Domain.Entities
{
    public class SubCategory : Entity
    {
        public string Name { get; private set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Product> Products { get; private set; }

        public SubCategory(string name)
        {
            ValidationDomain(name);
        }

        public SubCategory(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(name);
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecters");

            Name = name;
        }
    }
}
