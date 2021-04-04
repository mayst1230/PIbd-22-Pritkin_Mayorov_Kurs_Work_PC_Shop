
namespace ComputerEquipmentStoreView
{
    partial class CommentForm
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
            this.labelNameAssembly = new System.Windows.Forms.Label();
            this.comboBoxAssembly = new System.Windows.Forms.ComboBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.labelText = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ButtonSaveProduct = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNameAssembly
            // 
            this.labelNameAssembly.AutoSize = true;
            this.labelNameAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameAssembly.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNameAssembly.Location = new System.Drawing.Point(11, 9);
            this.labelNameAssembly.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNameAssembly.Name = "labelNameAssembly";
            this.labelNameAssembly.Size = new System.Drawing.Size(103, 29);
            this.labelNameAssembly.TabIndex = 13;
            this.labelNameAssembly.Text = "Сборка:";
            // 
            // comboBoxAssembly
            // 
            this.comboBoxAssembly.FormattingEnabled = true;
            this.comboBoxAssembly.Location = new System.Drawing.Point(119, 12);
            this.comboBoxAssembly.Name = "comboBoxAssembly";
            this.comboBoxAssembly.Size = new System.Drawing.Size(354, 21);
            this.comboBoxAssembly.TabIndex = 16;
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(119, 69);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(354, 20);
            this.textBoxText.TabIndex = 17;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelText.Location = new System.Drawing.Point(29, 60);
            this.labelText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(85, 29);
            this.labelText.TabIndex = 18;
            this.labelText.Text = "Текст:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelDate.Location = new System.Drawing.Point(41, 113);
            this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(73, 29);
            this.labelDate.TabIndex = 19;
            this.labelDate.Text = "Дата:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(119, 119);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(354, 20);
            this.dateTimePicker.TabIndex = 20;
            // 
            // ButtonSaveProduct
            // 
            this.ButtonSaveProduct.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonSaveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSaveProduct.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonSaveProduct.Location = new System.Drawing.Point(11, 167);
            this.ButtonSaveProduct.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSaveProduct.Name = "ButtonSaveProduct";
            this.ButtonSaveProduct.Size = new System.Drawing.Size(229, 34);
            this.ButtonSaveProduct.TabIndex = 23;
            this.ButtonSaveProduct.Text = "Сохранить";
            this.ButtonSaveProduct.UseVisualStyleBackColor = false;
            this.ButtonSaveProduct.Click += new System.EventHandler(this.ButtonSaveProduct_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonCancel.Location = new System.Drawing.Point(244, 167);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(229, 34);
            this.ButtonCancel.TabIndex = 24;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // CommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(479, 212);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSaveProduct);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.comboBoxAssembly);
            this.Controls.Add(this.labelNameAssembly);
            this.Name = "CommentForm";
            this.Text = "Комментарий";
            this.Load += new System.EventHandler(this.CommentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNameAssembly;
        private System.Windows.Forms.ComboBox comboBoxAssembly;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button ButtonSaveProduct;
        private System.Windows.Forms.Button ButtonCancel;
    }
}