using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRSTesting.Application.Products
{
    public static class ProductModule
    {
        public static void AddProductModule(this IServiceCollection services)
        {
            // Add service of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Add service of Validator -> Fluent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // Add service of Mediator -> Mediator Pattern
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
