using System.Collections;
using ProsaOpg.Data;
using ProsaOpg.Types;


#if DEBUG
System.Console.WriteLine("Hello, World! - debug");
#else
    System.Console.WriteLine("Hello, World! - release");
#endif

IDataAccess dataAccess = DataAccessFactory.CreateDataContext("DataSource=customers.db");
IEnumerable<Customer> customers = dataAccess.GetAllCustomers();

foreach (var customer in customers)
{
    Console.WriteLine(customer.Name);
}