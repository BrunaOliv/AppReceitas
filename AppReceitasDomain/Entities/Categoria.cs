using AppReceitas.Domain.Validation;

namespace AppReceitas.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public ICollection<Receitas> Receitas{ get; private set; }

        public Categoria(string nome)
        {
            ValidateDomain(nome);
        }
        public Categoria(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "Valor invalido.");
            Id = id;
            ValidateDomain(nome);
        }
        public void Update(string nome)
        {
            ValidateDomain(nome);
        }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome invalido");
            DomainExceptionValidation.When(nome.Length < 3, "Nome invalido, minimo 3 caracter.");

            Nome = nome;
        }
    }
}
