using ProsaOpg.Typer;

namespace ProsaOpg.Data;

public class EfDataAccessService : IDataAccess
{
    private readonly string _connectionString;

    public EfDataAccessService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        using EfContext context = new EfContext(_connectionString);
        Console.WriteLine("Getting all customers from database using EF Core using " + _connectionString);
        var customers = context.Customers.ToList();
        Console.WriteLine("Got {Count} customers from database", customers.Count);
        return customers;
    }

}