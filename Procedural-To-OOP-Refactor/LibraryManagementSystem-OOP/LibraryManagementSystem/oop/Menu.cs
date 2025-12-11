using LibraryManagementSystem.oop.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop
{
    internal class Menu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\n--- MENU ---");
                Console.WriteLine("1. Borrow Book");
                Console.WriteLine("2. Return Book");
                Console.WriteLine("3. Create New Book");
                Console.WriteLine("4. Generate Overdue Report");
                Console.WriteLine("5. Configure System");
                Console.WriteLine("6. Show Data Snapshot");
                Console.WriteLine("7. Exit");

                Console.Write("\nEnter choice: ");
                string choice = Console.ReadLine();
                ProcessManager manager = new ProcessManager(choice);
                if (manager.ControlFlow() == null)
                    break;
                manager.ControlFlow().processInterAction();
            }

            Console.WriteLine("\nSystem shutting down. Goodbye!");
        }
    }
}
