using Microsoft.EntityFrameworkCore;
using MorphoStore.Data;
using MorphoStore.Mapping;

namespace MorphoStore.Endpoints;

public static class CategoriesEndpoints
{
    const string GetCategoriesEndpointName = "GetCategories";

    public static RouteGroupBuilder MapCategoryEndpoints(this WebApplication app) 
    {
        var group = app.MapGroup("categories").WithParameterValidation();

        group.MapGet("/", GetCategoriesList);

        group.MapGet("/{id}", GetCategoriesById).WithName(GetCategoriesEndpointName);

        return group;
    }

    private static async Task<IResult> GetCategoriesList(JewleryStoreContext dbContext) 
    {
        var categoryDtos = await dbContext.Category
            .Select(category => category.MapCategoryToDto())
            .AsNoTracking()
            .ToListAsync();

        return Results.Ok(categoryDtos);
    }
    private static async Task<IResult> GetCategoriesById(int id, JewleryStoreContext dbContext)
    {
        var category = await dbContext.Category.FindAsync(id);
        return category is null ? Results.NotFound() : Results.Ok(category.MapCategoryToDto());
    }
}
