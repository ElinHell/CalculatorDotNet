using GaiaProject.Models;
using GaiaProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace GaiaProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorService _calculator;

        public CalculatorController(CalculatorService calculator)
        {
            _calculator = calculator;
        }


        [HttpPost("calculate")]
        public ActionResult<CalculateResponse> Calculate([FromBody] CalculateRequest request)
        {
            try
            {
                double result = _calculator.CalculateAndSave(request.Operation, request.A, request.B);
                return Ok(new CalculateResponse { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }



        }
    }
}
