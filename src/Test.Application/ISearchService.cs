using Test.Models;

namespace Test.Application;

public interface ISearchService
{
    ProductDto GetResultByProductName(string productName);
    CategoryDto GetResultByCategoryName(string categoryName);
}