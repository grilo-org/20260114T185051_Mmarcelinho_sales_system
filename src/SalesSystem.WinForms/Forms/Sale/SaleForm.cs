using SalesSystem.Application.Clients.List;
using SalesSystem.Application.Products.List;
using SalesSystem.Application.Sales.Create;
using SalesSystem.Domain.Product.Models;
using SalesSystem.WinForms.Forms.Sale.ViewModels;

namespace SalesSystem.WinForms.Forms;

public partial class SaleForm : Form
{
    private readonly IListClientsService _listClientsService;
    private readonly IListProductsService _listProductsService;
    private readonly ICreateSaleService _createSaleService;

    private readonly BindingSource _saleItemsSource = [];
    private readonly List<SaleItemViewModel> _saleItems = [];

    public SaleForm(
        IListClientsService listClientsService,
        IListProductsService listProductsService,
        ICreateSaleService createSaleService)
    {
        InitializeComponent();

        _listClientsService = listClientsService;
        _listProductsService = listProductsService;
        _createSaleService = createSaleService;
    }

    private async void SaleForm_Load(object sender, EventArgs e)
    {
        await LoadClientsAsync();
        await LoadProductsAsync();

        _saleItemsSource.DataSource = _saleItems;
        dgvSaleItems.AutoGenerateColumns = true;
        dgvSaleItems.DataSource = _saleItemsSource;
        dgvSaleItems.Columns["ProductId"].Visible = false;
        dgvSaleItems.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
        dgvSaleItems.Columns["Total"].DefaultCellStyle.Format = "C2";

        UpdateTotal();
    }

    private async Task LoadClientsAsync()
    {
        var clients = await _listClientsService.ExecuteAsync();

        cmbClients.DataSource = clients;
        cmbClients.DisplayMember = "Name";
        cmbClients.ValueMember = "Id";
    }

    private async Task LoadProductsAsync()
    {
        var products = await _listProductsService.ExecuteAsync();

        dgvProducts.AutoGenerateColumns = true;
        dgvProducts.DataSource = products;
    }

    private void btnAddItem_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow is null)
            return;

        var product = (Product)dgvProducts.CurrentRow.DataBoundItem!;
        var quantity = (int)nudQuantity.Value;

        if (quantity <= 0)
        {
            MessageBox.Show("Quantidade inválida.");
            return;
        }

        if (_saleItems.Any(i => i.ProductId == product.Id))
        {
            MessageBox.Show("Produto já adicionado à venda.");
            return;
        }

        _saleItems.Add(new SaleItemViewModel
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Quantity = quantity,
            UnitPrice = product.Price
        });

        _saleItemsSource.ResetBindings(false);
        UpdateTotal();
    }

    private void UpdateTotal()
    {
        var total = _saleItems.Sum(i => i.Total);
        lblTotal.Text = $"Total: {total:C}";
    }

    private async void btnFinishSale_Click(object sender, EventArgs e)
    {
        if (cmbClients.SelectedItem is null)
        {
            MessageBox.Show("Selecione um cliente.");
            return;
        }

        if (_saleItems.Count == 0)
        {
            MessageBox.Show("Adicione ao menos um item à venda.");
            return;
        }

        var command = new CreateSaleCommand(
            ClientId: (int)cmbClients.SelectedValue!,
            Items: [.. _saleItems.Select(i =>
                new SaleItemInput(i.ProductId, i.Quantity)
            )]
        );

        try
        {
            await _createSaleService.ExecuteAsync(command);

            MessageBox.Show("Venda registrada com sucesso.");

            _saleItems.Clear();
            _saleItemsSource.ResetBindings(false);
            UpdateTotal();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}