
namespace ComputerEquipmentStoreView
{
    partial class AssemblyForm
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
            this.ButtonSaveAssembly = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.labelNameAssembly = new System.Windows.Forms.Label();
            this.textBoxNameAssembly = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonSaveAssembly
            // 
            this.ButtonSaveAssembly.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonSaveAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSaveAssembly.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonSaveAssembly.Location = new System.Drawing.Point(11, 56);
            this.ButtonSaveAssembly.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonSaveAssembly.Name = "ButtonSaveAssembly";
            this.ButtonSaveAssembly.Size = new System.Drawing.Size(181, 34);
            this.ButtonSaveAssembly.TabIndex = 8;
            this.ButtonSaveAssembly.Text = "Сохранить сборку";
            this.ButtonSaveAssembly.UseVisualStyleBackColor = false;
            this.ButtonSaveAssembly.Click += new System.EventHandler(this.ButtonSaveAssembly_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonCancel.Location = new System.Drawing.Point(196, 56);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(181, 34);
            this.ButtonCancel.TabIndex = 9;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelNameAssembly
            // 
            this.labelNameAssembly.AutoSize = true;
            this.labelNameAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameAssembly.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNameAssembly.Location = new System.Drawing.Point(8, 21);
            this.labelNameAssembly.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNameAssembly.Name = "labelNameAssembly";
            this.labelNameAssembly.Size = new System.Drawing.Size(219, 29);
            this.labelNameAssembly.TabIndex = 10;
            this.labelNameAssembly.Text = "Название сборки:";
            // 
            // textBoxNameAssembly
            // 
            this.textBoxNameAssembly.Location = new System.Drawing.Point(158, 23);
            this.textBoxNameAssembly.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNameAssembly.Name = "textBoxNameAssembly";
            this.textBoxNameAssembly.Size = new System.Drawing.Size(220, 20);
            this.textBoxNameAssembly.TabIndex = 11;
            // 
            // AssemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(385, 101);
            this.Controls.Add(this.textBoxNameAssembly);
            this.Controls.Add(this.labelNameAssembly);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSaveAssembly);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AssemblyForm";
            this.Text = "Сборка";
            this.Load += new System.EventHandler(this.AssemblyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSaveAssembly;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label labelNameAssembly;
        private System.Windows.Forms.TextBox textBoxNameAssembly;
    }
}