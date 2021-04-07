using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class AssemblyComponentForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ComponentLogic logicC;
        private readonly AssemblyLogic logicA;
        private AssemblyViewModel assemblyView;
        private Dictionary<int, (string, int)> currentAssemblyComponent;

        public AssemblyComponentForm(ComponentLogic logicC, AssemblyLogic logicA)
        {
            InitializeComponent();
            this.logicC = logicC;
            this.logicA = logicA;

           
        }

        private void AssemblyComponentForm_Load(object sender, EventArgs e)
        {
            try
            {
                var listAssemblies = logicA.Read(null);
                if (listAssemblies != null)
                {
                    comboBoxAssembly.DataSource = listAssemblies;
                    comboBoxAssembly.DisplayMember = "AssemblyName";
                    comboBoxAssembly.ValueMember = "Id";
                    comboBoxAssembly.SelectedItem = null;
                }

       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAssembly.SelectedValue == null)
            {
                MessageBox.Show("Выберите сборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logicA.CreateOrUpdate(new AssemblyBindingModel
                {
                    Id = assemblyView.Id,
                    AssemblyName = assemblyView.AssemblyName,
                    BuyerId = assemblyView.BuyerId,
                    Components = currentAssemblyComponent
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
