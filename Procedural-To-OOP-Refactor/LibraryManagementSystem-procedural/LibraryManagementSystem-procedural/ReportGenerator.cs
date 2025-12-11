using LibraryManagementSystem.Data;
using System;
using System.Linq;

public static class ReportGenerator
{
   
    public static string GenerateReportOutput(string reportType, List<Loan> records, string outputFormat)
    {
        string output = "";

        if (reportType == "Overdue")
        {
            output += "--- OVERDUE ITEMS ---\n";
        }
        else if (reportType == "Summary")
        {
            output += "--- LIBRARY SUMMARY ---\n";
            output += $"Total Books: {Database.Books.Count}\n";
            output += $"Total Loans: {Database.LoanRecords.Count}\n";
        }

        if (outputFormat == "CSV")
        {
            output += "BookID,MemberID,DueDate,DaysLate,Fee\n"; // Header
            foreach (var loan in records)
            {
                int daysLate = (int)(DateTime.Now - loan.DueDate).TotalDays;

                // Fetch member to calculate fee 
                var member = Database.Members.FirstOrDefault(m => m.ID == loan.MemberID);
                decimal fee = MemberManager.CalculateLateFee(member, daysLate);

                output += $"{loan.BookID},{loan.MemberID},{loan.DueDate:yyyy-MM-dd},{daysLate},{fee:F2}\n";
            }
        }
        else if (outputFormat == "HTML")
        {
            
            output += "<html><body><h1>Overdue Loans</h1><table><tr><th>Book</th><th>Member</th><th>Fee</th></tr>";
            foreach (var loan in records)
            {
                int daysLate = (int)(DateTime.Now - loan.DueDate).TotalDays;
                var member = Database.Members.FirstOrDefault(m => m.ID == loan.MemberID);
                decimal fee = MemberManager.CalculateLateFee(member, daysLate);

               
                string style = (daysLate > 30) ? "style='color:red;'" : "";

                output += $"<tr {style}><td>{loan.BookID}</td><td>{member.Name}</td><td>${fee:F2}</td></tr>";
            }
            output += "</table></body></html>";
        }
        else
        {
            output += "Error: Unknown output format requested.";
        }

        return output;
    }
}