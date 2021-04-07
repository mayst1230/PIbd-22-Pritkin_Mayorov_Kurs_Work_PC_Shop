namespace ComputerEquipmentStoreViewSeller
{
    partial class AssemblyComponentForm
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
            this.labelComponents = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxAssembly
            // 
            this.comboBoxAssembly.FormattingEnabled = true;
            this.comboBoxAssembly.Location = new System.Drawing.Point(12, 25);
            this.comboBoxAssembly.Name = "comboBoxAssembly";
            this.comboBoxAssembly.Size = new System.Drawing.Size(344, 21);
            this.comboBoxAssembly.TabIndex = 1;
            // 
            // labelAssembly
            // 
            this.labelAssembly.AutoSize = true;
            this.labelAssembly.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAssembly.Location = new System.Drawing.Point(12, 9);
            this.labelAssembly.Name = "labelAssembly";
            this.labelAssembly.Size = new System.Drawing.Size(47, 13);
            this.labelAssembly.TabIndex = 2;
            this.labelAssembly.Text = "Сборка:";
            // 
            // labelComponents
            // 
            this.labelComponents.AutoSize = true;
            this.labelComponents.ForeColor = System.Drawing.SystemColors.Control;
            this.labelComponents.Location = new System.Drawing.Point(12, 59);
            this.labelComponents.Name = "labelComponents";
            this.labelComponents.Size = new System.Drawing.Size(94, 13);
            this.labelComponents.TabIndex = 3;
            this.labelComponents.Text = "Комплектующие:";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Brown;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSave.Location = new System.Drawing.Point(94, 306);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(129, 26);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Brown;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.Location = new System.Drawing.Point(227, 306);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 26);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AssemblyComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(368, 345);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelComponents);
            this.Controls.Add(this.labelAssembly);
            this.Controls.Add(this.comboBoxAssembly);
            this.Name = "AssemblyComponentForm";
            this.Text = "Привязка комлпектующих к сборкам";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxAssembly;
        private System.Windows.Forms.Label labelAssembly;
        private System.Windows.Forms.Label labelComponents;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}