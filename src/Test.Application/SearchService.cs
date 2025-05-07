using Microsoft.Data.SqlClient;
using Test.Models;

namespace Test.Application;

public class SearchService : ISearchService
{
    private readonly string _connectionString;

    public SearchService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ProductDto GetResultByProductName(string productName)
    {
        var productDto = new ProductDto
        {
            ProductName = productName,
            Categories = new List<Category>()
        };
        var sql = @"SELECT ca.Name
FROM s31162.dbo.Category ca
JOIN s31162.dbo.Product_Category pc ON pc.Category_Id = ca.Id
JOIN s31162.dbo.Product p ON p.Id = pc.Product_Id
WHERE p.Name = @ProductName";

        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ProductName", productName);
            var reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                    while (reader.Read())
                        productDto.Categories.Add(new Category
                        {
                            Name = reader.GetString(0)
                        });
            }
            finally
            {
                reader.Close();
            }
        }

        return productDto;
    }

    public CategoryDto GetResultByCategoryName(string categoryName)
    {
        var categoryDto = new CategoryDto
        {
            CategoryName = categoryName,
            Products = new List<Product>()
        };

        var sql = @"SELECT p.Name, p.Price 
FROM s31162.dbo.Product p
JOIN s31162.dbo.Product_Category pc ON pc.Product_Id = p.ID
JOIN s31162.dbo.Category c ON pc.Category_Id = c.ID
WHERE c.Name = @CategoryName;
";
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            var reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                    while (reader.Read())
                        categoryDto.Products.Add(new Product
                        {
                            Name = reader.GetString(0),
                            Price = reader.GetFloat(1)
                        });
            }
            finally
            {
                reader.Close();
            }
        }

        return categoryDto;
    }
}