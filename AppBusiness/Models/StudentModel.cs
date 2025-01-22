using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBusiness.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
    }

    public class StudentReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
    }
}
