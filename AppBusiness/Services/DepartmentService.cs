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
    public interface IDepartmentService : ICommonService<DepartmentModel, DepartmentReadModel>
    {

    }

    public class DepartmentService : CommonService<Department, DepartmentModel, DepartmentReadModel>, IDepartmentService
    {
        public DepartmentService(SchoolContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<DepartmentReadModel> Get()
        {
            return Table
                .Include(r => r.Employees)
                .Include(r => r.Students)
                .Select(r => new DepartmentReadModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Employees = r.Employees.Select(e => e.Name).ToList(),
                    Students = r.Students.Select(s => s.Name).ToList()
                });
        }
    }
}
