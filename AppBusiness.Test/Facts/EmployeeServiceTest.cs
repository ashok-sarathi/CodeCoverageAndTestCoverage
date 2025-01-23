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
    public class EmployeeServiceTest
    {

        [Fact]
        public void Test1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
            });
            var mapper = config.CreateMapper();

            var contextOptions = new DbContextOptionsBuilder<SchoolContext>()
                .UseNpgsql("Server=localhost;Port=1;Database=myDataBase;User Id=postgres;Password=postgres;")
                .Options;

            EmployeeService service = new EmployeeService(new SchoolContext(contextOptions), mapper);

            var fullData = service.Get();
            var oldDataCout = fullData.Count();

            var Employee1 = new EmployeeModel()
            {
                Name = "",
                Age = 21,
                DepartmentId = 1
            };

            service.Add(Employee1);
            var fullDataAfterDataInsert = service.Get();
            var newDataCout = fullDataAfterDataInsert.Count();

            Assert.True(oldDataCout < newDataCout);
            Assert.False(!fullDataAfterDataInsert.Any(p => p.DepartmentName != null));

        }
    }
}
