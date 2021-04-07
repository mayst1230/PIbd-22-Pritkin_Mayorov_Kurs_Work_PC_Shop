
namespace ComputerEquipmentStoreView
{
    partial class LinkAssemblyForm
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
            this.ButtonLinkAssembly = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.comboBoxPurchase = new System.Windows.Forms.ComboBox();
            this.labelNamePurchase = new System.Windows.Forms.Label();
            this.labelAssembly = new System.Windows.Forms.Label();
            this.textBoxAssembly = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonLinkAssembly
            // 
            this.ButtonLinkAssembly.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonLinkAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLinkAssembly.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonLinkAssembly.Location = new System.Drawing.Point(16, 400);
            this.ButtonLinkAssembly.Name = "ButtonLinkAssembly";
            this.ButtonLinkAssembly.Size = new System.Drawing.Size(344, 52);
            this.ButtonLinkAssembly.TabIndex = 23;
            this.ButtonLinkAssembly.Text = "Привязать";
            this.ButtonLinkAssembly.UseVisualStyleBackColor = false;
            this.ButtonLinkAssembly.Click += new System.EventHandler(this.ButtonLinkAssembly_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonCancel.Location = new System.Drawing.Point(369, 400);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(344, 52);
            this.ButtonCancel.TabIndex = 24;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // comboBoxPurchase
            // 
            this.comboBoxPurchase.FormattingEnabled = true;
            this.comboBoxPurchase.Location = new System.Drawing.Point(261, 43);
            this.comboBoxPurchase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPurchase.Name = "comboBoxPurchase";
            this.comboBoxPurchase.Size = new System.Drawing.Size(448, 28);
            this.comboBoxPurchase.TabIndex = 25;
            this.comboBoxPurchase.SelectedIndexChanged += new System.EventHandler(this.comboBoxPurchase_SelectedIndexChanged);
            // 
            // labelNamePurchase
            // 
            this.labelNamePurchase.AutoSize = true;
            this.labelNamePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNamePurchase.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNamePurchase.Location = new System.Drawing.Point(84, 31);
            this.labelNamePurchase.Name = "labelNamePurchase";
            this.labelNamePurchase.Size = new System.Drawing.Size(113, 29);
            this.labelNamePurchase.TabIndex = 26;
            this.labelNamePurchase.Text = "Покупка:";
            // 
            // labelAssembly
            // 
            this.labelAssembly.AutoSize = true;
            this.labelAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAssembly.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelAssembly.Location = new System.Drawing.Point(99, 128);
            this.labelAssembly.Name = "labelAssembly";
            this.labelAssembly.Size = new System.Drawing.Size(103, 29);
            this.labelAssembly.TabIndex = 27;
            this.labelAssembly.Text = "Сборка:";
            // 
            // textBoxAssembly
            // 
            this.textBoxAssembly.Location = new System.Drawing.Point(261, 142);
            this.textBoxAssembly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAssembly.Name = "textBoxAssembly";
            this.textBoxAssembly.ReadOnly = true;
            this.textBoxAssembly.Size = new System.Drawing.Size(450, 26);
            this.textBoxAssembly.TabIndex = 28;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelCount.Location = new System.Drawing.Point(16, 218);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(158, 29);
            this.labelCount.TabIndex = 29;
            this.labelCount.Text = "Количество:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCost.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelCost.Location = new System.Drawing.Point(34, 308);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(146, 29);
            this.labelCost.TabIndex = 30;
            this.labelCost.Text = "Стоимость:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(261, 232);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(448, 26);
            this.textBoxCount.TabIndex = 31;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(261, 322);
            this.textBoxCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(448, 26);
            this.textBoxCost.TabIndex = 32;
            // 
            // LinkAssemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(729, 469);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxAssembly);
            this.Controls.Add(this.labelAssembly);
            this.Controls.Add(this.labelNamePurchase);
            this.Controls.Add(this.comboBoxPurchase);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonLinkAssembly);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LinkAssemblyForm";
            this.Text = "Привязка сборки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLinkAssembly;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.ComboBox comboBoxPurchase;
        private System.Windows.Forms.Label labelNamePurchase;
        private System.Windows.Forms.Label labelAssembly;
        private System.Windows.Forms.TextBox textBoxAssembly;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxCost;
    }
}