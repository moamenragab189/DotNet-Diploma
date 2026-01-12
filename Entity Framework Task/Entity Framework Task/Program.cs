using Entity_Framework_Task.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Entity_Framework_Task
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CompanyDatabaseContext context = new CompanyDatabaseContext();
            CompanyRepository repository = new CompanyRepository(context);

            //

            #region (1) Names of all departments.
            /* var departmentNames = await repository.getDepartments();
                 foreach (var dept in departmentNames)
                 {
                     Console.WriteLine(dept.name);
                 }*/
            #endregion

            //=============================================================\\
            #region (2) Names of new departments

            /* var newDepartments = await repository.getNewDepartments();
                foreach (var dept in newDepartments)
                {
                    Console.WriteLine(dept.name);
                }*/
            #endregion

            //=============================================================\\
            #region (3) Names of projects that their deadline is after 2026-01-01
            /* var projects = await repository.prjectByDeadline(new DateTime(2026, 01, 01));
             foreach (var proj in projects)
             {
                 Console.WriteLine(proj.name);
             }*/
            #endregion

            //===========================================================\\
            #region (4) Names of all employees
            /* var employeeNames = await repository.employeesName();
             foreach (var name in employeeNames)
             {
                 Console.WriteLine(name);
             }*/
            #endregion

            //===========================================================\\

            #region(5) Names of the department in which Waleed Adel works.
            /* var department = await repository.departmentByEmpoyee("Waleed Adel");
                 Console.WriteLine(department.name);*/
            #endregion

            //===========================================================\\

            #region (6) Names of employees earning more than 6000
            /*var employees = await repository.employeesBySalary(6000);
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.name);
                Console.WriteLine(emp.salary);
                
            }*/
            #endregion

            //===========================================================\\

            #region (7) Names of projects that have employees with salary less than 5000
            /*var projects = await repository.projectByEmployeeSalaryLessThan(5000);
            foreach (var proj in projects)
            {
                Console.WriteLine(proj.name);
            }*/
            #endregion

            //===========================================================\\

            #region (8) Department names of employees working on ERP projects.
            /*var departments = await repository.departmentsByProject(3);
            foreach (var dept in departments)
            {
                Console.WriteLine(dept.name);
            }*/
            #endregion

            //===========================================================\\

            #region (9) Name of the employee with the highest salary.
            /* var employee = await repository.MaxEmployeeSalary();
             Console.WriteLine(employee.name);
             Console.WriteLine(employee.salary);*/
            #endregion

            //===========================================================\\

            #region (10) Names of employees earning more than 4000 and working on CRM project
          /*  var crmProject = await context.projects.FirstAsync(p => p.name == "CRM");
            var employees = await repository.EmployeeBySalaryLessThanOnProject(4000, crmProject);
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.name);
                Console.WriteLine(emp.salary);
            }*/
            #endregion

        }
    }
}
