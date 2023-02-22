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
using student_department.Application.Features.Teachers.Commands.CreateTeacher;
using student_department.Application.Features.Teachers.Queries.GetTeachersList;
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
            CreateMap<Department, DepartmentListVm>();
            CreateMap<Department, DepartmentStudentListVm>();
            CreateMap<Department, CreateDepartmentDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, StudentDepartmentDto>();
            CreateMap<Department, TeacherDepartmentDto>();
            CreateMap<Department, CourseDepartmentDto>();

            CreateMap<Course, CreateCourseDto>();
            CreateMap<Course, CourseListVm>();
            CreateMap<Course, TeacherCourseDto>();

            CreateMap<Teacher, TeacherListVm>().ReverseMap();
            CreateMap<Teacher, CreateTeacherCommand>().ReverseMap();
            CreateMap<Teacher, DepartmentTeacherDto>().ReverseMap();
            CreateMap<Teacher, CourseTeacherDto>().ReverseMap();

            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();
            CreateMap<Student, StudentDetailVm>().ReverseMap();
            CreateMap<Student, StudentListVm>().ReverseMap();
            CreateMap<Student, DepartmentStudentDto>().ReverseMap();
        }
    }
}
