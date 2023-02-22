using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace student_department.Application.Contracts.Persistence
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<bool> IsStudentEmailUnique(string Email);

        Task<List<Student>> GetAllStudentsWithDepartment();
    }
}
