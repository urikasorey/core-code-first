﻿using EF_Core_Code_first.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF_Core_Code_first.Data;



namespace EF_Core_Code_first.Services
{
	public class SchoolService : ISchoolService
	{
		private readonly AppDbContext _db;

		public SchoolService(AppDbContext db)
		{
			_db = db;
		}

		// Students Services

		public async Task<List<Students>> GetStudentsAsync()
		{
			try
			{
				return await _db.Students.ToListAsync();
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<Students> GetStudentsAsync(Guid id)
		{
			try
			{
				return await _db.Students.FindAsync(id);
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<Students> AddStudentsAsync(Students student)
		{
			try
			{
				await _db.Students.AddAsync(student);
				await _db.SaveChangesAsync();
				return student;
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<Students> UpdateStudentsAsync(Students student)
		{
			try
			{
				_db.Entry(student).State = EntityState.Modified;
				await _db.SaveChangesAsync();
				return student;
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<(bool, string)> DeleteStudentsAsync(Students student)
		{
			try
			{
				var existingStudent = await _db.Students.FindAsync(student.StudentId);
				if (existingStudent == null)
				{
					return (false, "Student not found.");
				}

				_db.Students.Remove(existingStudent);
				await _db.SaveChangesAsync();
				return (true, "Student deleted successfully.");
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return (false, $"An error occurred: {ex.Message}");
			}
		}

		// Courses Services

		public async Task<IEnumerable<Courses>> GetCoursesAsync()
		{
			try
			{
				return await _db.Courses.ToListAsync();
			}
			catch (Exception ex)
			{
				// Xử lý ngoại lệ một cách phù hợp
				return null;
			}
		}

		public async Task<Courses> GetCoursesAsync(Guid id, bool includeCourses = false)
		{
			try
			{
				if (includeCourses)
				{
					return await _db.Courses
						.Include(c => c.CoursesId)
						.FirstOrDefaultAsync(c => c.CoursesId == id);
				}
				else
				{
					return await _db.Courses
						.FirstOrDefaultAsync(c => c.CoursesId == id);
				}
			}
			catch (Exception ex)
			{
				// Xử lý ngoại lệ một cách phù hợp
				return null;
			}
		}

		public async Task<Courses> AddCoursesAsync(Courses course)
		{
			try
			{
				await _db.Courses.AddAsync(course);
				await _db.SaveChangesAsync();
				return course;
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<Courses> UpdateCoursesAsync(Courses course)
		{
			try
			{
				_db.Entry(course).State = EntityState.Modified;
				await _db.SaveChangesAsync();
				return course;
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<(bool, string)> DeleteCoursesAsync(Courses course)
		{
			try
			{
				var existingCourse = await _db.Courses.FindAsync(course.CoursesId);
				if (existingCourse == null)
				{
					return (false, "Course not found.");
				}

				_db.Courses.Remove(existingCourse);
				await _db.SaveChangesAsync();
				return (true, "Course deleted successfully.");
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return (false, $"An error occurred: {ex.Message}");
			}
		}

		// StudentCourses Services

		public async Task<List<StudentCourses>> GetStudentCoursesAsync()
		{
			try
			{
				return await _db.StudentCourses.ToListAsync();
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<StudentCourses> GetStudentCourseAsync(Guid studentId, Guid courseId)
		{
			try
			{
				return await _db.StudentCourses.FindAsync(studentId, courseId);
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<StudentCourses> AddStudentCourseAsync(StudentCourses studentCourse)
		{
			try
			{
				await _db.StudentCourses.AddAsync(studentCourse);
				await _db.SaveChangesAsync();
				return studentCourse;
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<StudentCourses> UpdateStudentCourseAsync(StudentCourses studentCourse)
		{
			try
			{
				_db.Entry(studentCourse).State = EntityState.Modified;
				await _db.SaveChangesAsync();
				return studentCourse;
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return null;
			}
		}

		public async Task<(bool, string)> DeleteStudentCourseAsync(StudentCourses studentCourse)
		{
			try
			{
				var existingStudentCourse = await _db.StudentCourses.FindAsync(studentCourse.StudentId, studentCourse.CoursesId);
				if (existingStudentCourse == null)
				{
					return (false, "StudentCourse not found.");
				}

				_db.StudentCourses.Remove(existingStudentCourse);
				await _db.SaveChangesAsync();
				return (true, "StudentCourse deleted successfully.");
			}
			catch (Exception ex)
			{
				// Handle exception appropriately
				return (false, $"An error occurred: {ex.Message}");
			}
		}

		public Task<List<Students>> GetStudentssAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<StudentCourses>> GetStudentsCoursesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<StudentCourses> GetStudentsCourseAsync(Guid studentId, Guid courseId)
		{
			throw new NotImplementedException();
		}

		Task<ActionResult<IEnumerable<Students>>> ISchoolService.GetStudentsAsync()
		{
			throw new NotImplementedException();
		}
	}
}