using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Praivte_and_Publiv_Members
{
    internal class BankAcount
    {
        private decimal Balance=0;
        private int AcountNumber=123;

        public void Deposit(decimal amount) 
        {
            Balance += amount;   
        }
        public void Withdraw(decimal amount) 
        {
            Balance -= amount;   
        }
        public void ShowCurrentBalance()
        {
            Console.WriteLine(Balance);
        }

    }
}
