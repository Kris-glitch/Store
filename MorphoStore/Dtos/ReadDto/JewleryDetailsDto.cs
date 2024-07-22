namespace MorphoStore.Dtos.ReadDto;

public record JewleryDetailsDto
(
    int Id,
    string Name,
    string Description,
    decimal Price,
    double Weight,
    int Category,
    int Collection,
    DateOnly DateOfProduction,
    string ImageUrl
);
