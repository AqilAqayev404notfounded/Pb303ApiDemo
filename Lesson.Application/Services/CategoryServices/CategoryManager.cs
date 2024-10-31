using Academy.Domain.Entities;
using AutoMapper;
using Lesson.Application.DTOs;
using Lesson.Persistance.Repositories.Abstraction;
using Lesson.Persistance.Repositories.Implamantions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.Services.CategoryServices
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryCreateDto createDto)
        {
            var categoryEntity = mapper.Map<Category>(createDto);
            var createdCategory = await categoryRepository.AddAsync(categoryEntity);
            return mapper.Map<CategoryDto>(createdCategory);
        }

        public async Task<CategoryDto> DeleteAsync(int id)
        {
            var existCategory = await categoryRepository.GetAsync(id);

            if (existCategory == null) throw new Exception("Not found");

            var deletedCategory = await categoryRepository.DeleteAsync(existCategory);

            return mapper.Map<CategoryDto>(deletedCategory);
        }

        public async Task<CategoryDto?> GetAsync(int id)
        {
            var CategoryEntity = await categoryRepository.GetAsync(id);

            if (CategoryEntity == null) throw new Exception("Not found");

            return mapper.Map<CategoryDto>(CategoryEntity);
        }

        public async Task<CategoryDto?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        {
            var CategoryEntity = await categoryRepository.GetAsync(predicate, include);

            if (CategoryEntity == null) throw new Exception("Not found");

            return mapper.Map<CategoryDto>(CategoryEntity);
        }

        public async Task<CategorytListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            var categoryListEntity = await categoryRepository.GetListAsync(predicate, orderBy, include, index, size, enableTracking);

            if (categoryListEntity == null) throw new Exception("Not found");

            return mapper.Map<CategorytListDto>(categoryListEntity);
        }

        public async Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto updateDto)
        {
            var existCategory = await categoryRepository.GetAsync(id);

            if (existCategory == null) throw new Exception("Not found");

            existCategory = mapper.Map(updateDto, existCategory);

            var updatedProduct = await categoryRepository.UpdateAsync(existCategory);

            return mapper.Map<CategoryDto>(updatedProduct);
        }
    }

     
    
}
