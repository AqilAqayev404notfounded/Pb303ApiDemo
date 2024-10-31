using Academy.Domain.Entities;
using Core.Persistence.Repositories;
using Lesson.Persistance.Context;
using Lesson.Persistance.Repositories.Abstraction;

namespace Lesson.Persistance.Repositories.Implamantions
{
    public class CategoryRepository : EfRepositoryBase<Category, AppDbContext>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
