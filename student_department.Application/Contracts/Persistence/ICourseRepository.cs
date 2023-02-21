using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace student_department.Application.Contracts.Persistence
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {

    }
}
