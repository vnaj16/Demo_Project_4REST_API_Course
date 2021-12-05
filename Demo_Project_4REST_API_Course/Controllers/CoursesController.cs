using Microsoft.AspNetCore.Mvc;

namespace Demo_Project_4REST_API_Course.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CoursesController : ControllerBase
    {
        [HttpGet(Name = nameof(GetCourses))]
        public IActionResult GetCourses()
        {
            var reponse = new
            {
                href = Url.Link(nameof(GetCourses), null)
            };

            return Ok(reponse);
        }
    }
}
