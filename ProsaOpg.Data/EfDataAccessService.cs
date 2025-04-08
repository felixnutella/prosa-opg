using ProsaOpg.Types;

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
        var customers = context.Customers.ToList();
        return customers;
    }

}