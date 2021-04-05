using System;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;

namespace ComputerEquipmentStoreView
{
    public partial class AssembliesForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly AssemblyLogic assemblyLogic;

        public AssembliesForm(AssemblyLogic assemblyLogic)
        {
            InitializeComponent();
            this.assemblyLogic = assemblyLogic;
        }


        private void AssembliesForm_Load(object sender, EventArgs e)
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
                    //посмотреть еще
                    dataGridViewAssemblies.DataSource = list;
                    dataGridViewAssemblies.Columns[0].Visible = false;
                    dataGridViewAssemblies.Columns[1].Visible = true;
                    dataGridViewAssemblies.Columns[2].Visible = true;
                    dataGridViewAssemblies.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<AssemblyForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAssemblies.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<AssemblyForm>();
                form.Id = Convert.ToInt32(dataGridViewAssemblies.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAssemblies.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewAssemblies.SelectedRows[0].Cells[0].Value);
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


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
