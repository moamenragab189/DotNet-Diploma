using Entity_Framework_Task;
using Entity_Framework_Task.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Task
{
    internal class CompanyRepository
    {
        private readonly CompanyDatabaseContext _context;
        public CompanyRepository(CompanyDatabaseContext context)
        {
            _context = context;
        }

       
        public async Task <List<department>> getDepartments()
        {
            return await _context.departments.ToListAsync();
        }
        
        public async Task<List<department>> getNewDepartments()
        {
            return await _context.departments.Where(d => d.isNew).ToListAsync();
        }

        //Projects with deadlines after a specific date.
        public async Task<List<Project>> prjectByDeadline(DateTime date)
        {
            return await _context.projects.Where(p => p.deadLine > date).ToListAsync();
        }

        //Names of all employees.
        public async Task<List<string>> employeesName()
        {
            return await _context.employees.Select(e=>e.name).ToListAsync();
        }
        //Department of a specific employee by name.
        public async Task<department> departmentByEmpoyee(string name)
        {
            return await _context.employees.Where(e => e.name == name)
                .Select(e => e.Department).FirstAsync();
        }
        //Employees with salary greater than or equal to a specific amount.
        public async Task<List<Employee>> employeesBySalary(decimal salary)
        {
            return await _context.employees.Where(e => e.salary >=salary).ToListAsync();
        }

        //Projects that have employees with salary less than a specific amount.
        public async Task<List<Project>> projectByEmployeeSalaryLessThan(decimal salary)
        {
            return await _context.projects.Where(p => p.Employees.Any(e => e.salary < salary)).ToListAsync();
        }
        //Departments that have employees working on a specific project by project ID.
        public async Task<List<department>> departmentsByProject(int projectId)
        {
            return await _context.departments.Where(d => d.Employees.Any(e => e.Project.id == projectId)).ToListAsync();
        }

        //Employee with the highest salary.
        public async Task<Employee> MaxEmployeeSalary()
        {
            decimal maxSalary = await _context.employees.MaxAsync(e => e.salary);
            return await _context.employees.Where(e=>e.salary==maxSalary).FirstAsync();
        }
        //Employees with salary greater than a specific amount and working on a specific project.
        public async Task<List<Employee>> EmployeeBySalaryLessThanOnProject(decimal salary,Project project)
        {
            return await _context.employees.Where(e => e.salary > salary && e.Project.id == project.id).ToListAsync();
        }



    }
}
