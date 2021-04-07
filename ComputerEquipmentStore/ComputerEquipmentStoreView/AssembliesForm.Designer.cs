
namespace ComputerEquipmentStoreView
{
    partial class AssembliesForm
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
            this.dataGridViewAssemblies = new System.Windows.Forms.DataGridView();
            this.ButtonCreate = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.ButtonLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssemblies)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAssemblies
            // 
            this.dataGridViewAssemblies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssemblies.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewAssemblies.Location = new System.Drawing.Point(9, 9);
            this.dataGridViewAssemblies.Name = "dataGridViewAssemblies";
            this.dataGridViewAssemblies.RowHeadersWidth = 62;
            this.dataGridViewAssemblies.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewAssemblies.Size = new System.Drawing.Size(549, 333);
            this.dataGridViewAssemblies.TabIndex = 6;
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCreate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonCreate.Location = new System.Drawing.Point(562, 8);
            this.ButtonCreate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.Size = new System.Drawing.Size(181, 34);
            this.ButtonCreate.TabIndex = 7;
            this.ButtonCreate.Text = "Создать сборку";
            this.ButtonCreate.UseVisualStyleBackColor = false;
            this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonUpdate.Location = new System.Drawing.Point(562, 46);
            this.ButtonUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(181, 34);
            this.ButtonUpdate.TabIndex = 8;
            this.ButtonUpdate.Text = "Изменить сборку";
            this.ButtonUpdate.UseVisualStyleBackColor = false;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonDelete.Location = new System.Drawing.Point(562, 84);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(181, 34);
            this.ButtonDelete.TabIndex = 9;
            this.ButtonDelete.Text = "Удалить сборку";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefresh.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRefresh.Location = new System.Drawing.Point(562, 123);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(181, 34);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // ButtonLink
            // 
            this.ButtonLink.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLink.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonLink.Location = new System.Drawing.Point(563, 273);
            this.ButtonLink.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLink.Name = "ButtonLink";
            this.ButtonLink.Size = new System.Drawing.Size(181, 67);
            this.ButtonLink.TabIndex = 11;
            this.ButtonLink.Text = "Привязать сборку к покупке";
            this.ButtonLink.UseVisualStyleBackColor = false;
            this.ButtonLink.Click += new System.EventHandler(this.ButtonLink_Click);
            // 
            // AssembliesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(751, 351);
            this.Controls.Add(this.ButtonLink);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ButtonCreate);
            this.Controls.Add(this.dataGridViewAssemblies);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AssembliesForm";
            this.Text = "Сборки";
            this.Load += new System.EventHandler(this.AssembliesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssemblies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAssemblies;
        private System.Windows.Forms.Button ButtonCreate;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button ButtonLink;
    }
}