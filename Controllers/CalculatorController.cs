using GaiaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Project_Gaya.DTOs;
using Project_Gaya.Models;

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


                if (!Enum.TryParse<OperationType>(request.Operation, true, out var operationType))
                {
                    return BadRequest("Invalid operation");
                }


                var response = _calculator.CalculateWithHistory(operationType, request.A, request.B);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
