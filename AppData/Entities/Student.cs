﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Entities
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public int Age { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
