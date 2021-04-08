
namespace ComputerEquipmentStoreView
{
    partial class ListPurchaseComponentForm
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
            this.buttonToExcel = new System.Windows.Forms.Button();
            this.buttonToWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonToExcel
            // 
            this.buttonToExcel.Location = new System.Drawing.Point(12, 12);
            this.buttonToExcel.Name = "buttonToExcel";
            this.buttonToExcel.Size = new System.Drawing.Size(157, 62);
            this.buttonToExcel.TabIndex = 0;
            this.buttonToExcel.Text = "Вывести список в Excel";
            this.buttonToExcel.UseVisualStyleBackColor = true;
            this.buttonToExcel.Click += new System.EventHandler(this.buttonToExcel_Click);
            // 
            // buttonToWord
            // 
            this.buttonToWord.Location = new System.Drawing.Point(631, 12);
            this.buttonToWord.Name = "buttonToWord";
            this.buttonToWord.Size = new System.Drawing.Size(157, 62);
            this.buttonToWord.TabIndex = 1;
            this.buttonToWord.Text = "Вывести список в Word";
            this.buttonToWord.UseVisualStyleBackColor = true;
            this.buttonToWord.Click += new System.EventHandler(this.buttonToWord_Click);
            // 
            // ListPurchaseComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonToWord);
            this.Controls.Add(this.buttonToExcel);
            this.Name = "ListPurchaseComponentForm";
            this.Text = "Получить список комплектующих по покупкам";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonToExcel;
        private System.Windows.Forms.Button buttonToWord;
    }
}