using ProsaOpg.Data;
using ProsaOpg.Types;

namespace ProsaOpg.Test;

public class AllTests
{
    [Fact]
    public void IsCreatedDateCorrectWhenCreatingANewCustomer()
    {
        var kunde = new Customer();
        Assert.True(kunde.CreatedDate.Date == DateTime.Today.Date, "CreatedDate should be today's date.");
    }

    [Fact]
    public void WhenUsingMockDataAccessServiceAreWeGettingFiveCustomers()
    {
        var mockService = new MockDataAccessService();
        var customers = mockService.GetAllCustomers().ToList();
        Assert.Equal(5, customers.Count);
    }
}
