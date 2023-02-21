using AutoMapper;
using student_department.Application.Features.Courses.Commands.CreateCourse;
using student_department.Application.Features.Courses.Queries.GetCoursesList;
using student_department.Application.Features.Departments.Commands.CreateDepartment;
using student_department.Application.Features.Departments.Queries.GetDepartmentsList;
using student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents;
using student_department.Application.Features.Students.Commands.CreateStudent;
using student_department.Application.Features.Students.Commands.UpdateStudent;
using student_department.Application.Features.Students.Queries.GetStudentDetail;
using student_department.Application.Features.Students.Queries.GetStudentsList;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, CreateDepartmentDto>();
            CreateMap<Department, DepartmentListVm>();
            CreateMap<Department, DepartmentStudentListVm>();
            CreateMap<Department, CreateDepartmentDto>();
            CreateMap<Department, DepartmentDto>();

            CreateMap<Course, CreateCourseDto>();
            CreateMap<Course, CourseListVm>();
            CreateMap<Course, CreateCourseDto>();
            CreateMap<Course, DepartmentCourseDto>();

            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();
            CreateMap<Student, StudentDetailVm>().ReverseMap();
            CreateMap<Student, StudentListVm>().ReverseMap();
            CreateMap<Student, DepartmentStudentDto>().ReverseMap();
        }
    }
}
