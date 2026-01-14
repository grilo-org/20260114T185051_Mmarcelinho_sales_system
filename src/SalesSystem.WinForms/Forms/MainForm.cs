using Microsoft.Extensions.DependencyInjection;

namespace SalesSystem.WinForms.Forms;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public MainForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private void btnClients_Click(object sender, EventArgs e)
    {
        using var scope = _serviceProvider.CreateScope();
        var clientForm = scope.ServiceProvider.GetRequiredService<ClientForm>();
        clientForm.ShowDialog();
    }

    private void btnProducts_Click(object sender, EventArgs e)
    {
        using var scope = _serviceProvider.CreateScope();
        var productForm = scope.ServiceProvider.GetRequiredService<ProductForm>();
        productForm.ShowDialog();
    }

    private void btnSales_Click(object sender, EventArgs e)
    {
        using var scope = _serviceProvider.CreateScope();
        var saleForm = scope.ServiceProvider.GetRequiredService<SaleForm>();
        saleForm.ShowDialog();
    }

    private void btnReport_Click(object sender, EventArgs e)
    {
        using var scope = _serviceProvider.CreateScope();
        var reportForm = scope.ServiceProvider.GetRequiredService<SalesReportForm>();
        reportForm.ShowDialog();
    }
}
