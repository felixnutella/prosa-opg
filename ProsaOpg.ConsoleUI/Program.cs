using ProsaOpg.Data;
#if DEBUG
System.Console.WriteLine("Hello, World! - debug");
#else
    System.Console.WriteLine("Hello, World! - release");
#endif

var context = DataAccessFactory.CreateDataContext("Data Source=customers.db;");
var customers = context.GetAllCustomers();
foreach (var customer in customers)
{
    Console.WriteLine(customer.Name);
}
