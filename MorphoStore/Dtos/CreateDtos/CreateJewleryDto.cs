using System.ComponentModel.DataAnnotations;

namespace MorphoStore.Dtos.CreateDto;

public record class CreateJewleryDto
(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(500)] string Description,
    [Required][Range(1, 100000)] decimal Price,
    [Required] double Weight,
    [Required][Range(1, 7)] int CategoryId,
    [Required] int CollectionId,
    [Required] DateOnly DateOfProduction,
    [Required] string ImageUrl
);
