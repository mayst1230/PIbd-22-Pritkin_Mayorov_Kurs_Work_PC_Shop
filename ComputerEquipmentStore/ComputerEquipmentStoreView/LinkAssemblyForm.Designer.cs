
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonLinkAssembly
            // 
            this.ButtonLinkAssembly.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonLinkAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLinkAssembly.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonLinkAssembly.Location = new System.Drawing.Point(11, 260);
            this.ButtonLinkAssembly.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLinkAssembly.Name = "ButtonLinkAssembly";
            this.ButtonLinkAssembly.Size = new System.Drawing.Size(229, 34);
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
            this.ButtonCancel.Location = new System.Drawing.Point(246, 260);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(229, 34);
            this.ButtonCancel.TabIndex = 24;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // comboBoxPurchase
            // 
            this.comboBoxPurchase.FormattingEnabled = true;
            this.comboBoxPurchase.Location = new System.Drawing.Point(174, 28);
            this.comboBoxPurchase.Name = "comboBoxPurchase";
            this.comboBoxPurchase.Size = new System.Drawing.Size(300, 21);
            this.comboBoxPurchase.TabIndex = 25;
            this.comboBoxPurchase.SelectedIndexChanged += new System.EventHandler(this.comboBoxPurchase_SelectedIndexChanged);
            // 
            // labelNamePurchase
            // 
            this.labelNamePurchase.AutoSize = true;
            this.labelNamePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNamePurchase.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNamePurchase.Location = new System.Drawing.Point(56, 20);
            this.labelNamePurchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.labelAssembly.Location = new System.Drawing.Point(66, 83);
            this.labelAssembly.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAssembly.Name = "labelAssembly";
            this.labelAssembly.Size = new System.Drawing.Size(103, 29);
            this.labelAssembly.TabIndex = 27;
            this.labelAssembly.Text = "Сборка:";
            // 
            // textBoxAssembly
            // 
            this.textBoxAssembly.Location = new System.Drawing.Point(174, 92);
            this.textBoxAssembly.Name = "textBoxAssembly";
            this.textBoxAssembly.ReadOnly = true;
            this.textBoxAssembly.Size = new System.Drawing.Size(301, 20);
            this.textBoxAssembly.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(11, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "Количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(23, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Стоимость:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(174, 151);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(300, 20);
            this.textBoxCount.TabIndex = 31;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(174, 209);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(300, 20);
            this.textBoxCost.TabIndex = 32;
            // 
            // LinkAssemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(486, 305);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAssembly);
            this.Controls.Add(this.labelAssembly);
            this.Controls.Add(this.labelNamePurchase);
            this.Controls.Add(this.comboBoxPurchase);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonLinkAssembly);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxCost;
    }
}