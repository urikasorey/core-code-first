using EF_Core_Code_first.Models;
using Microsoft.AspNetCore.Mvc;


namespace EF_Core_Code_first.Services
{
	public interface ISchoolService
	{
		// Students Services
		Task<List<Students>> GetStudentssAsync(); // GET All Studentss
		Task<Students> GetStudentsAsync(Guid id); // GET Single Students
		Task<Students> AddStudentsAsync(Students Students); // POST New Students
		Task<Students> UpdateStudentsAsync(Students Students); // PUT Students
		Task<(bool, string)> DeleteStudentsAsync(Students Students); // DELETE Students

		// Course Services
		Task<IEnumerable<Courses>> GetCoursesAsync();// GET All Courses
		Task<Courses> GetCoursesAsync(Guid id, bool includeCourses = false);// GET Single Course
		Task<Courses> AddCoursesAsync(Courses courses);// POST New Course
		Task<Courses> UpdateCoursesAsync(Courses courses); // PUT Course
		Task<(bool, string)> DeleteCoursesAsync(Courses courses);// DELETE Course

		// StudentsCourse Services
		Task<List<StudentCourses>> GetStudentsCoursesAsync(); // GET All StudentsCourses
		Task<StudentCourses> GetStudentsCourseAsync(Guid studentId, Guid courseId); // GET Single StudentCourse
		Task<StudentCourses> AddStudentCourseAsync(StudentCourses studentCourse); // POST New StudentCourse
		Task<StudentCourses> UpdateStudentCourseAsync(StudentCourses studentCourse); // PUT StudentCourse
		Task<(bool, string)> DeleteStudentCourseAsync(StudentCourses studentCourse); // DELETE StudentCourse
		Task<ActionResult<IEnumerable<Students>>> GetStudentsAsync();
	}	
}