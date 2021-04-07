using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;

namespace ComputerEquipmentStoreView
{
    public partial class CommentsForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly CommentLogic commentLogic;

        public CommentsForm(CommentLogic commentLogic)
        {
            InitializeComponent();
            this.commentLogic = commentLogic;
        }



        private void CommentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            try
            {
                var list = commentLogic.Read(null, Program.Buyer.Id);
                if (list != null)
                {
                    dataGridViewComments.DataSource = list;
                    dataGridViewComments.Columns[0].Visible = false;//ID комментария
                    dataGridViewComments.Columns[1].Visible = true;//ID сборки
                    dataGridViewComments.Columns[2].Visible = true;//ID покупателя
                    dataGridViewComments.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//Текст комментария
                    dataGridViewComments.Columns[4].Visible = true;//Дата комментария
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CommentForm>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewComments.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<CommentForm>();
                int id = Convert.ToInt32(dataGridViewComments.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id =
               Convert.ToInt32(dataGridViewComments.SelectedRows[0].Cells[0].Value);
                try
                {
                    commentLogic.Delete(new CommentBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }  
    }
}
