using AppReceitas.Domain.Validation;

namespace AppReceitas.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Recipes> Receitas{ get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor invalido.");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome invalido");
            DomainExceptionValidation.When(name.Length < 3, "Nome invalido, minimo 3 caracter.");

            Name = name;
        }
    }
}
