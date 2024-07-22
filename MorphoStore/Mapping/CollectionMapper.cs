using MorphoStore.Dtos.ReadDto;
using MorphoStore.Entities;

namespace MorphoStore.Mapping;

public static class CollectionMapper
{
    public static Collection MapCollectionToEntity(this CreateCollectionDto collectionDto)
    {
        return new Collection()
        {
            Name = collectionDto.Name
        };
    }

    public static CollectionDto MapCollectionToDto(this Collection collection)
    {
        return new 
        (
            collection.Id,
            collection.Name
        );
    }
}
