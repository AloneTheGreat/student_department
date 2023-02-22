using Microsoft.EntityFrameworkCore;
using student_department.Application.Contracts.Persistence;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_department.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(StudentDepartmentDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Department>> GetDepartmentsWithStudents()
        {
            var allDepartments = await _dbContext.Departments.Include(x => x.Students).ToListAsync();
            
            return allDepartments;
        }

        public async Task<List<Department>> GetDepartmentsWithTeachers()
        {
            var allDepartments = await _dbContext.Departments.Include(x => x.Teachers).ToListAsync();

            return allDepartments;
        }
    }
}
