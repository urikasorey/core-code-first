using System.ComponentModel.DataAnnotations;

namespace EF_Core_Code_first.Models
{
	public class Courses
	{
		[Key]
		public Guid CoursesId { get; set; }
		public string ?CoursesName { get; set; }
		public string? Description { get; set; }
		public List<StudentCourses> StudentCourses { get; set; }
	}
}
