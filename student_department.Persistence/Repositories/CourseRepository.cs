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

    }
}
