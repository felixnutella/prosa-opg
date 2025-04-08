using ProsaOpg.Types;

namespace ProsaOpg.Data;

public class DataContext : IDataAccess
{

    private readonly IDataAccess dataAccess;

    public DataContext(IDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return dataAccess.GetAllCustomers();
    }
}
