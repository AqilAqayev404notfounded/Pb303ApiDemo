using Academy.Domain.Entities;
using AutoMapper;
using Lesson.Application.DTOs;
using Lesson.Domain.Entities;
using Lesson.Persistance.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.Services.ProductService
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto> AddAsync(ProductCreateDto createDto)
        {
            var productEntity = mapper.Map<Product>(createDto);
            var createdProduct = await productRepository.AddAsync(productEntity);
            return mapper.Map<ProductDto>(createdProduct);
        }

        public async Task<ProductDto> DeleteAsync(int id)
        {
            var existProduct = await productRepository.GetAsync(id);

            if (existProduct == null) throw new Exception("Not found");

            var deletedProduct = await productRepository.DeleteAsync(existProduct);

            return mapper.Map<ProductDto>(deletedProduct);
        }

        public async Task<ProductDto?> GetAsync(int id)
        {
            var ProductEntity = await productRepository.GetAsync(id);

            if (ProductEntity == null) throw new Exception("Not found");

            return mapper.Map<ProductDto>(ProductEntity);
        }

        public async Task<ProductDto?> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
        {
            var ProductEntity = await productRepository.GetAsync(predicate, include);

            if (ProductEntity == null) throw new Exception("Not found");

            return mapper.Map<ProductDto>(ProductEntity);
        }

        public async Task<ProducttListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            var productListEntity = await productRepository.GetListAsync(predicate, orderBy, include, index, size, enableTracking);

            if (productListEntity == null) throw new Exception("Not found");

            return mapper.Map<ProducttListDto>(productListEntity);
        }

        public async Task<ProductDto> UpdateAsync(int id, ProductUpdateDto updateDto)
        {
            var existProduct = await productRepository.GetAsync(id);

            if (existProduct == null) throw new Exception("Not found");

            existProduct = mapper.Map(updateDto, existProduct);

            var updatedProduct = await productRepository.UpdateAsync(existProduct);

            return mapper.Map<ProductDto>(updatedProduct);
        }
    }
}
