using System.Windows;
using Unity;

namespace ComputerEquipmentStoreBuyerWpf
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

        private void buttonPurchases_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<PurchasesWindow>();
            form.ShowDialog();
        }

        private void buttonAssemblies_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<AssembliesWindow>();
            form.ShowDialog();
        }

        private void buttonComments_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<CommentsWindow>();
            form.ShowDialog();
        }

        private void buttonGetList_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ListPurchaseComponentWindow>();
            form.ShowDialog();
        }

        private void buttonGetReport_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ReportPurchaseComponentCommentWindow>();
            form.ShowDialog();
        }
    }
}
