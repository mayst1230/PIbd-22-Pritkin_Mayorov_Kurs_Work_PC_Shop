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
    /// Логика взаимодействия для CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly AssemblyLogic assemblyLogic;

        private readonly CommentLogic commentLogic;

        private int? id;

        public int Id { set { id = value; } }

        private readonly Logger logger;

        public CommentWindow(AssemblyLogic assemblyLogic,CommentLogic commentLogic)
        {
            InitializeComponent();
            this.assemblyLogic = assemblyLogic;
            this.commentLogic = commentLogic;
            logger = LogManager.GetCurrentClassLogger();

            var list = assemblyLogic.Read(new AssemblyBindingModel { BuyerId = App.Buyer.Id });
            if (list != null)
            {
                comboBoxAssembly.ItemsSource = list;
            }
        }

        private void CommentWindow_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var list = commentLogic.Read(new CommentBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (list != null)
                    {
                        comboBoxAssembly.SelectedValue = list.AssemblyId;
                        textBoxText.Text = list.Text;
                        datePickerDateOfComment.SelectedDate = list.DateComment;
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Ошибка загрузки данных о комментарии: " + ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxAssembly.SelectedValue == null)
            {
                MessageBox.Show("Выберите сборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxText.Text))
            {
                MessageBox.Show("Заполните поле Текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePickerDateOfComment.SelectedDate == null)
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
                    BuyerId = App.Buyer.Id,
                    Text = textBoxText.Text,
                    DateComment = (DateTime)(datePickerDateOfComment.SelectedDate == null ? new DateTime(0, 0, 0) : datePickerDateOfComment.SelectedDate)
                });
                logger.Info("Сохранение комментария прошло успешно");
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка сохранения комментария: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
