using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Task.Entities
{
    internal class Employee
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }
        public decimal salary { get; set; }
        // Foreign key properties
        public int projectId { get; set; }
        public int departmentId { get; set; }
        // Navigation properties to represent relationships
        public Project Project { get; set; }
        public department Department { get; set; }

    }
}
