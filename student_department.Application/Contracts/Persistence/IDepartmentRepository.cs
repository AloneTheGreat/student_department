using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace student_department.Application.Contracts.Persistence
{
    public interface IDepartmentRepository : IAsyncRepository<Department>
    {
        Task<List<Department>> GetDepartmentsWithStudents();
        Task<List<Department>> GetDepartmentsWithTeachers();
    }
}
