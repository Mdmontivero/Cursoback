using Cursoback.DTOs;
using FluentValidation;

namespace Cursoback.Validator
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
        }
    }
}
