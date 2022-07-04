using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog.Extensions
{
    public static class ItemExtensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreeatedDate = item.CreeatedDate
            };
        }
    }
}