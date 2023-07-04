using Fiorello.Core.Entities;

namespace Fiorello.Services.Dtos.CategoryDtos
{
    public class CategoryGetAllItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Flower> Flowers { get; set; }
    }

}
