using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.processes
{
    internal class ProcessConfigInteraction : IProcess
    {
        public void processInterAction()
        {
            Console.WriteLine("\n[5. System Configurations]");
            ConfigManager configManager = ConfigManager.GetInstance();
            configManager.DisplayCurrentConfig();
            Console.Write("Enter setting key (SystemName, IsMaintenanceMode, DefaultLoanDays): ");
            string key = Console.ReadLine().Trim();
            Console.Write($"Enter new value for {key}: ");
            string value = Console.ReadLine().Trim();

            if (configManager.UpdateConfiguration(key, value))
            {
                Console.WriteLine($"\n>> Successfully updated {key}.");
            }
            else
            {
                Console.WriteLine($"\n>> Failed to update {key}. Check key and value format.");
            }
            configManager.DisplayCurrentConfig();
        }
    }
}
