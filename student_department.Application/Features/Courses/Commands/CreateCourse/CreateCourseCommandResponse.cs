using student_department.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandResponse : BaseResponse
    {
        public CreateCourseCommandResponse() : base()
        {

        }

        public CreateCourseDto Course { get; set; }
    }
}
