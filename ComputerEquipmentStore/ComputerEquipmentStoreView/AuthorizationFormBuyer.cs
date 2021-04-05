using System;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;

namespace ComputerEquipmentStoreView
{
    public partial class AuthorizationFormBuyer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly BuyerLogic buyerLogic;


        public AuthorizationFormBuyer(BuyerLogic buyerLogic)
        {
            InitializeComponent();
            this.buyerLogic = buyerLogic;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку авторизации (входа)
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> Данные о событии
        private void ButtonAuthorization_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var buyer = buyerLogic.Read(new BuyerBindingModel
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text
            });

            if (buyer != null && buyer.Count > 0)
            {
                var currentBuyer = buyer[0];
                Program.Buyer = currentBuyer;
                var MainFormBuyer = Container.Resolve<MainFormBuyer>();
                MainFormBuyer.Show();
            }
            else
            {
                MessageBox.Show("Неверно введен пароль или логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var RegistrationFormBuyer = Container.Resolve<RegistrationFormBuyer>();
            RegistrationFormBuyer.Show();
        }
    }
}
