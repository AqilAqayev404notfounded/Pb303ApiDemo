using Lesson.Application.Services.CategoryServices;
using Lesson.Application.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Lesson.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();

        return services;
    }
}
