namespace Test.Application;

public class SearchService : ISearchService
{
    private readonly string _connectionString;

    public SearchService(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    
}