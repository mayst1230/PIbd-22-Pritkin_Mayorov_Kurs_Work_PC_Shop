using System;
using System.Windows.Forms;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
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
                    Cost = 0,//Создается просто сборка компоненты добавляются потом
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
                        new AssemblyBindingModel { Id = id },
                        Program.Buyer.Id,
                        false)?[0];
                    if (view != null)
                    {
                        textBoxNameAssembly.Text = view.AssemblyName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
