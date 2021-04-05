
namespace ComputerEquipmentStoreView
{
    partial class PurchaseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelNamePurhase = new System.Windows.Forms.Label();
            this.labelDatePurchase = new System.Windows.Forms.Label();
            this.textBoxNamePurchase = new System.Windows.Forms.TextBox();
            this.textBoxDatePurchase = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonChange = new System.Windows.Forms.Button();
            this.ButtonAddProduct = new System.Windows.Forms.Button();
            this.ButtonSaveProduct = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNamePurhase
            // 
            this.labelNamePurhase.AutoSize = true;
            this.labelNamePurhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNamePurhase.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNamePurhase.Location = new System.Drawing.Point(8, 6);
            this.labelNamePurhase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNamePurhase.Name = "labelNamePurhase";
            this.labelNamePurhase.Size = new System.Drawing.Size(232, 29);
            this.labelNamePurhase.TabIndex = 11;
            this.labelNamePurhase.Text = "Название покупки:";
            // 
            // labelDatePurchase
            // 
            this.labelDatePurchase.AutoSize = true;
            this.labelDatePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDatePurchase.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelDatePurchase.Location = new System.Drawing.Point(480, 6);
            this.labelDatePurchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatePurchase.Name = "labelDatePurchase";
            this.labelDatePurchase.Size = new System.Drawing.Size(173, 29);
            this.labelDatePurchase.TabIndex = 12;
            this.labelDatePurchase.Text = "Дата покупки:";
            // 
            // textBoxNamePurchase
            // 
            this.textBoxNamePurchase.Location = new System.Drawing.Point(241, 11);
            this.textBoxNamePurchase.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNamePurchase.Name = "textBoxNamePurchase";
            this.textBoxNamePurchase.Size = new System.Drawing.Size(220, 20);
            this.textBoxNamePurchase.TabIndex = 13;
            // 
            // textBoxDatePurchase
            // 
            this.textBoxDatePurchase.Location = new System.Drawing.Point(657, 11);
            this.textBoxDatePurchase.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDatePurchase.Name = "textBoxDatePurchase";
            this.textBoxDatePurchase.Size = new System.Drawing.Size(220, 20);
            this.textBoxDatePurchase.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewProducts);
            this.groupBox1.Controls.Add(this.ButtonRefresh);
            this.groupBox1.Controls.Add(this.ButtonDelete);
            this.groupBox1.Controls.Add(this.ButtonChange);
            this.groupBox1.Controls.Add(this.ButtonAddProduct);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(8, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(873, 343);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Товары";
            // 
            // dataGridViewProducts
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnProductName,
            this.ColumnCount,
            this.ColumnPrice});
            this.dataGridViewProducts.Location = new System.Drawing.Point(4, 16);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 62;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewProducts.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProducts.RowTemplate.Height = 28;
            this.dataGridViewProducts.Size = new System.Drawing.Size(680, 323);
            this.dataGridViewProducts.TabIndex = 20;
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.MinimumWidth = 8;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnProductName
            // 
            this.ColumnProductName.FillWeight = 300F;
            this.ColumnProductName.HeaderText = "Название продукта";
            this.ColumnProductName.MinimumWidth = 8;
            this.ColumnProductName.Name = "ColumnProductName";
            this.ColumnProductName.Width = 300;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.MinimumWidth = 8;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 150;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPrice.FillWeight = 300F;
            this.ColumnPrice.HeaderText = "Цена";
            this.ColumnPrice.MinimumWidth = 8;
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonRefresh.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonRefresh.Location = new System.Drawing.Point(688, 131);
            this.ButtonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(181, 34);
            this.ButtonRefresh.TabIndex = 19;
            this.ButtonRefresh.Text = "Обновить";
            this.ButtonRefresh.UseVisualStyleBackColor = false;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonDelete.Location = new System.Drawing.Point(688, 93);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(181, 34);
            this.ButtonDelete.TabIndex = 18;
            this.ButtonDelete.Text = "Удалить запись";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonChange
            // 
            this.ButtonChange.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonChange.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonChange.Location = new System.Drawing.Point(688, 55);
            this.ButtonChange.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(181, 34);
            this.ButtonChange.TabIndex = 17;
            this.ButtonChange.Text = "Изменить запись";
            this.ButtonChange.UseVisualStyleBackColor = false;
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // ButtonAddProduct
            // 
            this.ButtonAddProduct.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonAddProduct.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonAddProduct.Location = new System.Drawing.Point(688, 17);
            this.ButtonAddProduct.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAddProduct.Name = "ButtonAddProduct";
            this.ButtonAddProduct.Size = new System.Drawing.Size(181, 34);
            this.ButtonAddProduct.TabIndex = 16;
            this.ButtonAddProduct.Text = "Добавить товар";
            this.ButtonAddProduct.UseVisualStyleBackColor = false;
            this.ButtonAddProduct.Click += new System.EventHandler(this.ButtonAddProduct_Click);
            // 
            // ButtonSaveProduct
            // 
            this.ButtonSaveProduct.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonSaveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSaveProduct.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonSaveProduct.Location = new System.Drawing.Point(8, 408);
            this.ButtonSaveProduct.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSaveProduct.Name = "ButtonSaveProduct";
            this.ButtonSaveProduct.Size = new System.Drawing.Size(229, 34);
            this.ButtonSaveProduct.TabIndex = 21;
            this.ButtonSaveProduct.Text = "Сохранить";
            this.ButtonSaveProduct.UseVisualStyleBackColor = false;
            this.ButtonSaveProduct.Click += new System.EventHandler(this.ButtonSaveProduct_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonCancel.Location = new System.Drawing.Point(241, 408);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(229, 34);
            this.ButtonCancel.TabIndex = 22;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(892, 464);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSaveProduct);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxDatePurchase);
            this.Controls.Add(this.textBoxNamePurchase);
            this.Controls.Add(this.labelDatePurchase);
            this.Controls.Add(this.labelNamePurhase);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNamePurhase;
        private System.Windows.Forms.Label labelDatePurchase;
        private System.Windows.Forms.TextBox textBoxNamePurchase;
        private System.Windows.Forms.TextBox textBoxDatePurchase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonChange;
        private System.Windows.Forms.Button ButtonAddProduct;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button ButtonSaveProduct;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
    }
}