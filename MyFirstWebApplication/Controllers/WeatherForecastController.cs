using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpPut("add")]
        public ActionResult<int> Add([FromBody] AddNumbersRequest request)
        {
            return Ok(request.Number1 + request.Number2);
        }
    }
    public class AddNumbersRequest
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
