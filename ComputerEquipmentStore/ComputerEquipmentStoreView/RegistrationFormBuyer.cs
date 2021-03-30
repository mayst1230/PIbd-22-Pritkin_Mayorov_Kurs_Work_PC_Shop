using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerEquipmentStoreView
{
    public partial class RegistrationFormBuyer : Form
    {
        public RegistrationFormBuyer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> Данные о событии
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == textBoxRepeatPassword.Text)
            {
                MessageBox.Show("Поздравляю! Вы зарегестрировались как " + textBoxLogin.Text + "!");
                Close();
            }
            else
            {
                MessageBox.Show("Поздравляю! Вы ошиблись с паролями. Сделайте их одинаковыми!");
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
