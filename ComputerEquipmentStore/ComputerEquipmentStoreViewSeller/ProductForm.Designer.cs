namespace ComputerEquipmentStoreViewSeller
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelProductPrice = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.buttonUpdateComponent = new System.Windows.Forms.Button();
            this.buttonDeleteComponent = new System.Windows.Forms.Button();
            this.buttonChangeComponent = new System.Windows.Forms.Button();
            this.buttonAddComponent = new System.Windows.Forms.Button();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComponents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelProductName.Location = new System.Drawing.Point(17, 15);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(60, 13);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Название:";
            // 
            // labelProductPrice
            // 
            this.labelProductPrice.AutoSize = true;
            this.labelProductPrice.ForeColor = System.Drawing.SystemColors.Control;
            this.labelProductPrice.Location = new System.Drawing.Point(41, 43);
            this.labelProductPrice.Name = "labelProductPrice";
            this.labelProductPrice.Size = new System.Drawing.Size(36, 13);
            this.labelProductPrice.TabIndex = 1;
            this.labelProductPrice.Text = "Цена:";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(105, 12);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(322, 20);
            this.textBoxProductName.TabIndex = 2;
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Location = new System.Drawing.Point(105, 40);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.Size = new System.Drawing.Size(321, 20);
            this.textBoxProductPrice.TabIndex = 3;
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.buttonUpdateComponent);
            this.groupBoxComponents.Controls.Add(this.buttonDeleteComponent);
            this.groupBoxComponents.Controls.Add(this.buttonChangeComponent);
            this.groupBoxComponents.Controls.Add(this.buttonAddComponent);
            this.groupBoxComponents.Controls.Add(this.dataGridViewComponents);
            this.groupBoxComponents.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBoxComponents.Location = new System.Drawing.Point(19, 86);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(768, 319);
            this.groupBoxComponents.TabIndex = 4;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Комплектующие";
            // 
            // buttonUpdateComponent
            // 
            this.buttonUpdateComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonUpdateComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateComponent.Location = new System.Drawing.Point(611, 157);
            this.buttonUpdateComponent.Name = "buttonUpdateComponent";
            this.buttonUpdateComponent.Size = new System.Drawing.Size(134, 28);
            this.buttonUpdateComponent.TabIndex = 4;
            this.buttonUpdateComponent.Text = "Обновить";
            this.buttonUpdateComponent.UseVisualStyleBackColor = false;
            this.buttonUpdateComponent.MouseCaptureChanged += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonDeleteComponent
            // 
            this.buttonDeleteComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonDeleteComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteComponent.Location = new System.Drawing.Point(611, 115);
            this.buttonDeleteComponent.Name = "buttonDeleteComponent";
            this.buttonDeleteComponent.Size = new System.Drawing.Size(134, 27);
            this.buttonDeleteComponent.TabIndex = 3;
            this.buttonDeleteComponent.Text = "Удалить";
            this.buttonDeleteComponent.UseVisualStyleBackColor = false;
            this.buttonDeleteComponent.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonChangeComponent
            // 
            this.buttonChangeComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonChangeComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeComponent.Location = new System.Drawing.Point(611, 74);
            this.buttonChangeComponent.Name = "buttonChangeComponent";
            this.buttonChangeComponent.Size = new System.Drawing.Size(134, 27);
            this.buttonChangeComponent.TabIndex = 2;
            this.buttonChangeComponent.Text = "Изменить";
            this.buttonChangeComponent.UseVisualStyleBackColor = false;
            this.buttonChangeComponent.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonAddComponent
            // 
            this.buttonAddComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonAddComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddComponent.Location = new System.Drawing.Point(611, 36);
            this.buttonAddComponent.Name = "buttonAddComponent";
            this.buttonAddComponent.Size = new System.Drawing.Size(134, 26);
            this.buttonAddComponent.TabIndex = 1;
            this.buttonAddComponent.Text = "Добавить";
            this.buttonAddComponent.UseVisualStyleBackColor = false;
            this.buttonAddComponent.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnComponents,
            this.ColumnCount,
            this.ColumnPrice});
            this.dataGridViewComponents.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewComponents.Location = new System.Drawing.Point(8, 19);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewComponents.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewComponents.Size = new System.Drawing.Size(579, 288);
            this.dataGridViewComponents.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnId.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnComponents
            // 
            this.ColumnComponents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComponents.HeaderText = "Комплектующее";
            this.ColumnComponents.Name = "ColumnComponents";
            // 
            // ColumnCount
            // 
            this.ColumnCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "Сумма";
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Brown;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSave.Location = new System.Drawing.Point(560, 417);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(84, 24);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Brown;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.Location = new System.Drawing.Point(659, 417);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 24);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxProductPrice);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.labelProductPrice);
            this.Controls.Add(this.labelProductName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductForm";
            this.Text = "Товар";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelProductPrice;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.TextBox textBoxProductPrice;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
        private System.Windows.Forms.Button buttonUpdateComponent;
        private System.Windows.Forms.Button buttonDeleteComponent;
        private System.Windows.Forms.Button buttonChangeComponent;
        private System.Windows.Forms.Button buttonAddComponent;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComponents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
    }
}