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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppBusiness.Services
{
    public interface IStudentService : ICommonService<StudentModel, StudentReadModel>
    {

    }

    public class StudentService : CommonService<Student, StudentModel, StudentReadModel>, IStudentService
    {
        public StudentService(SchoolContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<StudentReadModel> Get()
        {
            return Table.Include(r => r.Department)
                .Select(r => new StudentReadModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Age = r.Age,
                    DepartmentName = r.Department.Name
                });
        }
    }
}
