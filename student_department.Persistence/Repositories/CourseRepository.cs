using Microsoft.EntityFrameworkCore;
using student_department.Application.Contracts.Persistence;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_department.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(StudentDepartmentDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Course>> GetAllWithDeatails()
        {
            var allCourses = await _dbContext.Courses.Include(x => x.Teacher).ThenInclude(x => x.Department).ThenInclude(x => x.Students).ToListAsync();
            return allCourses;
        }
    }
}
