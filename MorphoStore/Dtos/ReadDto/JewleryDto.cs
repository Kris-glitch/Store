namespace MorphoStore.Dtos.ReadDto;

public record class JewleryDto
(
    int Id,
    string Name,
    string Description,
    decimal Price,
    double Weight,
    string Category,
    string Collection,
    DateOnly DateOfProduction,
    string ImageUrl
);