using MorphoStore.Dtos.CreateDto;
using MorphoStore.Dtos.ReadDto;
using MorphoStore.Dtos.UpdateDto;
using MorphoStore.Entities;

namespace MorphoStore.Mapping;

public static class JewleryMapper
{
    public static Jewlery MapJewleryToEntity(this CreateJewleryDto jewleryDto)
    {
        return new Jewlery()
        {
            Name = jewleryDto.Name,
            Description = jewleryDto.Description,
            Price = jewleryDto.Price,
            Weight = jewleryDto.Weight,
            CategoryId = jewleryDto.CategoryId,
            CollectionId = jewleryDto.CollectionId,
            DateOfProduction = jewleryDto.DateOfProduction,
            ImageUrl = jewleryDto.ImageUrl
        };
    }

        public static Jewlery MapJewleryToEntity(this UpdateJewleryDto jewleryDto, int id)
    {
        return new Jewlery()
        {
            Id = id,
            Name = jewleryDto.Name,
            Description = jewleryDto.Description,
            Price = jewleryDto.Price,
            Weight = jewleryDto.Weight,
            CategoryId = jewleryDto.CategoryId,
            CollectionId = jewleryDto.CollectionId,
            DateOfProduction = jewleryDto.DateOfProduction,
            ImageUrl = jewleryDto.ImageUrl
        };
    }

    public static JewleryDto MapJewleryToDto(this Jewlery jewlery)
    {
        return new 
        (
            jewlery.Id,
            jewlery.Name,
            jewlery.Description,
            jewlery.Price,
            jewlery.Weight,
            jewlery.Category!.Name,
            jewlery.Collection!.Name,
            jewlery.DateOfProduction,
            jewlery.ImageUrl
        );
    }

    public static JewleryDetailsDto MapToJewleryDetailsDto(this Jewlery jewlery)
    {
        return new 
        (
            jewlery.Id,
            jewlery.Name,
            jewlery.Description,
            jewlery.Price,
            jewlery.Weight,
            jewlery.Category!.Id,
            jewlery.Collection!.Id,
            jewlery.DateOfProduction,
            jewlery.ImageUrl
        );
    }
}
