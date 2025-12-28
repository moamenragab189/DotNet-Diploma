using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LINQ_Tasks
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }

    class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
                {
                    new Customer { Id = 1, Name = "Ahmed", City = "Cairo" },
                    new Customer { Id = 2, Name = "Mona", City = "Giza" },
                    new Customer { Id = 3, Name = "Youssef", City = "Cairo" },
                    new Customer { Id = 4, Name = "Sara", City = "Alex" }
                };

            var categories = new List<Category>
                {
                    new Category { Id = 1, Name = "Electronics" },
                    new Category { Id = 2, Name = "Books" },
                    new Category { Id = 3, Name = "Clothing" }
                };

            var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Price = 30000, CategoryId = 1 },
                    new Product { Id = 2, Name = "Headphones", Price = 1500, CategoryId = 1 },
                    new Product { Id = 3, Name = "Novel", Price = 250, CategoryId = 2 },
                    new Product { Id = 4, Name = "T-Shirt", Price = 400, CategoryId = 3 }
                };

            var orders = new List<Order>
                {
                    new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.Today.AddDays(-5) },
                    new Order { Id = 2, CustomerId = 2, OrderDate = DateTime.Today.AddDays(-2) },
                    new Order { Id = 3, CustomerId = 1, OrderDate = DateTime.Today.AddDays(-1) }
                };

            var orderItems = new List<OrderItem>
                {
                    new OrderItem { OrderId = 1, ProductId = 1, Quantity = 1 },
                    new OrderItem { OrderId = 1, ProductId = 2, Quantity = 2 },
                    new OrderItem { OrderId = 2, ProductId = 3, Quantity = 3 },
                    new OrderItem { OrderId = 3, ProductId = 4, Quantity = 2 }
                };
            //===================================================//


            ////




            // Task 1: Return all customers who live in Cairo. 

            #region Task 1
            /* var cairoCustomers = customers.Where(c => c.City == "Cairo");
              foreach (var customer in cairoCustomers)
              {
                  Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.Name}, City: {customer.City}");

              }
          */
            #endregion

            //=====================================================//


            //TASK 2 : Return only the names of all products.

            #region Task 2
            /*  var productNames = products.Select(n=>n.Name);
                 foreach (var name in productNames)
                 {
                     Console.WriteLine(name);
                 }*/
            #endregion

            //=====================================================//

            //TASK 3:Return all products ordered by price descending.
            #region Task 3

            /* var orderedProducts = products.OrderByDescending(p=>p.Price);
             foreach (var product in orderedProducts)
             {
                 Console.WriteLine($"Product Name: {product.Name}, Price: {product.Price}");
             }*/

            #endregion


            //=====================================================//
            //TASK 4: Return the cheapest product.
            #region Task 4
            /* var chProduct = products.MinBy(p=>p.Price);
             Console.WriteLine($"Cheapest Product Name: {chProduct.Name}\nPrice :{chProduct.Price}");*/
            #endregion

            //=====================================================//
            //TASK 5: Check if there are any products that cost more than 20000.
            #region Task 5
            /* var cost = products.Any(p => p.Price > 20000);
             if (cost)
             {
                 Console.WriteLine("There are products that cost more than 20000.");
             }
             else
             {
                 Console.WriteLine("There are no products that cost more than 20000.");
             } */
            #endregion

            //=====================================================//

            //TASK 6: Check if all products cost more than 100.
            #region Task 6
            /* var product = products.All(p => p.Price > 100);
                if (product)
                {
                    Console.WriteLine("All products cost more than 100.");
                }
                else
                {
                    Console.WriteLine("Not all products cost more than 100.");

                }*/
            #endregion

            //=====================================================//

            //TASK 7: Return all orders placed in the last 3 days.
            #region Task 7
            /* var ordersLast3Days = orders.Where(o => o.OrderDate >= DateTime.Today.AddDays(-3));
               foreach (var item in orders)
               {
                   Console.WriteLine(item.OrderDate);
               }*/
            #endregion

            //=====================================================//

            //TASK 8: Return the total number of customers.
            #region Task 8
            /* var numberOfCustomers = customers.Count();
                Console.WriteLine($"Total number of customers: {numberOfCustomers}");*/
            #endregion

            //=====================================================//

            //TASK 9:Return all products belonging to the Electronics category.
            #region Task 9
            /* var ElectronicsProducts = products.Where(p => p.CategoryId == 1);

               foreach (var e in ElectronicsProducts)
               {
                   Console.WriteLine($"Electronics Product Name: {e.Name}, Price: {e.Price}");
               }*/
            #endregion

            //=====================================================//

            //TASK 10: Return the number of products in each category.
            #region Task 10

            /*var numberOfProductsbyCategory = products.GroupBy(p => p.CategoryId);
            foreach (var group in numberOfProductsbyCategory)
            {
                Console.WriteLine($"Category ID: {group.Key} ,number of products {group.Count()}");
                foreach (var product in group)
                {
                    Console.WriteLine($" - Product Name: {product.Name}, Price: {product.Price}");
                }
            }*/
            #endregion


            //=====================================================//

            //TASK 11: Return the first customer with the ID of 1.

            #region Task 11
            /* var firstcustomer = customers.First(c=>c.Id==1);
                Console.WriteLine($"name : {firstcustomer.Name} , id : {firstcustomer.Id}");*/
            #endregion

            //=====================================================//
            // Task 12 : attempt to retrive a customer with id 99 using First then describe what happens.
            #region Task 12
            /*  var customer = customers.First(c => c.Id == 99); // throws un handled exception not found
                Console.WriteLine($"name : {customer.Name} , id : {customer.Id}");*/
            #endregion

            //=====================================================//

            //Task 13 : Retrieve the customer with Id = 99 using FirstOrDefault and safely return the name or "Unknown  Customer".
            #region Task 13
            /*  var customer = customers.FirstOrDefault(c => c.Id == 99)?.Name??"unknown"; 
                Console.WriteLine($"name : {customer} ");*/
            #endregion

            //=====================================================//
            // Task 14: Retrieve the order with Id = 2 using Single.
            //          Explain what would happen if duplicate orders existed.          
            #region Task 14
            /* var x = customers.Single(c=>c.Id==2);//if duplicate orders existed it throws 'Sequence contains more than one matching element'

               Console.WriteLine($"name : {x.Name} , id : {x.Id}");*/
            #endregion

            //=====================================================//

            // Task 15:Return each customer along with the number of orders they made.
            #region Task 15
            /*var customerOrderes = customers.GroupJoin(
                    orders,
                    c => c.Id,
                    o => o.CustomerId,
                    (c, corders) => new
                    {
                        name = c.Name,
                        id = c.Id,
                        orders = corders.Count()
                    }
                    );
                foreach (var cust in customerOrderes)
                {
                    Console.WriteLine($"Customer Name: {cust.name}, ID: {cust.id}, Number of Orders: {cust.orders}");
                }*/
            #endregion

            //=====================================================//
            //Task 16 :Return customers who have never placed an order.

            #region Task 16
            /* var customer = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id))
                   .Select(f => new {f.Name,f.Id });
               foreach (var x in customer)
               { 
                   Console.WriteLine($"name : {x.Name} , id : {x.Id}");
               }*/
            #endregion

            //=====================================================//

            //Task 17:Return each order with its total item quantity. 
            #region Task 17 
            /*            var orderItems1 = orderItems.GroupBy(o=>o.OrderId);

                foreach (var item in orderItems1)
                {
                   Console.WriteLine($"Order ID: {item.Key}, Total Items: {item.Sum(i=>i.Quantity)}" );
                }*/
            #endregion

            //=====================================================//
            //Return customers who have ordered at least one Electronics product.

            #region Task 18
            /* var x = customers.Join(
                    orders,
                    c => c.Id,
                    o => o.CustomerId,
                    (c, o) => new
                    {
                         c,
                         o

                    }
                    ).Join(orderItems,o1=>o1.o.Id,i=>i.OrderId,(c,i)=>new
                    {
                        c
                        , i
                    }
                    ).Join(products,o=>o.i.ProductId,p=>p.Id,
                    (c, p) => new 
                    {
                        c,p
                    }
                    ).Where(p=>p.p.CategoryId==1).Select(x=>x.c.c.c).Distinct();
                foreach (var item in x)
                {
                    Console.WriteLine($"Customer Name: {item.Name} ");
                }*/
            #endregion

            //=====================================================//
            // Task 19 :Calculate the total price of each order (quantity × product price).

            #region Task 19
            /*var x = orderItems.Join(products, o => o.ProductId, p => p.Id, (o, p) => new
                {
                    o,p
                }
                ).GroupBy(o=>o.o.OrderId);

                foreach (var item in x)
                {
                    Console.WriteLine($"Order ID: {item.Key}, Total Price: {item.Sum(s=>s.p.Price*s.o.Quantity)}");
                }*/
            #endregion

            //=====================================================//

            //Task 20 :Return the customer who spent the most money overall. 

            #region Task 20
            /*var mostspend = customers.Join(orders, c => c.Id, o => o.CustomerId, (c, o) => new { c, o })
                    .Join(orderItems, o1 => o1.o.Id, i => i.OrderId, (c, i) => new { c, i })
                    .Join(products, o => o.i.ProductId, p => p.Id, (c, p) => new { c, p })
                    .GroupBy(c => c.c.c.c.Id)
                    .Select(x => new
                    {
                        customerid = x.Key,
                        totalspend = x.Sum(s => s.p.Price * s.c.i.Quantity)
                    }).OrderByDescending(x => x.totalspend)
                .FirstOrDefault(); 
                if(mostspend != null)
                    Console.WriteLine($"Customer ID: {mostspend.customerid}, Total Spend: {mostspend.totalspend}");*/
            #endregion

            //=====================================================//
            // Task 21:Return a flat list containing:● Customer name
            //● Product name
            //● Quantity
            //● Order date

            #region Task 21

            /* var list = customers.Join(
                 orders,
                 c => c.Id,
                 o => o.CustomerId,
                 (c, o) => new
                 {
                     cName = c.Name,
                     orderid = o.Id,
                     date = o.OrderDate
                 }
                 ).Join(orderItems, o => o.orderid, i => i.OrderId,
                 (o, i) => new
                 {
                     cname = o.cName,
                     date = o.date,
                     orderid = o.orderid,
                     quantity = i.Quantity,
                     prodectid = i.ProductId
                 }
                 ).Join(products, o1 => o1.prodectid, p => p.Id,
                 (o1, p) => new
                 {
                     cname = o1.cname,
                     date = o1.date,
                     orderid = o1.orderid,
                     quantity = o1.quantity,
                     pName = p.Name
                 }
                 );
             foreach (var item in list)
                 {
                 Console.WriteLine($"Customer Name: {item.cname}, Order Date: {item.date}, Order ID: {item.orderid}, Quantity: {item.quantity}, Product Name: {item.pName}");
             }*/
            #endregion
         

        }

    }
}
