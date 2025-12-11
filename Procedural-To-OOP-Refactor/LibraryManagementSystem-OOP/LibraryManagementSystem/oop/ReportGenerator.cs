using LibraryManagementSystem.Data;
using LibraryManagementSystem.oop.Builders;
using System;
using System.Linq;

public  class ReportGenerator
{
    Database database = Database.Getinstance();
       private string _reportType;
       private List<Loan> _records;
       private string _outputFormat;
    public ReportGenerator(string reportType, List<Loan> records, string outputFormat) 
    {
        _reportType=reportType;
        _records=records;
        _outputFormat=outputFormat;
    }
    public string GenerateReportOutput()
    {
        string output = "";

        if (_reportType == "Overdue")
        {
            output += "--- OVERDUE ITEMS ---\n";
        }
        else if (_reportType == "Summary")
        {
            output += "--- LIBRARY SUMMARY ---\n";
            output += $"Total Books: {database.Books().Count}\n";
            output += $"Total Loans: {database.LoanRecords().Count}\n";
        }

        if (_outputFormat == "CSV")
        {
            output += "BookID,MemberID,DueDate,DaysLate,Fee\n"; // Header
            foreach (var loan in _records)
            {
                int daysLate = (int)(DateTime.Now - loan.DueDate).TotalDays;

                // Fetch member to calculate fee 
                
                var member = database.Members().FirstOrDefault(m => m.ID == loan.MemberID);


                MemberManagerBuilder memberManagerBuilder = new MemberManagerBuilder();
                memberManagerBuilder.setmember(member).setdaysLate(daysLate);
                MemberManager memberManager = memberManagerBuilder.Build();


                decimal fee = memberManager.CalculateLateFee();

                output += $"{loan.BookID},{loan.MemberID},{loan.DueDate:yyyy-MM-dd},{daysLate},{fee:F2}\n";
            }
        }
        else if (_outputFormat == "HTML")
        {
            
            output += "<html><body><h1>Overdue Loans</h1><table><tr><th>Book</th><th>Member</th><th>Fee</th></tr>";
            foreach (var loan in _records)
            {
                int daysLate = (int)(DateTime.Now - loan.DueDate).TotalDays;
                var member = database.Members().FirstOrDefault(m => m.ID == loan.MemberID);


                MemberManagerBuilder memberManagerBuilder = new MemberManagerBuilder();
                memberManagerBuilder.setmember(member).setdaysLate(daysLate);
                MemberManager memberManager = memberManagerBuilder.Build();

                decimal fee = memberManager.CalculateLateFee();

               
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