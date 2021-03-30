using System;
using System.Windows;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System.Text.RegularExpressions;
using Unity;
using System.Windows.Forms;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class RegistrationFormSeller : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly SellerLogic logic;
        public RegistrationFormSeller(SellerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните поле \"Логин\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(textBoxLogin.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Логин введен некорректно, введите логин в формате почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле \"пароль\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new SellerBindingModel
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку отмены регистрации
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> Данные о событии
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
