using Microsoft.EntityFrameworkCore;
using student_department.Application.Contracts.Persistence;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_department.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentDepartmentDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsStudentEmailUnique(string Email)
        {
            var matches = _dbContext.Students.Any(e => e.Email.Equals(Email));
            return Task.FromResult(matches);
        }

    }
}
