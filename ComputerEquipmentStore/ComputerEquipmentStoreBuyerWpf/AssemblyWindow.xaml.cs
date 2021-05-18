using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using NLog;

namespace ComputerEquipmentStoreBuyerWpf
{

    public class GridAssemblyComponent
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для AssemblyWindow.xaml
    /// </summary>
    public partial class AssemblyWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private int? id;

        public int Id { set { id = value; } }

        private readonly AssemblyLogic assemblyLogic;

        private readonly ComponentLogic componentLogic;

        private Dictionary<int, (string, int, decimal)> assemblyComponents;

        private readonly Logger logger;

        public AssemblyWindow(AssemblyLogic assemblyLogic, ComponentLogic componentLogic)
        {
            InitializeComponent();
            this.assemblyLogic = assemblyLogic;
            this.componentLogic = componentLogic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void AssemblyWindow_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    AssemblyViewModel view = assemblyLogic.Read(new AssemblyBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxAssemblyName.Text = view.AssemblyName;
                        textBoxAllowence.Text = view.Allowance.ToString();
                        assemblyComponents = view.Components;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Ошибка загрузки данных о сборке: " + ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                assemblyComponents = new Dictionary<int, (string, int, decimal)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (assemblyComponents != null)
                {
                    dataGridComponents.Items.Clear();
                    foreach (var assemblyComponent in assemblyComponents)
                    {
                        dataGridComponents.Items.Add(new GridAssemblyComponent
                        {
                            Id = assemblyComponent.Key,
                            ComponentName = assemblyComponent.Value.Item1,
                            Count = assemblyComponent.Value.Item2,
                            Cost = assemblyComponent.Value.Item3
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных о сборке: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAssemblyName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAllowence.Text))
            {
                MessageBox.Show("Заполните наценку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                decimal priceOfComponents = 0; 
                foreach (var components in assemblyComponents)
                {
                    priceOfComponents += components.Value.Item2;
                }
                assemblyLogic.CreateOrUpdate(new AssemblyBindingModel
                {
                    Id = id,
                    AssemblyName = textBoxAssemblyName.Text,
                    Allowance = Convert.ToDecimal(textBoxAllowence.Text),
                    Cost = Convert.ToDecimal(textBoxAllowence.Text) + priceOfComponents,
                    Components = assemblyComponents,
                    BuyerId = App.Buyer.Id
                });
                logger.Info("Сохранение сборки прошло успешно");
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка сохранения сборки: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}
