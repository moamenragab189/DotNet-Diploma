using Oop.Constructor;
using Oop.Data_Abstraction;
using Oop.Inheritance_and_Composition;
using Oop.Polymorphism;
using Oop.Praivte_and_Publiv_Members;
using Oop.Private_and_Publiv_Members;
using Oop.Static_and_instance_member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
                    // Static and Instance Members

            #region Task1 description
            /*   Task 1
    Create a class Car with: 
    ● a static variable count to track the total number of cars created,
    ● an instance variable model.
    Each time a new Car object is created, increment count.
    Print the total number of cars after creating several instances.
             */
            #endregion

            #region Task1 Implementation
            Car Kia = new Car();
            Kia.model = "kia";
            Car Honda = new Car();
            Honda.model = "honda";
            Car Proton = new Car();
            Proton.model = "proton";
            //Console.WriteLine(Car.Count);// 3 cars  
            #endregion

            //====================================
            #region Task2 description
            /* Task 2
           Make a class Student with: 
           ● a static variable schoolName,
           ● A public instance variable studentName.
           Change the schoolName from one object and see how it affects all other
           objects.
              */
            #endregion

            #region Task2 Implementation
            Student student = new Student();
            student.StudentName = "ahmed";
            Student student2 = new Student();
            student.StudentName = "ali";
            Student student3 = new Student();
            student.StudentName = "samy";
            //student3.SchoolName;//can't be accessed  
            #endregion

            //==================================

            //Private and Public Members 

            #region Task3 description
            /*
               Private and Public Members 
                       Task 3 
               Define a class BankAccount with private attributes balance and 
               accountNumber. 
               Provide public methods to: 
               ● Deposit money 
               ● Withdraw money, 
               ● Show the current balance. 
               Test direct access to balance (should fail or be restricted) 

                */
            #endregion


            #region Task3 Implementation
            BankAcount acount = new BankAcount();
            acount.Deposit(20);
            acount.Withdraw(10);
            // Console.WriteLine(acount.Balance);//privat attributes cant't ba accessed
            // acount.ShowCurrentBalance();//10 
            #endregion
            //=================================

            #region Task4 Description
            /*
                            Task 4 
               Create a class Person with a private age variable. 
               Provide a public setAge() method that refuses to set the age if it’s negative or 
               above 120.
                */

            #endregion

            #region Task4 Implementation
            Person person = new Person();
            // person.SetAge(-1);
            // person.SetAge(20);
            #endregion

            //=================================

            //  Constructors

            #region Task5 Description
            /*
                                    Constructors 
                       Task 5 
                       Create a class Rectangle with: 
                       ● A default constructor (sets width and height to 1), 
                       ● A parameterized constructor (sets custom values). 
                       Print the area in both cases. 
                      
                */
            #endregion

            #region Task5 Implementation
            Rectangle rectangle = new Rectangle();
            //rectangle.area();//1
            Rectangle rectangle2 = new Rectangle(4, 5);
            //rectangle2.area();//20

            #endregion
            //====================================

            #region Task6 description
            /*
     Task 6 
        In a class Book, have a default constructor that calls another constructor with 
        predefined title and author values. 
     */
            #endregion

            #region Task6 Implementation
            //Book book = new Book();
            #endregion
            //=======================================
            //      Data Abstraction
            #region Task7 description
            /*
                             Data Abstraction  
                Task 7 
                Create a class Circle that stores radius as a private field and has methods 
                area() and circumference(). 
                Implement these methods with reference to the private field.
                 */

            #endregion

            #region Task7 Implementation

            Circle circle = new Circle(5);
            //Console.WriteLine(circle.Area());
            //Console.WriteLine(circle.Circumference()); 
            #endregion

            //=======================================
            //Inheritance and Composition 
            #region Task8 Description
            /*
                         Inheritance and Composition 
            Task 8 
            Create a class PerfectList that takes a List of integers in its constructor and 
            stores it in a private field. It has a public method Validate(), which checks whether 
            the passed list is perfect or not. 
            A perfect list is a list whose numbers have no duplicates, and their summation is 
            greater than 100. 
            Extend this behavior, once with Inheritance, and another time with Composition. 
            The extended implementation adds another check. The list size must be less than 
            10.
                 */
            #endregion

            #region Task8 Implementation
            PerfectList perfect = new PerfectList(new List<int> { 50, 60 });
            perfect.Validate();
            ComplexValidatInhirtance complexValidat = new ComplexValidatInhirtance(new List<int> { 50, 60, 39, 2, 1, 7, 8, 9, });
            complexValidat.Validate();
            ComplexValidatComposition complexValidat2 = new ComplexValidatComposition(new List<int> { 50, 60, 39, 2, 1, 7, 8, 9, });
            complexValidat.Validate();
            Console.WriteLine();
            #endregion

            //=======================================
            //Inheritance and Late Binding (Polymorphism) 
            #region Task9 Description

            /*
                             Inheritance and Late Binding (Polymorphism) 
                Task 9 
                In your system, you have a Client class which takes a User as a constructor 
                parameter. 
                The User class has a public method called CalcDiscount, and it returns 0.1 as the 
                default discount. 
                There are two subclasses of User: PremiumUser, and PartnerUser. 
                PremiumUser’s CalcDiscount returns 0.2 as a discount percentage. 
                PartnerUser’s CalcDiscount returns 0.4 as a discount percentage. 
                In your Main method, pass each type of user to the client and log the result.
             */
            #endregion
            #region Task9 Implementation

            User user = new PremiumUser();
            // Client client = new Client(user);
            user = new PartnerUser();
            // Client client2 = new Client(user); 
            #endregion
        }


    }
}
