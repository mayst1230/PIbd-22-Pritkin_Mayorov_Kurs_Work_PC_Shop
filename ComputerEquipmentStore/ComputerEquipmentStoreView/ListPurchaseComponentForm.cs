using System;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;

namespace ComputerEquipmentStoreView
{
    public partial class ListPurchaseComponentForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogicBuyer reportLogic;

        public ListPurchaseComponentForm(ReportLogicBuyer reportLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
        }

        private void buttonToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        reportLogic.SavePurchaseComponentToExcelFile(new ReportBindingModelBuyer
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonToWord_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SavePurchaseComponentToWordFile(new ReportBindingModelBuyer
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }
    }
}
