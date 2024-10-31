using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.DTOs
{
    public class CategoryDto :IDto
    {
        public string Name { get; set; }
    }
    public class CategoryCreateDto : IDto
    {
        public string Name { get; set; }
    }
    public class CategoryUpdateDto : IDto
    {
        public string Name { get; set; }
    }
    public class CategorytListDto : BasePageableDto, IDto
    {
        public List<CategoryDto> Items { get; set; } = [];
    }
}
