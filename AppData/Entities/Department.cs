﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
