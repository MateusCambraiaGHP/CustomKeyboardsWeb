using CustomKeyboardsCalculator.Core.Operations.Calculate.Queries.TryCalculate;
using CustomKeyboardsCalculator.Core.Operations.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<TryCalculateQueryResponse> Calculate(CalculatorParametersViewModel parameters)
        {
            var response = await _mediator.Send(new TryCalculateQuery(parameters));
            return response;
        }
    }
}
