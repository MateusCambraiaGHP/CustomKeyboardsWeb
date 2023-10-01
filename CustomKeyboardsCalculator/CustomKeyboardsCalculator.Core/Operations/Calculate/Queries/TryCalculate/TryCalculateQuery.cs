using CustomKeyboardsCalculator.Core.Operations.ViewModels;
using MediatR;

namespace CustomKeyboardsCalculator.Core.Operations.Calculate.Queries.TryCalculate
{
    public class TryCalculateQuery : IRequest<TryCalculateQueryResponse>
    {
        public CalculatorParametersViewModel CalculatorParametersViewModel { get; set; }
        public TryCalculateQuery(CalculatorParametersViewModel calculatorParametersViewModel) => CalculatorParametersViewModel = calculatorParametersViewModel;
    }
}
