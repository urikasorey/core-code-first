using Microsoft.EntityFrameworkCore;
using EF_Core_Code_first.Models;

namespace EF_Core_Code_first.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Students> Students { get; set; }
		public DbSet<Courses> Courses { get; set; }
		public DbSet<StudentCourses> StudentCourses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<StudentCourses>()
				.HasOne(x => x.Courses)
				.WithMany(x => x.StudentCourses);



			// Gọi phương thức Seed() từ DbInitializer
			new DbInitializer(builder).seed();
		}
	}
}
