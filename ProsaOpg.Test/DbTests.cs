using ProsaOpg.Data;

namespace ProsaOpg.Test;

public class DbTests
{
    [Fact]
    public void Test1()
    {
        var mockService = new MockDataAccessService();
        var customers = mockService.GetAllCustomers();
        Assert.NotNull(customers);
        Assert.Equal(5, customers.Count());
    }
}
