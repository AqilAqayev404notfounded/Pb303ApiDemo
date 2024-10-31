using Lesson.Application.DTOs;
using Lesson.Application.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetByPage([FromQuery] PageRequest pageRequest)
        {
            var productList = await _productService.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);

            return Ok(productList);
        }


        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetAsync(id.Value);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto createDto)
        {
            var createdProduct = await _productService.AddAsync(createDto);

            return Ok(createdProduct);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromBody] ProductUpdateDto updateDto)
        {
            if (id == null) return NotFound();

            var updatedProduct = await _productService.UpdateAsync(id.Value, updateDto);

            return Ok(updatedProduct);
        }
    }
}
