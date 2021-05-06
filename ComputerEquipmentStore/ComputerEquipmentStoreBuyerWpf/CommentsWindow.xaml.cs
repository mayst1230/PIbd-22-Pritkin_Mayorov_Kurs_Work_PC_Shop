using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using NLog;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для CommentsWindow.xaml
    /// </summary>
    public partial class CommentsWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly CommentLogic commentLogic;

        private readonly Logger logger;

        public CommentsWindow(CommentLogic commentLogic)
        {
            InitializeComponent();
            this.commentLogic = commentLogic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void CommentsWindows_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = commentLogic.Read(null, App.Buyer.Id, false);
                if (list != null)
                {
                    dataGridComments.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки списка комментариев: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<CommentWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridComments.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<CommentWindow>();
                form.Id = ((CommentViewModel)dataGridComments.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridComments.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((CommentViewModel)dataGridComments.SelectedItems[0]).Id;
                    try
                    {
                        commentLogic.Delete(new CommentBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка удаления комментария: " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefrash_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
