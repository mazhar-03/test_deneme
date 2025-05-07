using Microsoft.AspNetCore.Mvc;
using Test.Application;

namespace Test.API.controller;

[Route("api/")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISearchService _searchService;

    public ProductController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    [Route("search/")]
    public IResult GetItems([FromQuery] string type, [FromQuery] string q)
    {
        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(q))
            return Results.BadRequest("Both search type and query parameters are required.");

        if (type.ToLower() == "product")
        {
            var result = _searchService.GetResultByProductName(q);
            if (!result.Categories.Any())
                return Results.NotFound("No categories found for given query.");

            return Results.Ok(result);
        }

        if (type.ToLower() == "category")
        {
            var result = _searchService.GetResultByCategoryName(q);
            if (!result.Products.Any())
                return Results.NotFound("No products found for given query.");

            return Results.Ok(result);
        }

        return Results.BadRequest("Provide valid types(category, product).");
    }
}