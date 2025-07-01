using Microsoft.AspNetCore.Mvc;

namespace Atomic_Crud.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(100);
            return Ok(new { Message = "Its Working!!" });
        }
    }
}
