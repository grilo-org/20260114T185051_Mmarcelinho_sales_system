using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Application.Clients.Create;
using SalesSystem.Application.Clients.Delete;
using SalesSystem.Application.Clients.List;
using SalesSystem.Application.Clients.Update;
using SalesSystem.Application.Products.Create;
using SalesSystem.Application.Products.Delete;
using SalesSystem.Application.Products.List;
using SalesSystem.Application.Products.Update;
using SalesSystem.Application.Reports;
using SalesSystem.Application.Sales.Create;

namespace SalesSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services
            .AddClientServices()
            .AddProductServices()
            .AddSaleServices()
            .AddReportServices();

        return services;
    }

    private static IServiceCollection AddClientServices(
        this IServiceCollection services)
    {
        services.AddScoped<IListClientsService, ListClientsService>();
        services.AddScoped<ICreateClientService, CreateClientService>();
        services.AddScoped<CreateClientValidator>();

        services.AddScoped<IUpdateClientService, UpdateClientService>();
        services.AddScoped<UpdateClientValidator>();

        services.AddScoped<IDeleteClientService, DeleteClientService>();

        return services;
    }

    private static IServiceCollection AddProductServices(
        this IServiceCollection services)
    {
        services.AddScoped<IListProductsService, ListProductsService>();
        services.AddScoped<ICreateProductService, CreateProductService>();
        services.AddScoped<CreateProductValidator>();

        services.AddScoped<IUpdateProductService, UpdateProductService>();
        services.AddScoped<UpdateProductValidator>();

        services.AddScoped<IDeleteProductService, DeleteProductService>();

        return services;
    }

    private static IServiceCollection AddSaleServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateSaleService, CreateSaleService>();
        services.AddScoped<CreateSaleValidator>();

        return services;
    }

    private static IServiceCollection AddReportServices(
        this IServiceCollection services)
    {
        services.AddScoped<ISalesReportService, SalesReportService>();

        return services;
    }
}
