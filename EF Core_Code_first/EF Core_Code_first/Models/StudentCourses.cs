using System.ComponentModel.DataAnnotations;

namespace EF_Core_Code_first.Models
{
	public class StudentCourses
	{
		public Guid StudentId { get; set; }
		public Students Students { get; set; }
		public Guid CoursesId { get; set; }
		public Courses Courses { get; set; }

		
	}
}
