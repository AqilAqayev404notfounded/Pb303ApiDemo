using Academy.Domain.Entities;
using Core.Persistence.Repositories;
using Lesson.Domain.Entities;

namespace Lesson.Persistance.Repositories.Abstraction
{
    public interface IProductRepository : IRepositoryAsync<Product>
    {
    }

}
