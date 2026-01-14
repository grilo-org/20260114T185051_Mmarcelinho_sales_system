using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Application.Reports;
using SalesSystem.Domain.Client.Repositories;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Repositories;
using SalesSystem.Domain.Sale.Repositories;
using SalesSystem.Infrastructure.Persistence;
using SalesSystem.Infrastructure.Persistence.Client;
using SalesSystem.Infrastructure.Persistence.Product;
using SalesSystem.Infrastructure.Persistence.Reports;
using SalesSystem.Infrastructure.Persistence.Sale;

namespace SalesSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddDatabase(configuration)
            .AddUnitOfWork()
            .AddRepositories();

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddScoped(_ =>
            new DbSession(connectionString!));

        return services;
    }

    private static IServiceCollection AddUnitOfWork(
        this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISalesReportRepository, SalesReportRepository>();

        return services;
    }
}
