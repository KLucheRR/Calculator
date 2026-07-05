using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers.Calculator
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        [HttpPost("Calculate")]
        public ActionResult<double> Calculate([FromBody] Query query)
        {
            try
            {
                var result = query.Type switch
                {
                    OperationType.Sum => CalculatorCore.Calculator.Sum(query.Args.ToArray()),
                    OperationType.Substract => CalculatorCore.Calculator.Substract(query.Args.ToArray()),
                    OperationType.Multiply => CalculatorCore.Calculator.Multiply(query.Args.ToArray()),
                    OperationType.Divide => CalculatorCore.Calculator.Divide(query.Args.ToArray()),
                    _ => throw new NotImplementedException()
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Conflict(ex.ToString());
            }
        }
    }
}
