using ProsaOpg.Data;

var context = DataAccessFactory.CreateDataContext("Data Source=customers.db;");
var customers = context.GetAllCustomers();
foreach (var customer in customers)
{
    Console.WriteLine(customer.Name);
}
