namespace SalesSystem.WinForms.Forms
{
    partial class SalesReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            salesReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            pnlFilters = new Panel();
            btnGenerate = new Button();
            dtEnd = new DateTimePicker();
            dtStart = new DateTimePicker();
            pnlFilters.SuspendLayout();
            SuspendLayout();
            // 
            // salesReportViewer
            // 
            salesReportViewer.Dock = DockStyle.Fill;
            salesReportViewer.Location = new Point(0, 0);
            salesReportViewer.Name = "ReportViewer";
            salesReportViewer.ServerReport.BearerToken = null;
            salesReportViewer.Size = new Size(800, 450);
            salesReportViewer.TabIndex = 0;
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.PapayaWhip;
            pnlFilters.Controls.Add(btnGenerate);
            pnlFilters.Controls.Add(dtEnd);
            pnlFilters.Controls.Add(dtStart);
            pnlFilters.Dock = DockStyle.Bottom;
            pnlFilters.Location = new Point(0, 380);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(800, 70);
            pnlFilters.TabIndex = 1;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(192, 255, 192);
            btnGenerate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.Location = new Point(551, 9);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(191, 37);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Gerar relatório";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // dtEnd
            // 
            dtEnd.Format = DateTimePickerFormat.Short;
            dtEnd.Location = new Point(278, 15);
            dtEnd.Name = "dtEnd";
            dtEnd.Size = new Size(250, 27);
            dtEnd.TabIndex = 1;
            // 
            // dtStart
            // 
            dtStart.Format = DateTimePickerFormat.Short;
            dtStart.Location = new Point(12, 15);
            dtStart.Name = "dtStart";
            dtStart.Size = new Size(250, 27);
            dtStart.TabIndex = 0;
            // 
            // SalesReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlFilters);
            Controls.Add(salesReportViewer);
            Name = "SalesReportForm";
            Text = "Relatório de vendas";
            WindowState = FormWindowState.Maximized;
            pnlFilters.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer salesReportViewer;
        private Panel pnlFilters;
        private DateTimePicker dtStart;
        private Button btnGenerate;
        private DateTimePicker dtEnd;
    }
}