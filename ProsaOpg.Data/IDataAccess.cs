using ProsaOpg.Typer;

namespace ProsaOpg.Data;

public interface IDataAccess
{
    IEnumerable<Customer> GetAllCustomers();

}
