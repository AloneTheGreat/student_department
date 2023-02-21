using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Courses.Queries.GetCoursesList
{
    public class GetCourseListQuery : IRequest<List<CourseListVm>>
    {

    }
}
