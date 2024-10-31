using Academy.Domain.Entities;
using Core.Persistence.Repositories;
using Lesson.Domain.Entities;
using Lesson.Persistance.Context;
using Lesson.Persistance.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Persistance.Repositories.Implamantions
{
    public class ProductRepository : EfRepositoryBase<Product, AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
