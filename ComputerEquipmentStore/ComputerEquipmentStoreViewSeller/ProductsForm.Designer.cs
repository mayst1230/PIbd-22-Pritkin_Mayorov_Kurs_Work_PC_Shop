namespace ComputerEquipmentStoreViewSeller
{
    partial class ProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.buttonProductAdd = new System.Windows.Forms.Button();
            this.buttonProductChange = new System.Windows.Forms.Button();
            this.buttonProductDelete = new System.Windows.Forms.Button();
            this.buttonProductUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewProducts.Location = new System.Drawing.Point(4, 6);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(489, 440);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // buttonProductAdd
            // 
            this.buttonProductAdd.BackColor = System.Drawing.Color.Brown;
            this.buttonProductAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonProductAdd.Location = new System.Drawing.Point(509, 34);
            this.buttonProductAdd.Name = "buttonProductAdd";
            this.buttonProductAdd.Size = new System.Drawing.Size(118, 25);
            this.buttonProductAdd.TabIndex = 1;
            this.buttonProductAdd.Text = "Добавить";
            this.buttonProductAdd.UseVisualStyleBackColor = false;
            this.buttonProductAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonProductChange
            // 
            this.buttonProductChange.BackColor = System.Drawing.Color.Brown;
            this.buttonProductChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductChange.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonProductChange.Location = new System.Drawing.Point(509, 71);
            this.buttonProductChange.Name = "buttonProductChange";
            this.buttonProductChange.Size = new System.Drawing.Size(118, 24);
            this.buttonProductChange.TabIndex = 2;
            this.buttonProductChange.Text = "Изменить";
            this.buttonProductChange.UseVisualStyleBackColor = false;
            this.buttonProductChange.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonProductDelete
            // 
            this.buttonProductDelete.BackColor = System.Drawing.Color.Brown;
            this.buttonProductDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonProductDelete.Location = new System.Drawing.Point(509, 110);
            this.buttonProductDelete.Name = "buttonProductDelete";
            this.buttonProductDelete.Size = new System.Drawing.Size(118, 22);
            this.buttonProductDelete.TabIndex = 3;
            this.buttonProductDelete.Text = "Удалить";
            this.buttonProductDelete.UseVisualStyleBackColor = false;
            this.buttonProductDelete.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonProductUpdate
            // 
            this.buttonProductUpdate.BackColor = System.Drawing.Color.Brown;
            this.buttonProductUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonProductUpdate.Location = new System.Drawing.Point(509, 147);
            this.buttonProductUpdate.Name = "buttonProductUpdate";
            this.buttonProductUpdate.Size = new System.Drawing.Size(118, 22);
            this.buttonProductUpdate.TabIndex = 4;
            this.buttonProductUpdate.Text = "Обновить";
            this.buttonProductUpdate.UseVisualStyleBackColor = false;
            this.buttonProductUpdate.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(654, 450);
            this.Controls.Add(this.buttonProductUpdate);
            this.Controls.Add(this.buttonProductDelete);
            this.Controls.Add(this.buttonProductChange);
            this.Controls.Add(this.buttonProductAdd);
            this.Controls.Add(this.dataGridViewProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductsForm";
            this.Text = "Товары";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button buttonProductAdd;
        private System.Windows.Forms.Button buttonProductChange;
        private System.Windows.Forms.Button buttonProductDelete;
        private System.Windows.Forms.Button buttonProductUpdate;
    }
}