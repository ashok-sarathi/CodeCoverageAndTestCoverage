using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBusiness.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<string> Employees { get; set; } = [];
        public IList<string> Students { get; set; } = [];
    }
}
