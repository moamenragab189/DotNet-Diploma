using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.processes
{
    internal class ProcessReportInteraction : IProcess
    {
        Database database=Database.Getinstance();
       
        public void processInterAction()
        {
            Console.WriteLine("\n[4. Generate Overdue Report]");
            Console.Write("Output Format (CSV or HTML): ");
            string format = Console.ReadLine().Trim().ToUpper();

            // Get overdue records (DI Target: Direct access to static data)
            var overdueRecords = database.LoanRecords().Where(l => l.IsOverdue).ToList();


            ReportGenerator reportGenerator=new ReportGenerator("Overdue", overdueRecords, format);
            string report = reportGenerator.GenerateReportOutput();


            Console.WriteLine($"\n--- Generated {format} Report Output ---");
            Console.WriteLine(report);
            Console.WriteLine("-----------------------------------------");
        }
    }
}
