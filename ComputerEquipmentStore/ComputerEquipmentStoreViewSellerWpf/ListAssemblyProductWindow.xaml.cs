using Microsoft.Win32;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для ListAssemblyProductWindow.xaml
    /// </summary>
    public partial class ListAssemblyProductWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ProductLogic logicP;
        private readonly ReportLogic logicR;

        public ListAssemblyProductWindow(ProductLogic logicP, ReportLogic logicR)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicR = logicR;
        }

        private void ListAssemblyProductWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logicP.Read(null);
                if (list != null)
                {
                    dataGridProducts.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Question);
            }
        }

        private void buttonSaveToWord_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProducts.SelectedItem == null || dataGridProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                return;
            }
            var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    var list = new List<ProductViewModel>();
                    foreach (var product in dataGridProducts.SelectedItems)
                    {
                        list.Add((ProductViewModel)product);
                    }
                    logicR.SaveProductAssembliesToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        Products = list
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void buttonSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProducts.SelectedItem == null || dataGridProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите работу", "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var list = new List<ProductViewModel>();
                    foreach (var work in dataGridProducts.SelectedItems)
                    {
                        list.Add((ProductViewModel)work);
                    }
                    logicR.SaveProductAssembliesToExcelFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        Products = list
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
        }
    }
}