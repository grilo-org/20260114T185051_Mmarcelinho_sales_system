
namespace SalesSystem.WinForms.Forms
{
    partial class SaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleForm));
            cmbClients = new ComboBox();
            dgvProducts = new DataGridView();
            nudQuantity = new NumericUpDown();
            dgvSaleItems = new DataGridView();
            lblClient = new Label();
            btnAddItem = new Button();
            btnFinishSale = new Button();
            lblQuantity = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).BeginInit();
            SuspendLayout();
            // 
            // cmbClients
            // 
            cmbClients.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(147, 50);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(151, 28);
            cmbClients.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(70, 115);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(598, 126);
            dgvProducts.TabIndex = 1;
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(71, 316);
            nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(150, 27);
            nudQuantity.TabIndex = 2;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dgvSaleItems
            // 
            dgvSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSaleItems.Location = new Point(71, 367);
            dgvSaleItems.MultiSelect = false;
            dgvSaleItems.Name = "dgvSaleItems";
            dgvSaleItems.ReadOnly = true;
            dgvSaleItems.RowHeadersWidth = 51;
            dgvSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleItems.Size = new Size(597, 115);
            dgvSaleItems.TabIndex = 3;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Segoe UI", 11F);
            lblClient.Location = new Point(71, 53);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(71, 25);
            lblClient.TabIndex = 4;
            lblClient.Text = "Cliente";
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(192, 255, 255);
            btnAddItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddItem.Location = new Point(283, 303);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(177, 47);
            btnAddItem.TabIndex = 5;
            btnAddItem.Text = "Adicionar item";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnFinishSale
            // 
            btnFinishSale.BackColor = Color.FromArgb(192, 255, 192);
            btnFinishSale.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFinishSale.Location = new Point(287, 519);
            btnFinishSale.Name = "btnFinishSale";
            btnFinishSale.Size = new Size(173, 55);
            btnFinishSale.TabIndex = 6;
            btnFinishSale.Text = "Finalizar venda";
            btnFinishSale.UseVisualStyleBackColor = false;
            btnFinishSale.Click += btnFinishSale_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 11F);
            lblQuantity.Location = new Point(71, 277);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(111, 25);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "Quantidade";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(71, 534);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(126, 25);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total: R$ 0,00";
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(781, 641);
            Controls.Add(lblTotal);
            Controls.Add(lblQuantity);
            Controls.Add(btnFinishSale);
            Controls.Add(btnAddItem);
            Controls.Add(lblClient);
            Controls.Add(dgvSaleItems);
            Controls.Add(nudQuantity);
            Controls.Add(dgvProducts);
            Controls.Add(cmbClients);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SaleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vendas";
            Load += SaleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private NumericUpDown numericUpDown1;
        private DataGridView dataGridView2;
        private Label lblClient;
        private Button btnAddItem;
        private Button button1;
        private Button btnFinishSale;
        private Label lblQuantity;
        private Label label2;
        private Label lblTotal;
        private ComboBox cmbClients;
        private DataGridView dgvProducts;
        private NumericUpDown nudQuantity;
        private DataGridView dgvSaleItems;
    }
}