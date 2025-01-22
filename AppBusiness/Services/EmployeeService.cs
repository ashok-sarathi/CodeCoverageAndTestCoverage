using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBusiness.Models;
using AppData;
using AppData.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppBusiness.Services
{
    public interface IEmployeeService : ICommonService<EmployeeModel, EmployeeReadModel>
    {

    }

    public class EmployeeService : CommonService<Employee, EmployeeModel, EmployeeReadModel>, IEmployeeService
    {
        public EmployeeService(SchoolContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<EmployeeReadModel> Get()
        {
            return Table.Include(r => r.Department)
                .Select(r => new EmployeeReadModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Age = r.Age,
                    DepartmentName = r.Department.Name
                });
        }
    }
}
