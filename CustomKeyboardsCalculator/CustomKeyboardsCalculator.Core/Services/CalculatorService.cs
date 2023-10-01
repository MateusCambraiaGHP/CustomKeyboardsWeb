using NCalc;

namespace CustomKeyboardsCalculator.Core.Services
{
    public class CalculatorService
    {
        public async Task<string> Calculate(string expression)
        {
            Expression expressionResponse = new Expression(expression);
            object result = expressionResponse.Evaluate();
            return result.ToString();
        }
    }
}
