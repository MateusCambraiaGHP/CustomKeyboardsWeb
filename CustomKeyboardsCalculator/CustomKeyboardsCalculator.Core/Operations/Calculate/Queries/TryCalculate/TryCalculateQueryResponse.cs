using CustomKeyboardsCalculator.Core.Abstractions.Messages;
using CustomKeyboardsCalculator.Core.Operations.ViewModels;

namespace CustomKeyboardsCalculator.Core.Operations.Calculate.Queries.TryCalculate
{
    public class TryCalculateQueryResponse : BaseHandlerResponse
    {
        public CalculatorResponseViewModel Result { get; set; }

        public TryCalculateQueryResponse() { }

        public TryCalculateQueryResponse(CalculatorResponseViewModel result) => Result = result;

        public TryCalculateQueryResponse(CalculatorResponseViewModel result, string message = "")
            : base(message)
        {
            Result = result;
        }


        public TryCalculateQueryResponse(bool success, string message = "")
        : base(success, message) { }
    }
}
