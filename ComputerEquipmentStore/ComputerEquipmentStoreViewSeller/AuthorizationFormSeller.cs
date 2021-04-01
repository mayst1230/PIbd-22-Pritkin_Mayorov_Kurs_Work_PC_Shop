using System;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using Unity;
using System.Windows.Forms;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class AuthorizationFormSeller : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly SellerLogic logic;

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

            if (user != null && user.Count > 0)
            {
                var currentSeller = user[0];
                Program.Seller = currentSeller;
                var MainFormSeller = Container.Resolve<MainFormSeller>();
                MainFormSeller.Show();
                var AuthorizationFormSeller = Container.Resolve<AuthorizationFormSeller>();
                AuthorizationFormSeller.Close(); 
            }
            else
            {
<<<<<<< HEAD
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
=======
                MessageBox.Show("Неверно введен пароль или логин", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
>>>>>>> 28e011a374479cf7818d4b99658d289e2cad8ddb
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
