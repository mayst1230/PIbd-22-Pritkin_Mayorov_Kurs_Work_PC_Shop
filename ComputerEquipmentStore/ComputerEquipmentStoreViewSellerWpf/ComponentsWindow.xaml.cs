using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using NLog;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для ComponentsWindow.xaml
    /// </summary>
    public partial class ComponentsWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ComponentLogic logic;
        private readonly Logger logger;

        public ComponentsWindow(ComponentLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void ComponentsWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(new ComponentBindingModel { SellerId = App.Seller.Id});
                if (list != null)
                {
                    dataGridComponents.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ComponentWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridComponents.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<ComponentWindow>();
                form.Id = ((ComponentViewModel)dataGridComponents.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridComponents.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((ComponentViewModel)dataGridComponents.SelectedItems[0]).Id;
                    try
                    {
                        logic.Delete(new ComponentBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка удаления : " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void buttonAssemblyComponent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var form = Container.Resolve<AssemblyComponentWindow>();
                int id = ((ComponentViewModel)dataGridComponents.SelectedItems[0]).Id;
                form.Id = id;
                form.ComponentName = ((ComponentViewModel)dataGridComponents.SelectedItems[0]).ComponentName;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка выбора комплектующего : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка, выберите комплектующее", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
