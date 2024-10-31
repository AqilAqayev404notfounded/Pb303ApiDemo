using Core.Persistence.Paging;

namespace Lesson.Application.DTOs
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

    }
    public class ProductCreateDto : IDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductUpdateDto : IDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class ProducttListDto : BasePageableDto, IDto
    {
        public List<ProductDto> Items { get; set; } = [];
    }
}
