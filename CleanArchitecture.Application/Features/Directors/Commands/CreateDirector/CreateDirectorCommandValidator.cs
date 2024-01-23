using FluentValidation;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(director => director.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(director => director.Apellido)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");
        }
    }
}
