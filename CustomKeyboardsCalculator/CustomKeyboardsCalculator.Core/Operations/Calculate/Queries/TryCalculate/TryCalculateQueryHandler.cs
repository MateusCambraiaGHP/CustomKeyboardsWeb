using CustomKeyboardsCalculator.Core.Operations.ViewModels;
using CustomKeyboardsCalculator.Core.Services;
using MediatR;

namespace CustomKeyboardsCalculator.Core.Operations.Calculate.Queries.TryCalculate
{
    public class TryCalculateQueryHandler : IRequestHandler<TryCalculateQuery, TryCalculateQueryResponse>
    {
        public TryCalculateQueryHandler() { }

        public async Task<TryCalculateQueryResponse> Handle(TryCalculateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var calculatorService = new CalculatorService();
                var expressionResult = await calculatorService.Calculate(request.CalculatorParametersViewModel.Expression);

                var response = new CalculatorResponseViewModel
                {
                    Result = expressionResult
                };

                return new TryCalculateQueryResponse(response, "Operação realizada com sucesso");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
