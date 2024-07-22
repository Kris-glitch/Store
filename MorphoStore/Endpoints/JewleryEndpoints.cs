using Microsoft.EntityFrameworkCore;
using MorphoStore.Data;
using MorphoStore.Dtos.CreateDto;
using MorphoStore.Dtos.UpdateDto;
using MorphoStore.Mapping;

namespace MorphoStore.Endpoints;

public static class JewleryEndpoints
{
    const string GetJewleryEndpointName = "GetJewlery";

    public static RouteGroupBuilder MapJewleryEndpoints(this WebApplication app) 
    {
        var group = app.MapGroup("jewlery").WithParameterValidation();

        //GET jewlery list
        group.MapGet("/", GetJewleryList);

        //GET jewlery by id
        group.MapGet("/{id}", GetJewleryById).WithName(GetJewleryEndpointName);

        //POST jewlery object
        group.MapPost("/", CreateJewlery);

        //PUT
        group.MapPut("/{id}", UpdateJewlery);

        //DELETE
        group.MapDelete("/{id}", DeleteJewlery);

        return group;
    }

    private static async Task<IResult> GetJewleryList(JewleryStoreContext dbContext) 
    {
        var jewleryDtos = await dbContext.Jewlery
            .Include(jewlery => jewlery.Category)
            .Include(jewlery => jewlery.Collection)
            .Select(jewlery => jewlery.MapJewleryToDto())
            .AsNoTracking()
            .ToListAsync();

        return Results.Ok(jewleryDtos);
    } 

    private static async Task<IResult> GetJewleryById(int id, JewleryStoreContext dbContext)
    {
        var jewlery = await dbContext.Jewlery.FindAsync(id);
        return jewlery is null ? Results.NotFound() : Results.Ok(jewlery.MapToJewleryDetailsDto());
    }
    
    private static async Task<IResult> CreateJewlery(CreateJewleryDto newJewlery, JewleryStoreContext dbContext)
    {
        var jewlery = newJewlery.MapJewleryToEntity();

        dbContext.Jewlery.Add(jewlery);
        await dbContext.SaveChangesAsync();

        var jewleryDto = JewleryMapper.MapToJewleryDetailsDto(jewlery);

        return Results.CreatedAtRoute(GetJewleryEndpointName, new { id = jewleryDto.Id }, jewleryDto);
    }

    private static async Task<IResult> UpdateJewlery(int id, UpdateJewleryDto updatedJewlery, JewleryStoreContext dbContext)
    {
        var existingJewlery = await dbContext.Jewlery.FindAsync(id);
        if (existingJewlery is null) return Results.NotFound();

        dbContext.Entry(existingJewlery).CurrentValues.SetValues(updatedJewlery.MapJewleryToEntity(id));
        await dbContext.SaveChangesAsync();

        return Results.NoContent();
    }

    private static async Task<IResult> DeleteJewlery(int id, JewleryStoreContext dbContext)
    {
        await dbContext.Jewlery
            .Where(jewlery => jewlery.Id == id)
            .ExecuteDeleteAsync();

        return Results.NoContent();
    }
}
