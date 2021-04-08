using System;
using System.Windows.Forms;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using System.Collections.Generic;
using Unity;

namespace ComputerEquipmentStoreView
{
    public partial class AssemblyForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly AssemblyLogic assemblyLogic;

        private int? id;

        public int Id { set { id = value; } }

        private Dictionary<int, (string, int, decimal)> assemblyComponents;

        public AssemblyForm(AssemblyLogic assemblyLogic)
        {
            InitializeComponent();
            this.assemblyLogic = assemblyLogic;
        }

        private void ButtonSaveAssembly_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameAssembly.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                assemblyLogic.CreateOrUpdate(new AssemblyBindingModel
                {
                    Id = id,
                    AssemblyName = textBoxNameAssembly.Text,
                    Cost = 0,
                    Components = assemblyComponents,
                    BuyerId = Program.Buyer.Id
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AssemblyForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = assemblyLogic.Read(
                        new AssemblyBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxNameAssembly.Text = view.AssemblyName;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
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
                    /*
                    dataGridViewComponents.Rows.Clear();
                    foreach (var pc in assemblyComponents)
                    {
                        dataGridViewComponents.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2, pc.Value.Item3 });
                    
                    */
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
