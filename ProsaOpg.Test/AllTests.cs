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
        IDataAccess mockDataAccessService = new MockDataAccessService();
        Assert.True(mockDataAccessService.GetAllCustomers().Count() == 5, "There should be 5 customers.");
    }

}
