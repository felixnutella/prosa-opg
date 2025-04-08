namespace ProsaOpg.Data;

public class DataAccessFactory
{
    public static IDataAccess CreateDataContext(string connectionString)
    {
#if DEBUG
        return new MockDataAccessService();
#else
        return new EfDataAccessService(connectionString);
#endif
    }
}
