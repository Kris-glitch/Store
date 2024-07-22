using MorphoStore.Dtos.ReadDto;
using MorphoStore.Entities;

namespace MorphoStore.Mapping;

public static class CategoryMapper
{
        public static CategoryDto MapCategoryToDto(this Category category)
    {
        return new 
        (
            category.Id,
            category.Name
        );
    }
}
