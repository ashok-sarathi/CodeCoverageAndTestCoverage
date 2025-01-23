using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBusiness.Models;
using AppData.Entities;
using AutoMapper;

namespace AppBusiness.Mappers
{
    [ExcludeFromCodeCoverage]
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
