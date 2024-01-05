using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(updateStreamerCommand => updateStreamerCommand.Nombre)
                .NotNull().WithMessage("{Nombre} no permite valores nulos");

            RuleFor(updateStreamerCommand => updateStreamerCommand.Url)
                .NotNull().WithMessage("{Url} no permite valores nulos");
        }
    }
}
