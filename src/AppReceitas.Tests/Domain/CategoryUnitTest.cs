using AppReceitas.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace AppReceitas.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void CreateCatgory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<AppReceitas.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCatgory_WithInvalidName_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, minimum 3 caracters.");
        }
        [Fact]
        public void CreateCatgory_WithEmpytName_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name.");
        }
        [Fact]
        public void CreateCatgory_WithNegativeValue_ResultObjectInvalidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<AppReceitas.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid value.");
        }
    }
}