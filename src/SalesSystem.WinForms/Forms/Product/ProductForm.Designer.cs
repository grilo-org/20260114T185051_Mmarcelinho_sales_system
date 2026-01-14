namespace SalesSystem.WinForms.Forms
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            btnDelete = new Button();
            txtName = new TextBox();
            txtDescription = new TextBox();
            btnUpdate = new Button();
            btnSave = new Button();
            dgvProducts = new DataGridView();
            numericPrice = new NumericUpDown();
            numericStock = new NumericUpDown();
            lbPrice = new Label();
            lbStock = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStock).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 192, 192);
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(180, 124);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 39);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Deletar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.Location = new Point(64, 46);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nome";
            txtName.Size = new Size(125, 31);
            txtName.TabIndex = 14;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(229, 46);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Descrição";
            txtDescription.Size = new Size(125, 31);
            txtDescription.TabIndex = 13;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 255, 192);
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(323, 124);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(123, 43);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Atualizar";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 255, 192);
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(477, 124);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(123, 43);
            btnSave.TabIndex = 11;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Bottom;
            dgvProducts.Location = new Point(0, 200);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(800, 250);
            dgvProducts.TabIndex = 9;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // numericPrice
            // 
            numericPrice.DecimalPlaces = 2;
            numericPrice.Location = new Point(385, 46);
            numericPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(150, 27);
            numericPrice.TabIndex = 16;
            numericPrice.ThousandsSeparator = true;
            // 
            // numericStock
            // 
            numericStock.Location = new Point(571, 45);
            numericStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericStock.Name = "numericStock";
            numericStock.Size = new Size(150, 27);
            numericStock.TabIndex = 17;
            // 
            // lbPrice
            // 
            lbPrice.AutoSize = true;
            lbPrice.Font = new Font("Segoe UI", 11F);
            lbPrice.Location = new Point(430, 18);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(60, 25);
            lbPrice.TabIndex = 18;
            lbPrice.Text = "Preço";
            // 
            // lbStock
            // 
            lbStock.AutoSize = true;
            lbStock.Font = new Font("Segoe UI", 11F);
            lbStock.Location = new Point(610, 17);
            lbStock.Name = "lbStock";
            lbStock.Size = new Size(79, 25);
            lbStock.TabIndex = 19;
            lbStock.Text = "Estoque";
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(lbStock);
            Controls.Add(lbPrice);
            Controls.Add(numericStock);
            Controls.Add(numericPrice);
            Controls.Add(btnDelete);
            Controls.Add(txtName);
            Controls.Add(txtDescription);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(dgvProducts);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produtos";
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private TextBox txtName;
        private TextBox txtDescription;
        private Button btnUpdate;
        private Button btnSave;
        private DataGridView dgvProducts;
        private NumericUpDown numericPrice;
        private NumericUpDown numericStock;
        private Label lbPrice;
        private Label lbStock;
    }
}