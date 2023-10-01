using FluentValidation;

namespace CustomKeyboardsCalculator.Core.Operations.Calculate.Queries.TryCalculate
{
    public class TryCalculateQueryValidate : AbstractValidator<TryCalculateQuery>
    {
        public TryCalculateQueryValidate()
        {
            RuleFor(cp => cp.CalculatorParametersViewModel.Expression)
                .NotEmpty().WithMessage("The expression cannot be null");
        }
    }
}
