using Microsoft.AspNetCore.Mvc;
using EF_Core_Code_first.Models;
using EF_Core_Code_first.Services;

namespace EF_Core_Code_first.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CoursesController : ControllerBase
	{
		private readonly ISchoolService _coursesService;

		public CoursesController(ISchoolService coursesService)
		{
			_coursesService = coursesService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCourses()
		{
			var authors = await _coursesService.GetCoursesAsync();

			if (authors == null)
			{
				return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
			}

			return StatusCode(StatusCodes.Status200OK, authors);
		}

		[HttpGet("id")]
		public async Task<IActionResult> GetCourses(Guid id, bool includeCourses = false)
		{
			Courses courses = await _coursesService.GetCoursesAsync(id, includeCourses);

			if (courses == null)
			{
				return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
			}

			return StatusCode(StatusCodes.Status200OK, courses);
		}

		[HttpPost]
		public async Task<ActionResult<Courses>> AddCourses(Courses courses)
		{
			var dbCourses = await _coursesService.AddCoursesAsync(courses);

			if (dbCourses == null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CoursesName} could not be added.");
			}

			return CreatedAtAction("GetCourses", new { id = courses.CoursesId }, courses);
		}

		[HttpPut("id")]
		public async Task<IActionResult> UpdateCourses(Guid id, Courses courses)
		{
			if (id != courses.CoursesId)
			{
				return BadRequest();
			}

			Courses dbCourses = await _coursesService.UpdateCoursesAsync(courses);

			if (dbCourses == null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CoursesName} could not be updated");
			}

			return NoContent();
		}

		[HttpDelete("id")]
		public async Task<IActionResult> DeleteCourses(Guid id)
		{
			var courses = await _coursesService.GetCoursesAsync(id, false);
			(bool status, string message) = await _coursesService.DeleteCoursesAsync(courses);

			if (status == false)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, message);
			}

			return StatusCode(StatusCodes.Status200OK, courses);
		}
	}
}