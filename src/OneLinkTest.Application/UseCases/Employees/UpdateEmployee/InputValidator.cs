using FluentValidation;

namespace OneLinkTest.Application.UseCases.Employees.UpdateEmployee
{
    public class InputValidator : AbstractValidator<Input>
    {
        public InputValidator()
        {
            RuleFor(i => i.Document).GreaterThan(1)
                .LessThan(10_000_000_000)
                .WithMessage("Documento fuerda de rango");
            RuleFor(i => i.FirstName).Length(1, 80)
                .WithMessage("El nombre es requerido");
            RuleFor(i => i.LastName).Length(1, 80)
                .WithMessage("El apellido es requerido");
        }
    }
}
