using Microsoft.EntityFrameworkCore;
using MorphoStore.Data;
using MorphoStore.Mapping;

namespace MorphoStore.Endpoints;

public static class CollectionsEndpoints
{
    const string GetCollectionsEndpointName = "GetCollections";
    public static RouteGroupBuilder MapCollectionEndpoints(this WebApplication app) 
    {
        var group = app.MapGroup("collections").WithParameterValidation();

        group.MapGet("/", GetCollectionList);

        group.MapGet("/{id}", GetCollectionById).WithName(GetCollectionsEndpointName);

        group.MapPost("/", CreateCollection);

        group.MapDelete("/{id}", DeleteCollection);

        return group;
    }

    private static async Task<IResult> GetCollectionList(JewleryStoreContext dbContext) 
    {
        var collectionDtos = await dbContext.Collection
            .Select(collection => collection.MapCollectionToDto())
            .AsNoTracking()
            .ToListAsync();

        return Results.Ok(collectionDtos);
    }
    private static async Task<IResult> GetCollectionById(int id, JewleryStoreContext dbContext)
    {
        var collection = await dbContext.Collection.FindAsync(id);
        return collection is null ? Results.NotFound() : Results.Ok(collection.MapCollectionToDto());
    }

    private static async Task<IResult> CreateCollection(CreateCollectionDto newCollection, JewleryStoreContext dbContext)
    {
        var collection = newCollection.MapCollectionToEntity();
        dbContext.Collection.Add(collection);
        await dbContext.SaveChangesAsync();
        var collectionDto = CollectionMapper.MapCollectionToDto(collection);

        return Results.CreatedAtRoute(GetCollectionsEndpointName, new { id = collectionDto.Id }, collectionDto);
    }

    private static async Task<IResult> DeleteCollection(int id, JewleryStoreContext dbContext)
    {
        await dbContext.Collection
            .Where(collection => collection.Id == id)
            .ExecuteDeleteAsync();

        return Results.NoContent();
    }
}
