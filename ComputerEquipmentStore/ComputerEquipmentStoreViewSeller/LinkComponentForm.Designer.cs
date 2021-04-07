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
            this.comboBoxAssembly.Location = new System.Drawing.Point(124, 11);
            this.comboBoxAssembly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAssembly.Name = "comboBoxAssembly";
            this.comboBoxAssembly.Size = new System.Drawing.Size(415, 28);
            this.comboBoxAssembly.TabIndex = 1;
            this.comboBoxAssembly.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssembly_SelectedIndexChanged);
            // 
            // labelAssembly
            // 
            this.labelAssembly.AutoSize = true;
            this.labelAssembly.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAssembly.Location = new System.Drawing.Point(54, 14);
            this.labelAssembly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAssembly.Name = "labelAssembly";
            this.labelAssembly.Size = new System.Drawing.Size(68, 20);
            this.labelAssembly.TabIndex = 2;
            this.labelAssembly.Text = "Сборка:";
            // 
            // buttonLinkComponent
            // 
            this.buttonLinkComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonLinkComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLinkComponent.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonLinkComponent.Location = new System.Drawing.Point(13, 157);
            this.buttonLinkComponent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLinkComponent.Name = "buttonLinkComponent";
            this.buttonLinkComponent.Size = new System.Drawing.Size(194, 40);
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
            this.buttonCancel.Location = new System.Drawing.Point(215, 157);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(194, 40);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxComponent
            // 
            this.textBoxComponent.Location = new System.Drawing.Point(124, 49);
            this.textBoxComponent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxComponent.Name = "textBoxComponent";
            this.textBoxComponent.ReadOnly = true;
            this.textBoxComponent.Size = new System.Drawing.Size(415, 26);
            this.textBoxComponent.TabIndex = 29;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(124, 85);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(415, 26);
            this.textBoxCount.TabIndex = 32;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(124, 121);
            this.textBoxCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(415, 26);
            this.textBoxCost.TabIndex = 33;
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.ForeColor = System.Drawing.SystemColors.Control;
            this.labelComponent.Location = new System.Drawing.Point(25, 52);
            this.labelComponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(97, 20);
            this.labelComponent.TabIndex = 34;
            this.labelComponent.Text = "Компонент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.ForeColor = System.Drawing.SystemColors.Control;
            this.labelCount.Location = new System.Drawing.Point(18, 88);
            this.labelCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(104, 20);
            this.labelCount.TabIndex = 35;
            this.labelCount.Text = "Количество:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.ForeColor = System.Drawing.SystemColors.Control;
            this.labelCost.Location = new System.Drawing.Point(25, 124);
            this.labelCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(97, 20);
            this.labelCost.TabIndex = 36;
            this.labelCost.Text = "Стоимость:";
            // 
            // LinkComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(552, 218);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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