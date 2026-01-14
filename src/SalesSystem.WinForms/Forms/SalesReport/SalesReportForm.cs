using Microsoft.Reporting.WinForms;
using SalesSystem.Application.Reports;

namespace SalesSystem.WinForms.Forms;

public partial class SalesReportForm : Form
{
    private readonly ISalesReportService _service;

    public SalesReportForm(ISalesReportService service)
    {
        InitializeComponent();
        _service = service;

        salesReportViewer.LocalReport.ReportEmbeddedResource =
            "SalesSystem.WinForms.Report.SalesReport.rdlc";
    }

    private async void btnGenerate_Click(object sender, EventArgs e)
    {
        var data = await _service.GetByPeriodAsync(
            dtStart.Value.Date,
            dtEnd.Value.Date.AddDays(1).AddSeconds(-1)
        );

        salesReportViewer.LocalReport.DataSources.Clear();
        salesReportViewer.LocalReport.DataSources.Add(
            new ReportDataSource("SalesReportDataSet", data)
        );

        salesReportViewer.RefreshReport();
    }
}
