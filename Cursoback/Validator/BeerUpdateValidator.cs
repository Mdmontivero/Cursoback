using Cursoback.DTOs;
using FluentValidation;

namespace Cursoback.Validator
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("No puede esta vacio perro!");
            RuleFor(x => x.Id).NotNull().WithMessage(" Id obligatorio");
            
        }
    }
}
