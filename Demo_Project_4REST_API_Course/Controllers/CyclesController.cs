using Demo_Project_4REST_API_Course.Models;
using Demo_Project_4REST_API_Course.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CyclesController : ControllerBase
    {
        private readonly ICycleService _cycleService;

        public CyclesController(ICycleService cycleService)
        {
            _cycleService = cycleService;
        }

        [HttpGet(Name = nameof(GetCycles))]
        public IActionResult GetCycles()
        {
            var reponse = new
            {
                href = Url.Link(nameof(GetCycles), null)
            };

            return Ok(reponse);
        }

        [HttpGet("{cycleId}", Name = nameof(GetCycleById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Cycle>> GetCycleById(int cycleId)
        {
            var cycle = await _cycleService.GetCycleAsync(cycleId);
            if (cycle == null) return NotFound();
            return Ok(cycle);
        }
    }
}
