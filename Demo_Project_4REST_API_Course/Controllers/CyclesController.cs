using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Project_4REST_API_Course.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CyclesController : ControllerBase
    {
        [HttpGet(Name = nameof(GetCycles))]
        public IActionResult GetCycles()
        {
            var reponse = new
            {
                href = Url.Link(nameof(GetCycles), null)
            };

            return Ok(reponse);
        }
    }
}
