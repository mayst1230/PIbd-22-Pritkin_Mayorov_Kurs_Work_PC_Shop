namespace ComputerEquipmentStoreViewSeller
{
    partial class LinkComponentForm
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
            this.comboBoxAssembly = new System.Windows.Forms.ComboBox();
            this.labelAssembly = new System.Windows.Forms.Label();
            this.buttonLinkComponent = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxComponent = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.labelComponent = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAssembly
            // 
            this.comboBoxAssembly.FormattingEnabled = true;
            this.comboBoxAssembly.Location = new System.Drawing.Point(83, 7);
            this.comboBoxAssembly.Name = "comboBoxAssembly";
            this.comboBoxAssembly.Size = new System.Drawing.Size(278, 21);
            this.comboBoxAssembly.TabIndex = 1;
            this.comboBoxAssembly.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssembly_SelectedIndexChanged);
            // 
            // labelAssembly
            // 
            this.labelAssembly.AutoSize = true;
            this.labelAssembly.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAssembly.Location = new System.Drawing.Point(36, 9);
            this.labelAssembly.Name = "labelAssembly";
            this.labelAssembly.Size = new System.Drawing.Size(47, 13);
            this.labelAssembly.TabIndex = 2;
            this.labelAssembly.Text = "Сборка:";
            // 
            // buttonLinkComponent
            // 
            this.buttonLinkComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonLinkComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLinkComponent.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonLinkComponent.Location = new System.Drawing.Point(9, 102);
            this.buttonLinkComponent.Name = "buttonLinkComponent";
            this.buttonLinkComponent.Size = new System.Drawing.Size(129, 26);
            this.buttonLinkComponent.TabIndex = 4;
            this.buttonLinkComponent.Text = "Сохранить";
            this.buttonLinkComponent.UseVisualStyleBackColor = false;
            this.buttonLinkComponent.Click += new System.EventHandler(this.buttonLinkComponent_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Brown;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.Location = new System.Drawing.Point(143, 102);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 26);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxComponent
            // 
            this.textBoxComponent.Location = new System.Drawing.Point(83, 32);
            this.textBoxComponent.Name = "textBoxComponent";
            this.textBoxComponent.Size = new System.Drawing.Size(278, 20);
            this.textBoxComponent.TabIndex = 29;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(83, 55);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(278, 20);
            this.textBoxCount.TabIndex = 32;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(83, 79);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(278, 20);
            this.textBoxCost.TabIndex = 33;
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.ForeColor = System.Drawing.SystemColors.Control;
            this.labelComponent.Location = new System.Drawing.Point(17, 34);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(66, 13);
            this.labelComponent.TabIndex = 34;
            this.labelComponent.Text = "Компонент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.ForeColor = System.Drawing.SystemColors.Control;
            this.labelCount.Location = new System.Drawing.Point(12, 57);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 35;
            this.labelCount.Text = "Количество:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.ForeColor = System.Drawing.SystemColors.Control;
            this.labelCost.Location = new System.Drawing.Point(17, 81);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(65, 13);
            this.labelCost.TabIndex = 36;
            this.labelCost.Text = "Стоимость:";
            // 
            // LinkComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(368, 142);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComponent);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxComponent);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonLinkComponent);
            this.Controls.Add(this.labelAssembly);
            this.Controls.Add(this.comboBoxAssembly);
            this.Name = "LinkComponentForm";
            this.Text = "Привязка комлпектующих к сборкам";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxAssembly;
        private System.Windows.Forms.Label labelAssembly;
        private System.Windows.Forms.Button buttonLinkComponent;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxComponent;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelCost;
    }
}