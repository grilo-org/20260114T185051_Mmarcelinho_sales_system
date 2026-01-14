
using SalesSystem.Application.Products.Create;
using SalesSystem.Application.Products.Delete;
using SalesSystem.Application.Products.List;
using SalesSystem.Application.Products.Update;

namespace SalesSystem.WinForms.Forms;

public partial class ProductForm : Form
{
    private readonly ICreateProductService _createService;
    private readonly IUpdateProductService _updateService;
    private readonly IDeleteProductService _deleteService;
    private readonly IListProductsService _listService;

    private int? _selectedProductId;

    public ProductForm(
        ICreateProductService createService,
        IUpdateProductService updateService,
        IDeleteProductService deleteService,
        IListProductsService listService)
    {
        InitializeComponent();
        _createService = createService;
        _updateService = updateService;
        _deleteService = deleteService;
        _listService = listService;
    }

    private async void ProductForm_Load(object sender, EventArgs e)
    {
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        dgvProducts.AutoGenerateColumns = true;

        var products = await _listService.ExecuteAsync();

        dgvProducts.DataSource = products
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.Stock
            })
            .ToList();
    }

    private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        var row = dgvProducts.Rows[e.RowIndex];

        _selectedProductId = (int)row.Cells["Id"].Value!;

        txtName.Text = row.Cells["Name"].Value?.ToString();
        txtDescription.Text = row.Cells["Description"].Value?.ToString();

        numericPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value);
        numericStock.Value = Convert.ToDecimal(row.Cells["Stock"].Value);
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            await _createService.ExecuteAsync(
                new(
                    txtName.Text,
                    txtDescription.Text,
                    numericPrice.Value,
                    (int)numericStock.Value
                ));

            await LoadProductsAsync();
            ClearForm();

            MessageBox.Show("Produto cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_selectedProductId is null)
        {
            MessageBox.Show("Selecione um produto.");
            return;
        }

        try
        {
            await _updateService.ExecuteAsync(
                new(
                    _selectedProductId.Value,
                    txtName.Text,
                    txtDescription.Text,
                    numericPrice.Value,
                    (int)numericStock.Value
                ));

            await LoadProductsAsync();
            ClearForm();

            MessageBox.Show("Produto atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedProductId is null)
        {
            MessageBox.Show("Selecione um produto.");
            return;
        }

        var confirm = MessageBox.Show(
            "Deseja realmente excluir este Produto?",
            "Confirmação",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
            return;

        try
        {
            await _deleteService.ExecuteAsync(_selectedProductId.Value);

            await LoadProductsAsync();
            ClearForm();

            MessageBox.Show("Produto removido com sucesso.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearForm()
    {
        txtName.Clear();
        txtDescription.Clear();
        numericPrice.Value = 0;
        numericStock.Value = 0;
        _selectedProductId = null;
    }
}
