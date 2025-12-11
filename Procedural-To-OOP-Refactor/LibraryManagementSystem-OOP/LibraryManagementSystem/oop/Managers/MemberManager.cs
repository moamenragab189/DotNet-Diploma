using LibraryManagementSystem.Data;
using System;
using System.Linq;

public  class MemberManager
{
   public Member member;
   public int daysLate;
   

    public bool IsEligibleToBorrow()
    {
        if (string.IsNullOrEmpty(member.ID)) return false;

        // Staff members have high limits and are always eligible
        if (member.MembershipLevel == "Staff")
        {
            Console.WriteLine($"Staff member {member.Name} is always eligible (special status).");
            return true;
        }

        // Standard checks for Basic and Premium members
        Database database= Database.Getinstance();
        int currentLoans = database.LoanRecords().Count(l => l.MemberID == member.ID && !l.IsOverdue);

        if (currentLoans >= member.MaxLoans)
        {
            Console.WriteLine($"Limit reached for {member.MembershipLevel} member '{member.Name}'.");
            return false;
        }

        // Check for overdue books 
        bool hasOverdue = database.LoanRecords().Any(l => l.MemberID == member.ID && l.IsOverdue);
        if (hasOverdue)
        {
            Console.WriteLine($"Member '{member.Name}' has an **OVERDUE** book.");
            return false;
        }

        return true;
    }

    
    public decimal CalculateLateFee()
    {
        if (daysLate <= 0) return 0.0m;

        
        if (member.MembershipLevel == "Basic")
        {
            
            return daysLate * 0.75m;
        }
        else if (member.MembershipLevel == "Premium")
        {
            
            int chargeableDays = Math.Max(0, daysLate - 5);
            return chargeableDays * 0.40m;
        }
        else if (member.MembershipLevel == "Staff")
        {
            return 0.0m;
        }

        return daysLate * 1.00m; // Default/Unknown fee
    }
}