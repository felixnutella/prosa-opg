using ProsaOpg.Types;

namespace ProsaOpg.Data;

public interface IDataAccess
{
    IEnumerable<Customer> GetAllCustomers();

}
