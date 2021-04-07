namespace ComputerEquipmentStoreViewSeller
{
    partial class ComponentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentsForm));
            this.buttonCreateComponent = new System.Windows.Forms.Button();
            this.buttonChangeComponent = new System.Windows.Forms.Button();
            this.buttonDeleteComponent = new System.Windows.Forms.Button();
            this.buttonUpdateComponent = new System.Windows.Forms.Button();
            this.buttonAddComponentToAssembly = new System.Windows.Forms.Button();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateComponent
            // 
            this.buttonCreateComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonCreateComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateComponent.Location = new System.Drawing.Point(476, 16);
            this.buttonCreateComponent.Name = "buttonCreateComponent";
            this.buttonCreateComponent.Size = new System.Drawing.Size(140, 26);
            this.buttonCreateComponent.TabIndex = 0;
            this.buttonCreateComponent.Text = "Создать";
            this.buttonCreateComponent.UseVisualStyleBackColor = false;
            this.buttonCreateComponent.Click += new System.EventHandler(this.ButtonAddComponent_Click);
            // 
            // buttonChangeComponent
            // 
            this.buttonChangeComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonChangeComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeComponent.Location = new System.Drawing.Point(476, 48);
            this.buttonChangeComponent.Name = "buttonChangeComponent";
            this.buttonChangeComponent.Size = new System.Drawing.Size(140, 29);
            this.buttonChangeComponent.TabIndex = 1;
            this.buttonChangeComponent.Text = "Изменить";
            this.buttonChangeComponent.UseVisualStyleBackColor = false;
            this.buttonChangeComponent.Click += new System.EventHandler(this.ButtonInsertComponent_Click);
            // 
            // buttonDeleteComponent
            // 
            this.buttonDeleteComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonDeleteComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteComponent.Location = new System.Drawing.Point(476, 83);
            this.buttonDeleteComponent.Name = "buttonDeleteComponent";
            this.buttonDeleteComponent.Size = new System.Drawing.Size(140, 25);
            this.buttonDeleteComponent.TabIndex = 2;
            this.buttonDeleteComponent.Text = "Удалить";
            this.buttonDeleteComponent.UseVisualStyleBackColor = false;
            this.buttonDeleteComponent.Click += new System.EventHandler(this.ButtonDeleteComponent_Click);
            // 
            // buttonUpdateComponent
            // 
            this.buttonUpdateComponent.BackColor = System.Drawing.Color.Brown;
            this.buttonUpdateComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateComponent.Location = new System.Drawing.Point(476, 114);
            this.buttonUpdateComponent.Name = "buttonUpdateComponent";
            this.buttonUpdateComponent.Size = new System.Drawing.Size(140, 27);
            this.buttonUpdateComponent.TabIndex = 3;
            this.buttonUpdateComponent.Text = "Обновить";
            this.buttonUpdateComponent.UseVisualStyleBackColor = false;
            this.buttonUpdateComponent.Click += new System.EventHandler(this.ButtonUpdateComponent_Click);
            // 
            // buttonAddComponentToAssembly
            // 
            this.buttonAddComponentToAssembly.BackColor = System.Drawing.Color.Brown;
            this.buttonAddComponentToAssembly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddComponentToAssembly.Location = new System.Drawing.Point(476, 411);
            this.buttonAddComponentToAssembly.Name = "buttonAddComponentToAssembly";
            this.buttonAddComponentToAssembly.Size = new System.Drawing.Size(140, 27);
            this.buttonAddComponentToAssembly.TabIndex = 4;
            this.buttonAddComponentToAssembly.Text = "Привязка к сборке";
            this.buttonAddComponentToAssembly.UseVisualStyleBackColor = false;
            this.buttonAddComponentToAssembly.Click += new System.EventHandler(this.buttonAddComponentToAssembly_Click);
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewComponents.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            this.dataGridViewComponents.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewComponents.Size = new System.Drawing.Size(448, 426);
            this.dataGridViewComponents.TabIndex = 5;
            // 
            // ComponentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.dataGridViewComponents);
            this.Controls.Add(this.buttonAddComponentToAssembly);
            this.Controls.Add(this.buttonUpdateComponent);
            this.Controls.Add(this.buttonDeleteComponent);
            this.Controls.Add(this.buttonChangeComponent);
            this.Controls.Add(this.buttonCreateComponent);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComponentsForm";
            this.Text = "Комплектующие";
            this.Load += new System.EventHandler(this.ComponentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateComponent;
        private System.Windows.Forms.Button buttonChangeComponent;
        private System.Windows.Forms.Button buttonDeleteComponent;
        private System.Windows.Forms.Button buttonUpdateComponent;
        private System.Windows.Forms.Button buttonAddComponentToAssembly;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
    }
}