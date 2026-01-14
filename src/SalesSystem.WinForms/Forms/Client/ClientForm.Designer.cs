namespace SalesSystem.WinForms.Forms
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            dgvClients = new DataGridView();
            txtPhone = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            txtEmail = new TextBox();
            txtName = new TextBox();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Dock = DockStyle.Bottom;
            dgvClients.Location = new Point(0, 200);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(800, 250);
            dgvClients.TabIndex = 0;
            dgvClients.CellClick += dgvClients_CellClick;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(494, 55);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Telefone";
            txtPhone.Size = new Size(125, 31);
            txtPhone.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 255, 192);
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(494, 134);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 42);
            btnSave.TabIndex = 4;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 255, 192);
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(333, 134);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 42);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Atualizar";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(322, 55);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(125, 31);
            txtEmail.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.Location = new Point(150, 55);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nome";
            txtName.Size = new Size(125, 31);
            txtName.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(170, 134);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(105, 42);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Deletar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(txtName);
            Controls.Add(txtEmail);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtPhone);
            Controls.Add(dgvClients);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente";
            Load += ClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClients;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox txtPhone;
        private Button btnSave;
        private Button btnUpdate;
        private TextBox txtEmail;
        private TextBox txtName;
        private Button btnDelete;
    }
}