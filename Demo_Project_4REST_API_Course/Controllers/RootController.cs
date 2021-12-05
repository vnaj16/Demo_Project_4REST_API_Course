using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Controllers
{
    [ApiController]
    [Route("/")]
    public class RootController : ControllerBase
    {   
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var reponse = new
            {
                href = Url.Link(nameof(GetRoot),null),
                courses = new
                {
                    href = Url.Link(nameof(CoursesController.GetCourses), null),
                },
                cycles = new
                {
                    href = Url.Link(nameof(CyclesController.GetCycles), null),
                }
            };

            return Ok(reponse);
        }
    }
}
