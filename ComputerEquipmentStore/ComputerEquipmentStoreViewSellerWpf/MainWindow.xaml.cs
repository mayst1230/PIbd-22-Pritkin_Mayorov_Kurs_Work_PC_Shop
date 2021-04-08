using System.Windows;
using Unity;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonComponents_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ComponentsWindow>();
            form.ShowDialog();
        }

        private void buttonProducts_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ProductsWindow>();
            form.ShowDialog();
        }

        private void buttonOrders_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<OrderWindow>();
            form.ShowDialog();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<AuthorizationWindow>();
            form.ShowDialog();
            Hide();
        }
    }
}
