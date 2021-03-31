namespace ComputerEquipmentStoreViewSeller
{
    partial class OrderForm
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
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonUpdateOrder = new System.Windows.Forms.Button();
            this.buttonDeleteOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateOrder.Location = new System.Drawing.Point(646, 12);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(142, 27);
            this.buttonCreateOrder.TabIndex = 0;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewOrders.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrders.Size = new System.Drawing.Size(607, 426);
            this.dataGridViewOrders.TabIndex = 2;
            // 
            // buttonUpdateOrder
            // 
            this.buttonUpdateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateOrder.Location = new System.Drawing.Point(647, 50);
            this.buttonUpdateOrder.Name = "buttonUpdateOrder";
            this.buttonUpdateOrder.Size = new System.Drawing.Size(140, 24);
            this.buttonUpdateOrder.TabIndex = 3;
            this.buttonUpdateOrder.Text = "Изменить заказ";
            this.buttonUpdateOrder.UseVisualStyleBackColor = true;
            this.buttonUpdateOrder.Click += new System.EventHandler(this.buttonUpdateOrder_Click);
            // 
            // buttonDeleteOrder
            // 
            this.buttonDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteOrder.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteOrder.Location = new System.Drawing.Point(647, 84);
            this.buttonDeleteOrder.Name = "buttonDeleteOrder";
            this.buttonDeleteOrder.Size = new System.Drawing.Size(139, 24);
            this.buttonDeleteOrder.TabIndex = 4;
            this.buttonDeleteOrder.Text = "Удалить заказ";
            this.buttonDeleteOrder.UseVisualStyleBackColor = true;
            this.buttonDeleteOrder.Click += new System.EventHandler(this.buttonDeleteOrder_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDeleteOrder);
            this.Controls.Add(this.buttonUpdateOrder);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.buttonCreateOrder);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "OrderForm";
            this.Text = "Заказы на товары";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonUpdateOrder;
        private System.Windows.Forms.Button buttonDeleteOrder;
    }
}