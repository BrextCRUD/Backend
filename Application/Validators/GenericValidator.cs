using FluentValidation;
using System.Linq.Expressions;

namespace Application.Validators
{
    public class GenericValidator<T> : AbstractValidator<T>
    {
        public GenericValidator(Expression<Func<T, string>> propertySelector, string propertyName)
        {
            RuleFor(propertySelector)
                .NotEmpty().WithMessage($"{propertyName} es obligatorio.")
                .MaximumLength(100).WithMessage($"{propertyName} no puede tener más de 100 caracteres.");
        }
    }
}
