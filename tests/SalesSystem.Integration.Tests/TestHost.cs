using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Application;
using SalesSystem.Infrastructure;

namespace SalesSystem.Integration.Tests;

internal static class TestHost
{
    public static ServiceProvider Build(string connectionString)
    {
        var services = new ServiceCollection();

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:DefaultConnection"] = connectionString
            })
            .Build();

        services.AddSingleton<IConfiguration>(config);

        services
            .AddApplication()
            .AddInfrastructure(config);

        return services.BuildServiceProvider();
    }
}
