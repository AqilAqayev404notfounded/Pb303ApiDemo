using Academy.Domain.Entities;
using Core.Persistence.Repositories;

namespace Lesson.Persistance.Repositories.Abstraction
{
    public interface ICategoryRepository : IRepositoryAsync<Category>
    {
    }

}
