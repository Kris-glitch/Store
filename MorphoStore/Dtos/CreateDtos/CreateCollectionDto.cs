using System.ComponentModel.DataAnnotations;

namespace MorphoStore;

public record CreateCollectionDto
(
    [Required][StringLength(50)] string Name
);
