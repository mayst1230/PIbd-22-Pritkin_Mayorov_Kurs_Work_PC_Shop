
using System.Windows.Forms;

namespace ComputerEquipmentStoreView
{
    partial class RegistrationFormBuyer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationFormBuyer));
            this.labelRegistration = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelRepeatPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxRepeatPassword = new System.Windows.Forms.TextBox();
            this.ButtonRegister = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRegistration
            // 
            this.labelRegistration.AutoSize = true;
            this.labelRegistration.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F);
            this.labelRegistration.ForeColor = System.Drawing.Color.White;
            this.labelRegistration.Location = new System.Drawing.Point(179, 6);
            this.labelRegistration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegistration.Name = "labelRegistration";
            this.labelRegistration.Size = new System.Drawing.Size(252, 45);
            this.labelRegistration.TabIndex = 0;
            this.labelRegistration.Text = "Регистрация";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(8, 48);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(74, 26);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Location = new System.Drawing.Point(8, 96);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(86, 26);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Пароль";
            // 
            // labelRepeatPassword
            // 
            this.labelRepeatPassword.AutoSize = true;
            this.labelRepeatPassword.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.labelRepeatPassword.ForeColor = System.Drawing.Color.White;
            this.labelRepeatPassword.Location = new System.Drawing.Point(8, 142);
            this.labelRepeatPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRepeatPassword.Name = "labelRepeatPassword";
            this.labelRepeatPassword.Size = new System.Drawing.Size(199, 26);
            this.labelRepeatPassword.TabIndex = 3;
            this.labelRepeatPassword.Text = "Повторите пароль";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(8, 67);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(231, 20);
            this.textBoxLogin.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(8, 114);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(231, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // textBoxRepeatPassword
            // 
            this.textBoxRepeatPassword.Location = new System.Drawing.Point(8, 161);
            this.textBoxRepeatPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            this.textBoxRepeatPassword.Size = new System.Drawing.Size(231, 20);
            this.textBoxRepeatPassword.TabIndex = 6;
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.BackColor = System.Drawing.Color.Purple;
            this.ButtonRegister.FlatAppearance.BorderSize = 0;
            this.ButtonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonRegister.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.ButtonRegister.ForeColor = System.Drawing.Color.White;
            this.ButtonRegister.Location = new System.Drawing.Point(11, 203);
            this.ButtonRegister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(228, 43);
            this.ButtonRegister.TabIndex = 7;
            this.ButtonRegister.Text = "Зарегестрироваться";
            this.ButtonRegister.UseVisualStyleBackColor = false;
            this.ButtonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ButtonCancel.FlatAppearance.BorderSize = 0;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.ButtonCancel.ForeColor = System.Drawing.Color.White;
            this.ButtonCancel.Location = new System.Drawing.Point(265, 212);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(98, 34);
            this.ButtonCancel.TabIndex = 8;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(328, 58);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(154, 150);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 9;
            this.pictureBoxLogo.TabStop = false;
            // 
            // RegistrationFormBuyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(533, 280);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonRegister);
            this.Controls.Add(this.textBoxRepeatPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelRepeatPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelRegistration);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegistrationFormBuyer";
            this.Text = "Форма регистрации покупателя";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegistration;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelRepeatPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxRepeatPassword;
        private System.Windows.Forms.Button ButtonRegister;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}