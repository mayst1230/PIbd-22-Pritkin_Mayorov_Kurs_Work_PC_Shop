
namespace ComputerEquipmentStoreView
{
    partial class AuthorizationFormBuyer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationFormBuyer));
            this.labelAuthorization = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.ButtonAuthorization = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.labelRegistration = new System.Windows.Forms.Label();
            this.ButtonRegistration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAuthorization
            // 
            this.labelAuthorization.AutoSize = true;
            this.labelAuthorization.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F);
            this.labelAuthorization.ForeColor = System.Drawing.Color.White;
            this.labelAuthorization.Location = new System.Drawing.Point(324, 9);
            this.labelAuthorization.Name = "labelAuthorization";
            this.labelAuthorization.Size = new System.Drawing.Size(110, 45);
            this.labelAuthorization.TabIndex = 1;
            this.labelAuthorization.Text = "Вход";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(12, 113);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(74, 26);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Location = new System.Drawing.Point(7, 192);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(86, 26);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Пароль";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(12, 142);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(344, 26);
            this.textBoxLogin.TabIndex = 5;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 221);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(344, 26);
            this.textBoxPassword.TabIndex = 6;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(499, 104);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(231, 231);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 10;
            this.pictureBoxLogo.TabStop = false;
            // 
            // ButtonAuthorization
            // 
            this.ButtonAuthorization.BackColor = System.Drawing.Color.Purple;
            this.ButtonAuthorization.FlatAppearance.BorderSize = 0;
            this.ButtonAuthorization.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonAuthorization.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.ButtonAuthorization.ForeColor = System.Drawing.Color.White;
            this.ButtonAuthorization.Location = new System.Drawing.Point(12, 274);
            this.ButtonAuthorization.Name = "ButtonAuthorization";
            this.ButtonAuthorization.Size = new System.Drawing.Size(248, 39);
            this.ButtonAuthorization.TabIndex = 11;
            this.ButtonAuthorization.Text = "Войти";
            this.ButtonAuthorization.UseVisualStyleBackColor = false;
            this.ButtonAuthorization.Click += new System.EventHandler(this.ButtonAuthorization_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ButtonCancel.FlatAppearance.BorderSize = 0;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.ButtonCancel.ForeColor = System.Drawing.Color.White;
            this.ButtonCancel.Location = new System.Drawing.Point(281, 274);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(105, 39);
            this.ButtonCancel.TabIndex = 12;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelRegistration
            // 
            this.labelRegistration.AutoSize = true;
            this.labelRegistration.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRegistration.ForeColor = System.Drawing.Color.White;
            this.labelRegistration.Location = new System.Drawing.Point(19, 355);
            this.labelRegistration.Name = "labelRegistration";
            this.labelRegistration.Size = new System.Drawing.Size(301, 26);
            this.labelRegistration.TabIndex = 13;
            this.labelRegistration.Text = "Ещё не зарегстрировались?";
            // 
            // ButtonRegistration
            // 
            this.ButtonRegistration.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ButtonRegistration.FlatAppearance.BorderSize = 0;
            this.ButtonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRegistration.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonRegistration.ForeColor = System.Drawing.Color.White;
            this.ButtonRegistration.Location = new System.Drawing.Point(326, 349);
            this.ButtonRegistration.Name = "ButtonRegistration";
            this.ButtonRegistration.Size = new System.Drawing.Size(272, 39);
            this.ButtonRegistration.TabIndex = 14;
            this.ButtonRegistration.Text = "Зарегистрируйтесь";
            this.ButtonRegistration.UseVisualStyleBackColor = false;
            this.ButtonRegistration.Click += new System.EventHandler(this.ButtonRegistration_Click);
            // 
            // AuthorizationFormBuyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 418);
            this.Controls.Add(this.ButtonRegistration);
            this.Controls.Add(this.labelRegistration);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonAuthorization);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelAuthorization);
            this.Name = "AuthorizationFormBuyer";
            this.Text = "AuthorizationFormBuyer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAuthorization;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button ButtonAuthorization;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label labelRegistration;
        private System.Windows.Forms.Button ButtonRegistration;
    }
}