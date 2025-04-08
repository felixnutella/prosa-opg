namespace ProsaOpg.Data;

public class DataAccessFactory
{
    public static IDataAccess CreateDataContext(string connectionString, bool useMockData = false)
    {
        if (useMockData)
        {
            return new MockDataAccessService();
        }

        // if DEBUG... return new MockDataAccessService();
        // else if RELEASE...
        return new EfDataAccessService(connectionString);
    }
}
