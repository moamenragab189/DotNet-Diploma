using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Task.Entities
{
    internal class department
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }
        public bool isNew { get; set; }
        
        // Navigation property to represent the one-to-many relationship with Employee
        public List<Employee> Employees { get; set; }


    }
}
