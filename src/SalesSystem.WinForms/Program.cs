using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SalesSystem.Application;
using SalesSystem.Infrastructure;
using SalesSystem.WinForms.Forms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        services.AddSingleton<IConfiguration>(configuration);

        services
            .AddApplication()
            .AddInfrastructure(configuration);

        services.AddTransient<MainForm>();
        services.AddTransient<ClientForm>();
        services.AddTransient<ProductForm>();
        services.AddTransient<SaleForm>();
        services.AddTransient<SalesReportForm>();

        var serviceProvider = services.BuildServiceProvider();

        Application.Run(serviceProvider.GetRequiredService<MainForm>());
    }
}
