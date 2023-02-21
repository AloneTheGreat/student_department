﻿using System;

namespace student_department.Application.Features.Students.Queries.GetStudentsList
{
    public class StudentListVm
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentCoursesDto Department { get; set; }
    }
}