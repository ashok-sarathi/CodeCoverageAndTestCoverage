using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBusiness.Models;
using AppBusiness.Services;
using AppData;
using AppData.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppBusiness.Test.Facts
{
    public class StudentServiceTest
    {

        [Fact]
        public void Test1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentModel>().ReverseMap();
            });
            var mapper = config.CreateMapper();

            var contextOptions = new DbContextOptionsBuilder<SchoolContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CodeCoverage;Trusted_Connection=True")
                .Options;

            StudentService service = new StudentService(new SchoolContext(contextOptions), mapper);

            var fullData = service.Get();
            var oldDataCout = fullData.Count();

            var student1 = new StudentModel()
            {
                Name = "",
                Age = 21,
                DepartmentId = 1
            };

            service.Add(student1);
            var fullDataAfterDataInsert = service.Get();
            var newDataCout = fullDataAfterDataInsert.Count();

            Assert.True(oldDataCout < newDataCout);
        }
    }
}
