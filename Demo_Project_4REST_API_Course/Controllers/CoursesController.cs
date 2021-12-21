using Demo_Project_4REST_API_Course.Models;
using Demo_Project_4REST_API_Course.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [ApiVersion("1.0")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly PagingOptions _defaultPagingOptions;
        public CoursesController(ICourseService courseService, IOptions<PagingOptions> defaultPagingOptions)
        {
            _courseService = courseService;
            _defaultPagingOptions = defaultPagingOptions.Value;
        }

        [HttpGet(Name = nameof(GetAllCourses))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Collection<Course>>> GetAllCourses(
            [FromQuery] PagingOptions pagingOptions,
            [FromQuery] SortOptions<Course,CourseEntity> sortOptions,
            [FromQuery] SearchOptions<Course, CourseEntity> searchOptions)
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var courses = await _courseService.GetCoursesAsync(pagingOptions, sortOptions, searchOptions);

            var collection = PagedCollection<Course>.Create(
                Link.ToCollection(nameof(GetAllCourses)),
                courses.Items.ToArray(),
                courses.TotalSize,
                pagingOptions);

            return collection;
        }

        [HttpGet("{courseId}", Name = nameof(GetCourseById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Course>> GetCourseById(int courseId)
        {
            var course = await _courseService.GetCourseAsync(courseId);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost(Name = nameof(CreateCourse))]
        [ProducesResponseType(201)]
        public async Task<ActionResult> CreateCourse([FromBody] CourseForm courseForm)
        {
            //ACA PODRÍA TRAER EL CICLO DEL CURSO PARA VALIDAR QUE EXISTA, SINO, RETORNO UN 404

            var courseId = await _courseService.CreateCourseAsync(courseForm);

            return Created(Url.Link(nameof(CoursesController.GetCourseById), new { courseId }), null);
        }


        [HttpDelete("{courseId}", Name = nameof(DeleteCourseById))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteCourseById(int courseId)
        {
            await _courseService.DeleteCourseAsync(courseId);
            return NoContent();
        }
    }
}
