using Entity_Framework_Task.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Task
{
    internal class CompanyDatabaseContext : DbContext
    {
        public DbSet<Employee> employees {  get; set; }
        public DbSet<department> departments { get; set; }
        public DbSet<Project> projects { get; set; }

        //configure database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string coonStr = "Server=localhost;Database=Company;User Id=sa;Password=123;TrustServerCertificate=true;";
           optionsBuilder.UseSqlServer(coonStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<department>(
                entity => {
                    entity.HasKey(key => key.id);
                    entity.HasMany(e => e.Employees).WithOne(e => e.Department)
                    .HasForeignKey(e=>e.departmentId);
                    entity.ToTable("departments");
                }

                );

            modelBuilder.Entity<Employee>(
                entity => {
                entity.HasKey(e => e.id);
                    entity.HasOne(e => e.Project).WithMany(p => p.Employees)
                    .HasForeignKey(h=>h.projectId);
                    entity.ToTable("employees");
                }
                );
            modelBuilder.Entity<Project>(
                entity =>
                {
                    entity.HasKey(e => e.id);
                    entity.ToTable("projects");
                }
                );
            seedData(modelBuilder);

        }

        private void seedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<department>().HasData(
                new department() {id=1,name="HR",isNew=true },
                new department() {id=2,name="IT",isNew=false },
                new department() {id=3,name="Finance",isNew=true },
                new department() {id=4,name="Operation",isNew=false },
                new department() {id=5,name="Markting",isNew=false }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project() {id=1,name="CRM",deadLine= new DateTime(2025-12-1) },
                new Project() {id=2,name= "HR", deadLine= new DateTime(2026 - 06 - 01) },
                new Project() {id=3,name= "ERP", deadLine= new DateTime(2026 - 06 - 01) },
                new Project() {id=4,name= "School Management ", deadLine= new DateTime(2027 - 10 - 01) }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee() {id= 101, name= "named Ali Hassan",salary = 5000 ,projectId=1,departmentId=3},
                new Employee() {id= 102, name= "Sameer Zaki", salary = 6200, projectId=1,departmentId = 2 },
                new Employee() {id= 103, name= "Khaled Omar", salary = 4750, projectId=1,departmentId=1},
                new Employee() {id= 104, name= "Karim Ahmed", salary = 5500 ,projectId=1,departmentId=4},
                new Employee() {id= 105, name= "Youssef Nabil", salary = 7100, projectId= 2, departmentId=3},
                new Employee() {id= 106, name= "Loay Samir", salary = 4900, projectId=2,departmentId=2},
                new Employee() {id= 107, name= "Omar Fathy", salary = 6000 ,projectId=2,departmentId=2},
                new Employee() {id= 108, name= "Wael Magdy", salary = 5800 ,projectId=2,departmentId=2},
                new Employee() {id= 109, name= "Ahmed Tarek", salary = 6750, projectId=2,departmentId=2},
                new Employee() {id= 110, name= "Sameh Hany,", salary = 4300 ,projectId=3,departmentId=2},
                new Employee() {id= 111, name= "Mahmoud Said", salary = 5600 ,projectId=3,departmentId=3},
                new Employee() {id= 112, name= "Waleed Adel", salary = 6100 ,projectId=4,departmentId=2},
                new Employee() {id= 113, name= "Bassel Hossam", salary = 5400 ,projectId=4,departmentId=4},
                new Employee() {id= 114, name= "ALi Khalil", salary = 4850, projectId=4,departmentId=1},
                new Employee() {id= 115, name= "Hussein Mostafa", salary = 6900, projectId=4,departmentId=3}
                );
        }

    }
}
