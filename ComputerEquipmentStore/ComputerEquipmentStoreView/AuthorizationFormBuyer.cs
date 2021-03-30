using System;
using System.Windows.Forms;
using Unity;

namespace ComputerEquipmentStoreView
{
    public partial class AuthorizationFormBuyer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public AuthorizationFormBuyer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку авторизации (входа)
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> Данные о событии
        private void ButtonAuthorization_Click(object sender, EventArgs e)
        {
            MainBuyerForm form = new MainBuyerForm();
            form.Show();
            Hide();
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
            RegistrationFormBuyer form = new RegistrationFormBuyer();
            form.Show();
        }
    }
}
