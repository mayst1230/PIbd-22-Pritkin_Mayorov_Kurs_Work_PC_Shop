using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using Unity;

namespace ComputerEquipmentStoreView
{
    public partial class RegistrationFormBuyer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        //Логика покупателя
        private readonly BuyerLogic buyerLogic;

        public RegistrationFormBuyer(BuyerLogic buyerLogic)
        {
            InitializeComponent();
            this.buyerLogic = buyerLogic;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> Данные о событии
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните поле \"Логин\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Regex.IsMatch(textBoxLogin.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Логин введен некорректно, введите логин в формате почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле \"Пароль\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxRepeatPassword.Text))
            {
                MessageBox.Show("Заполните поле \"Повторите пароль\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxPassword.Text != textBoxRepeatPassword.Text)
            {
                MessageBox.Show("Пароль в обоих полях должен быть одинаковым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    buyerLogic.CreateOrUpdate(new BuyerBindingModel
                    {
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text
                    });
                    MessageBox.Show("Сохранение покупателя прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
