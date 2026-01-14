namespace SalesSystem.WinForms.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnClients = new Button();
            btnProducts = new Button();
            btnSales = new Button();
            btnReport = new Button();
            SuspendLayout();
            // 
            // btnClients
            // 
            btnClients.BackColor = Color.FromArgb(192, 255, 192);
            btnClients.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClients.Location = new Point(41, 42);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(280, 91);
            btnClients.TabIndex = 0;
            btnClients.Text = "Clientes";
            btnClients.UseVisualStyleBackColor = false;
            btnClients.Click += btnClients_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(255, 192, 192);
            btnProducts.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProducts.Location = new Point(432, 42);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(280, 91);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Produtos";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSales
            // 
            btnSales.BackColor = Color.FromArgb(192, 192, 255);
            btnSales.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSales.Location = new Point(41, 245);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(280, 91);
            btnSales.TabIndex = 2;
            btnSales.Text = "Vendas";
            btnSales.UseVisualStyleBackColor = false;
            btnSales.Click += btnSales_Click;
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.FromArgb(255, 224, 192);
            btnReport.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReport.Location = new Point(432, 245);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(280, 91);
            btnReport.TabIndex = 3;
            btnReport.Text = "Gerar relatório";
            btnReport.UseVisualStyleBackColor = false;
            btnReport.Click += btnReport_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReport);
            Controls.Add(btnSales);
            Controls.Add(btnProducts);
            Controls.Add(btnClients);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClients;
        private Button btnProducts;
        private Button btnSales;
        private Button btnReport;
    }
}