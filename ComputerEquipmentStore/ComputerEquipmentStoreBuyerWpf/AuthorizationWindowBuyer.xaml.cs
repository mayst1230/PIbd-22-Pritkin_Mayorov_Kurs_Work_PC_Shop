﻿using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using System.Windows;
using System.Windows.Forms;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindowBuyer.xaml
    /// </summary>
    public partial class AuthorizationWindowBuyer : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly BuyerLogic buyerLogic;

        public AuthorizationWindowBuyer(BuyerLogic buyerLogic)
        {
            InitializeComponent();
            this.buyerLogic = buyerLogic;
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Введите почту", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var buyer = buyerLogic.Read(new BuyerBindingModel
            {
                Login = textBoxEmail.Text,
                Password = passwordBox.Password
            });

            if (buyer != null && buyer.Count > 0)
            {
                var curUser = buyer[0];
                App.Buyer = curUser;
                var MainWindow = Container.Resolve<MainWindow>();
                MainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверно введен пароль или логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<RegistrationWindowBuyer>();
            form.ShowDialog();
        }
    }
}