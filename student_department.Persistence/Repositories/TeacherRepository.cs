using Microsoft.EntityFrameworkCore;
using student_department.Application.Contracts.Persistence;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace student_department.Persistence.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentDepartmentDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Teacher>> GetAllTeachersWithCourses()
        {
            var allTeachers = await _dbContext.Teachers.Include(x => x.Courses).Include(x => x.Department).ToListAsync();
            return allTeachers;
        }
    }
}
