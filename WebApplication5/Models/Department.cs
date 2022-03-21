using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication5.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Required]
        public int Deptid { get; set; }
        public string Deptname { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
