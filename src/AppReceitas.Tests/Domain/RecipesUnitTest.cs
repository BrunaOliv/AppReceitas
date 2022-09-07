using AppReceitas.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppReceitas.Tests
{
    public class RecipesUnitTest
    {
        [Fact]
        public void CreateRecipes_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Recipes(1, "Recipes Name", "Ingredients", "Modo de preparo", "image");
            action.Should()
                .NotThrow<AppReceitas.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateRecipes_WithNegativeId_DomainException()
        {
            Action action = () => new Recipes(-1, "Recipes Name", "Ingredients", "Modo de preparo", "image");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid value.");
        }
        [Fact]
        public void CreateRecipes_WithNullName_DomainException()
        {
            Action action = () => new Recipes(1, null, "Ingredients", "Modo de preparo", "image");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name.");
        }
        [Fact]
        public void CreateRecipes_WithInvalidName_DomainException()
        {
            Action action = () => new Recipes(1, "re", "Ingredients", "Modo de preparo", "image");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, minimum 3 caracters.");
        }

        [Fact]
        public void CreateRecipes_WithNullIngredient_DomainException()
        {
            Action action = () => new Recipes(1, "Recipes Name", null, "Modo de preparo", "image");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Ingredients.");
        }
        [Fact]
        public void CreateRecipes_WithInvalidIngredient_DomainException()
        {
            Action action = () => new Recipes(1, "Recipes Name", "In", "Modo de preparo", "image");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Ingredients, minimum 5 caracters.");
        }

        [Fact]
        public void CreateRecipes_WithNullPreaparationMode_DomainException()
        {
            Action action = () => new Recipes(1, "Recipes Name", "Ingredients", null, "image");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid preparation mode.");
        }
        [Fact]
        public void CreateRecipes_WithInvalidPreaparationMode_DomainException()
        {
            Action action = () => new Recipes(1, "Recipes Name", "Ingredients", "Modo", "image");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid preparation mode, minimum 5 caracters.");
        }
        [Fact]
        public void CreateRecipes_WithInvalidImage_DomainException()
        {
            Action action = () => new Recipes(1, "Recipes Name", "Ingredients", "Modo de preparo", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web ");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image, maximum 250 caracters.");
        }
        [Fact]
        public void CreateRecipes_WithEmptyImage_NoDomainException()
        {
            Action action = () => new Recipes(1, "Recipes Name", "Ingredients", "Modo de preparo", "");
            action.Should()
                .NotThrow<AppReceitas.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateRecipes_WithNullImage_NoDomainException()
        {
            Action action = () => new Recipes(1, "Recipes Name", "Ingredients", "Modo de preparo", null);
            action.Should()
                .NotThrow<AppReceitas.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreatProduct_NullImageNameValue_NoNullReferenceException()
        {
            Action action = () => new Recipes(1, "Recipes Name", "Ingredients", "Modo de preparo", null);
            action.Should().NotThrow<NullReferenceException>();
        }
    }
}
