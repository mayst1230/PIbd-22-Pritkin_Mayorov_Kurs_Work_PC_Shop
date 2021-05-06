using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;
using NLog;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly SellerLogic logic;
        private readonly Logger logger;
        public AuthorizationWindow(SellerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(textBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Почта введена некорректно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

            var seller = logic.Read(new SellerBindingModel
            {
                Login = textBoxEmail.Text,
                Password = passwordBox.Password
            });

            if (seller != null && seller.Count > 0)
            {
                var curUser = seller[0];
                App.Seller = curUser;
                var MainWindow = Container.Resolve<MainWindow>();
                MainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверно введен пароль или логин", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<RegistrationWindow>();
            form.ShowDialog();
        }
    }
}
