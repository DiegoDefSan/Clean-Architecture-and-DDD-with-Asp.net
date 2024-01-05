using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(streamerCommand => streamerCommand.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no peude exceder los 50 caracteres");

            RuleFor(streamerCommand => streamerCommand.Url)
                .NotEmpty().WithMessage("La {Url} no puede estar en blanco");
        }
    }
}
