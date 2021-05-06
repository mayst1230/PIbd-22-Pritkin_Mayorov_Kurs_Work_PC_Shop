using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System;
using System.Windows.Forms;

namespace ComputerEquipmentStoreViewSeller
{    
    public partial class ComponentsForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ComponentLogic logic;
        public ComponentsForm(ComponentLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ComponentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewComponents.DataSource = list;
                    dataGridViewComponents.Columns[0].Visible = false;
                    dataGridViewComponents.Columns[1].Visible = true;
                    dataGridViewComponents.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAddComponent_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ComponentForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonInsertComponent_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<ComponentForm>();
                form.Id = Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDeleteComponent_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new ComponentBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonUpdateComponent_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAddComponentToAssembly_Click(object sender, EventArgs e)
        {            
                var form = Container.Resolve<LinkComponentForm>();
                int id = Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.ComponentName = dataGridViewComponents.SelectedRows[0].Cells[2].Value.ToString();
                form.ShowDialog();            
        }
    }
}