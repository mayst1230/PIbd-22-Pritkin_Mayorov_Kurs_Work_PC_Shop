using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindowBuyer.xaml
    /// </summary>
    public partial class RegistrationWindowBuyer : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly BuyerLogic buyerLogic;

        public RegistrationWindowBuyer(BuyerLogic buyerLogic)
        {
            InitializeComponent();
            this.buyerLogic = buyerLogic;
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните поле \"Почта\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Почта введена некорректно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Заполните поле \"пароль\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(passwordBoxRepeat.Password))
            {
                MessageBox.Show("Заполните поле \"Повторите пароль\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (passwordBox.Password != passwordBoxRepeat.Password)
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
                        Login = textBoxEmail.Text,
                        Password = passwordBox.Password
                    });
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
