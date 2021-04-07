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

namespace ComputerEquipmentStoreView
{
    public partial class MainFormBuyer : Form

    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
    
        public MainFormBuyer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку перехода к покупкам
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> данные о событии
        private void ButtonToPurchase_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<PurchasesForm>();
            form.ShowDialog();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку перехода к сборкам
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> данные о событии
        private void ButtonToAssembly_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<AssembliesForm>();
            form.ShowDialog();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку перехода к комментриям к сборкам
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> данные о событии
        private void ButtonToComment_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CommentsForm>();
            form.ShowDialog();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку получения списка
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> данные о событии
        private void ButtonGetList_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<AssembliesForm>();
            form.ShowDialog();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку получения отчета
        /// </summary>
        /// <param name="sender"></param> Элемент вызвавший событие
        /// <param name="e"></param> данные о событии
        private void ButtonGetReport_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<AssembliesForm>();
            form.ShowDialog();
        }

        private void MainBuyerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
