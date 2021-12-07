using Demo_Project_4REST_API_Course.Models;
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
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {   
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var reponse = new RootResponse()
            {
                Self =Link.To(nameof(GetRoot)),
                Courses = Link.To(nameof(CoursesController.GetCourses)),
                Cycles = Link.To(nameof(CyclesController.GetCycles))
            };

            return Ok(reponse);
        }
    }
}
