using Lesson.Application.DTOs;
using Lesson.Application.Services.CategoryServices;
using Lesson.Application.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage([FromQuery] PageRequest pageRequest)
        {
            var CategoryList = await _categoryService.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);

            return Ok(CategoryList);
        }


        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetAsync(id.Value);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryCreateDto createDto)
        {
            var createdCategory = await _categoryService.AddAsync(createDto);

            return Ok(createdCategory);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromBody] CategoryUpdateDto updateDto)
        {
            if (id == null) return NotFound();

            var updatedCategory = await _categoryService.UpdateAsync(id.Value, updateDto);

            return Ok(updatedCategory);
        }
    }
}
