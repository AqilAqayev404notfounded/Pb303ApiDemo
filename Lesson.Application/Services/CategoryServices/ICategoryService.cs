using Academy.Domain.Entities;
using Lesson.Application.DTOs;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetAsync(int id);

        Task<CategoryDto?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);

        Task<CategorytListDto> GetListAsync(Expression<Func<Category, bool>>? predicate = null,
                                        Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
                                        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true);

        Task<CategoryDto> AddAsync( CategoryCreateDto createDto);
        Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto updateDto);
        Task<CategoryDto> DeleteAsync(int id);
    }
}
