using SalesSystem.Application.Clients.Create;
using SalesSystem.Application.Clients.Delete;
using SalesSystem.Application.Clients.List;
using SalesSystem.Application.Clients.Update;

namespace SalesSystem.WinForms.Forms;

public partial class ClientForm : Form
{
    private readonly ICreateClientService _createService;
    private readonly IUpdateClientService _updateService;
    private readonly IDeleteClientService _deleteService;
    private readonly IListClientsService _listService;

    private int? _selectedClientId;

    public ClientForm(
        ICreateClientService createService,
        IUpdateClientService updateService,
        IDeleteClientService deleteService,
        IListClientsService listService)
    {
        InitializeComponent();
        _createService = createService;
        _updateService = updateService;
        _deleteService = deleteService;
        _listService = listService;
    }

    private async void ClientForm_Load(object sender, EventArgs e)
    {
        await LoadClientsAsync();
    }

    private async Task LoadClientsAsync()
    {
        dgvClients.AutoGenerateColumns = true;

        var clients = await _listService.ExecuteAsync();

        dgvClients.DataSource = clients
            .Select(c => new
            {
                c.Id,
                c.Name,
                Email = c.Email.Value,
                c.Phone
            })
            .ToList();
    }

    private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        var row = dgvClients.Rows[e.RowIndex];

        _selectedClientId = (int)row.Cells["Id"].Value!;

        txtName.Text = row.Cells["Name"].Value?.ToString();
        txtEmail.Text = row.Cells["Email"].Value?.ToString();
        txtPhone.Text = row.Cells["Phone"].Value?.ToString();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            await _createService.ExecuteAsync(
                new(
                    txtName.Text,
                    txtEmail.Text,
                    txtPhone.Text
                ));

            await LoadClientsAsync();
            ClearForm();

            MessageBox.Show("Cliente cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_selectedClientId is null)
        {
            MessageBox.Show("Selecione um cliente.");
            return;
        }

        try
        {
            await _updateService.ExecuteAsync(
                new(
                    _selectedClientId.Value,
                    txtName.Text,
                    txtEmail.Text,
                    txtPhone.Text
                ));

            await LoadClientsAsync();
            ClearForm();

            MessageBox.Show("Cliente atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedClientId is null)
        {
            MessageBox.Show("Selecione um cliente.");
            return;
        }

        var confirm = MessageBox.Show(
            "Deseja realmente excluir este cliente?",
            "Confirmação",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
            return;

        try
        {
            await _deleteService.ExecuteAsync(_selectedClientId.Value);

            await LoadClientsAsync();
            ClearForm();

            MessageBox.Show("Cliente removido com sucesso.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearForm()
    {
        txtName.Clear();
        txtEmail.Clear();
        txtPhone.Clear();
        _selectedClientId = null;
    }
}
