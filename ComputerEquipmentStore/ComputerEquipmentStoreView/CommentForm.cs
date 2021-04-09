using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;

namespace ComputerEquipmentStoreView
{
    public partial class CommentForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly AssemblyLogic assemblyLogic;
        private readonly CommentLogic commentLogic;

        public int Id { set { id = value; } }
        
        private int? id;


        public CommentForm(AssemblyLogic assemblyLogic, CommentLogic commentLogic)
        {
            InitializeComponent();
            this.assemblyLogic = assemblyLogic;
            this.commentLogic = commentLogic;

            List<AssemblyViewModel> list = assemblyLogic.Read(null);
            if (list != null)
            {
                comboBoxAssembly.DisplayMember = "AssemblyName";
                comboBoxAssembly.ValueMember = "Id";
                comboBoxAssembly.DataSource = list;
                comboBoxAssembly.SelectedItem = null;
            }
        }

        private void CommentForm_Load(object sender, EventArgs e)
        {
            try
            {
                var list = assemblyLogic.Read(null);
                if (list != null)
                {
                    comboBoxAssembly.DataSource = list;
                    comboBoxAssembly.DisplayMember = "ProductName";
                    comboBoxAssembly.ValueMember = "Id";
                    comboBoxAssembly.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (id.HasValue)
            {
                try
                {
                    var list = commentLogic.Read(new CommentBindingModel
                    {
                        Id = id.Value
                    }, Program.Buyer.Id, false)?[0];
                    if (list != null)
                    {
                        comboBoxAssembly.SelectedValue = list.AssemblyId;
                        textBoxText.Text = list.Text;
                        dateTimePicker.Text = list.DateComment.ToString();


                        /*
                        var assemblylist = assemblyLogic.Read(new AssemblyBindingModel
                        {
                            Id = list.AssemblyId
                        })?[0];
                        */


                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSaveProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxText.Text))
            {
                MessageBox.Show("Заполните поле Текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAssembly.SelectedValue == null)
            {
                MessageBox.Show("Выберите сборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePicker.Value == null)
            {
                MessageBox.Show("Выберите дату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                commentLogic.CreateOrUpdate(new CommentBindingModel
                {
                    Id = id,
                    AssemblyId = Convert.ToInt32(comboBoxAssembly.SelectedValue),
                    BuyerId = Program.Buyer.Id,
                    Text = textBoxText.Text,
                    DateComment = dateTimePicker.Value
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
    }
}
