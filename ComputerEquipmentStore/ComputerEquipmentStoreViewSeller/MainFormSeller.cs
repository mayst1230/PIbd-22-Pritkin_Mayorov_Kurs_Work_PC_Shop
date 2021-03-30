using Unity;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class MainFormSeller : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public MainFormSeller()
        {
            InitializeComponent();
        }

        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ComponentsForm>();
            form.ShowDialog();
        }
    }
}
