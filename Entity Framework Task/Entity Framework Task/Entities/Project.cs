using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Task.Entities
{
    internal class Project
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime deadLine { get; set; }
            
        // Navigation property to represent the one-to-many relationship with Employee
        public List<Employee> Employees { get; set; }

        
    }
}
