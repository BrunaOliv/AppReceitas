using AppReceitas.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Entities
{
    public class Recipes : Entity
    {
        public string Nome { get; private set; }
        public string Ingredientes { get; private set; }
        public string ModoDePreparo { get; private set; }
        public string  Imagem { get; private set; }

        public Recipes(string nome, string ingredientes, string modoDePreparo, string imagem)
        {
            ValidateDomain(nome, ingredientes, modoDePreparo, imagem);
        }
        public Recipes(int id, string nome, string ingredientes, string modoDePreparo, string imagem)
        {
            DomainExceptionValidation.When(id < 0, "Valor inválido.");
            Id = id;
            ValidateDomain(nome, ingredientes, modoDePreparo, imagem);
        }

        public void Update(string nome, string ingredientes, string modoDePreparo, string imagem, int categoriaId)
        {
            ValidateDomain(nome, ingredientes, modoDePreparo, imagem);
            CategoriaId = categoriaId;
        }

        private void ValidateDomain(string nome, string ingredientes, string modoDePreparo, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido.");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. Minimo 3 caracter.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(ingredientes), "Ingredientes inválido.");
            DomainExceptionValidation.When(ingredientes.Length < 5, "Ingredientes inválido. Minimo 5 caracter.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(modoDePreparo), "Modo de preparo inválido.");
            DomainExceptionValidation.When(modoDePreparo.Length < 5, "Modo de preparo inválido. Minimo 5 caracter.");
            DomainExceptionValidation.When(imagem.Length > 250, "Imagem inválida. Maximo 250 caracter.");

            Nome = nome;
            Ingredientes = ingredientes;
            ModoDePreparo = modoDePreparo;
            Imagem = imagem;

        }
        public int CategoriaId { get; set; }
        public Category Categoria { get; set; }
    }
}
