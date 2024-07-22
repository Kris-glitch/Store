namespace MorphoStore.Entities;

public class Jewlery
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public double Weight { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int CollectionId { get; set; }
    public Collection? Collection { get; set; }
    public DateOnly DateOfProduction { get; set; }
    public string? ImageUrl { get; set; }
}
