using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop
{
    internal class UserWelcom
    {
        //welcom user and show snapshot
        ConfigManager configManager = ConfigManager.GetInstance();
        Database database = Database.Getinstance();
        public void WelcomMessage()
        {
            
            Console.Title = configManager.SystemName;
            Console.WriteLine($"--- Welcome to {configManager.SystemName} ---\n");
            ShowDataSnapshot();
        }
        public void ShowDataSnapshot()
        {

            Console.WriteLine("\n--- Current Library Snapshot ---");
            Console.WriteLine("BOOKS:");
            foreach (var b in database.Books())
            {
                string status = b.IsBorrowed ? "OUT" : "IN";
                Console.WriteLine($"  [{b.ID}] {b.Title} ({b.Type}) | Max Loan: {b.MaxLoanDays} days | Status: {status}");
            }
            Console.WriteLine("\nMEMBERS:");
            foreach (var m in database.Members())
            {
                Console.WriteLine($"  [{m.ID}] {m.Name} ({m.MembershipLevel}) | Max Loans: {m.MaxLoans}");
            }
            Console.WriteLine("\nLOAN RECORDS:");
            foreach (var l in database.LoanRecords())
            {
                string overdue = l.IsOverdue ? "OVERDUE" : "Active";
                Console.WriteLine($"  Book {l.BookID} to Member {l.MemberID} | Due: {l.DueDate:yyyy-MM-dd} | Status: {overdue}");
            }
            Console.WriteLine("----------------------------------------------");
            Menu menu=new Menu();
            menu.ShowMenu();
        }

       
    }
}
