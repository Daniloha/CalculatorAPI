using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Calculadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;
        

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber)) { 
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("product/{firstNumber}/{secondNumber}")]
        public IActionResult Prod(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var prod = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(prod.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var First = ConvertToDecimal(firstNumber);
                var Second = ConvertToDecimal(secondNumber);
                if (First >= Second)
                {
                    var div = First / Second;
                    return Ok(div.ToString());
                }
                return BadRequest("Invalid Input");
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("rsquare/{Number}")]
        public IActionResult Square(double Number)
        {
            try
            {
                var square = Math.Sqrt(Number);
                return Ok(square.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex + "Invalid Input");
            }
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}/{thirdnumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber, string thirdnumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber) && IsNumeric(thirdnumber))
            {
                var mean = (ConvertToDecimal(firstNumber) 
                    + ConvertToDecimal(secondNumber) 
                    + ConvertToDecimal(thirdnumber))/3;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}
