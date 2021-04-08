using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для AssembliesWindow.xaml
    /// </summary>
    public partial class AssembliesWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly AssemblyLogic assemblyLogic;


        public AssembliesWindow(AssemblyLogic assemblyLogic)
        {
            InitializeComponent();
            this.assemblyLogic = assemblyLogic;
        }

        private void AssembliesWindow_Loaded(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = assemblyLogic.Read(null);
                if (list != null)
                {
                    dataGridAssemblies.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<AssemblyWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAssemblies.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<AssemblyWindow>();
                form.Id = ((AssemblyViewModel)dataGridAssemblies.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAssemblies.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((AssemblyViewModel)dataGridAssemblies.SelectedItems[0]).Id;
                    try
                    {
                        assemblyLogic.Delete(new AssemblyBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void buttonLink_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAssemblies.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<LinkAssemblyWindow>();
                int id = ((AssemblyViewModel)dataGridAssemblies.SelectedItems[0]).Id;
                form.Id = id;
                form.AssemblyName = (string) ((AssemblyViewModel)dataGridAssemblies.SelectedItems[0]).AssemblyName;

                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }
    }
}
