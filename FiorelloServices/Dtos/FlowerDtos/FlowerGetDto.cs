namespace Fiorello.Services.Dtos.FlowerDtos
{
    public class FlowerGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public CategoryInFlowerGetDto Category { get; set; }
    }

    public class CategoryInFlowerGetDto
    {
        public int Id { get; set; }
= 0;    public string Name { get; set; }
    }
}
