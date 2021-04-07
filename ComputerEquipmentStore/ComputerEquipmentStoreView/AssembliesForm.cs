using System;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System.Collections.Generic;

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
                var list = assemblyLogic.Read(null, Program.Buyer.Id);
                if (list != null)
                {
                    //посмотреть еще
                    dataGridViewAssemblies.DataSource = list;
                    dataGridViewAssemblies.Columns[0].Visible = false;//ID сборки
                    dataGridViewAssemblies.Columns[1].Visible = true;//ID покупателя
                    dataGridViewAssemblies.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//Название сборки
                    dataGridViewAssemblies.Columns[3].Visible = true;//Стоимость сборки
                    dataGridViewAssemblies.Columns[4].Visible = false;//Компоненты
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

        private void ButtonLink_Click(object sender, EventArgs e)
        {
            if (dataGridViewAssemblies.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<LinkAssemblyForm>();
                int id = Convert.ToInt32(dataGridViewAssemblies.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.AssemblyName = (string) dataGridViewAssemblies.SelectedRows[0].Cells[2].Value;
                
                
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
