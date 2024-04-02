using System.ComponentModel.DataAnnotations;
namespace EF_Core_Code_first.Models
{
	public class Students
	{
		[Key]
		public Guid StudentId{ get; set; }
		public string ? Name { get; set; }
		public List<StudentCourses> StudentCourses { get; set; }
	}
}
