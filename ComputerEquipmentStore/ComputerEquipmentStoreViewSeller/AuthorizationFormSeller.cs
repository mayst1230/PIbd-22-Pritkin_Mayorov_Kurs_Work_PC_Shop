using System;
using System.Windows;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System.Text.RegularExpressions;
using Unity;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class AuthorizationFormSeller : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly SellerLogic logic;
        string password = "123";
        string login = "mayst1230@gmail.com";
        public AuthorizationFormSeller(SellerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonAuthorization_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

            var user = logic.Read(new SellerBindingModel
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text
            });

            if (user != null)
            {
                if (textBoxLogin.Text == login  && textBoxPassword.Text == password)
                {
                    if (user != null && user.Count > 0)
                    {
                        var currentSeller = user[0];
                        Program.Seller = currentSeller;
                        var MainFormSeller = Container.Resolve<MainFormSeller>();
                        MainFormSeller.Show();
                        var AuthorizationFormSeller = Container.Resolve<AuthorizationFormSeller>();
                        AuthorizationFormSeller.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введен пароль или логин", "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку отмены авторизации
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> Данные о событии
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку перехода к регистрации
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> Данные о событии
        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            var RegistrationFormSeller = Container.Resolve<RegistrationFormSeller>();
            RegistrationFormSeller.Show();
        }
    }
}
