using System;
using System.Windows;
using System.Windows.Media;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using LiveCharts;
using LiveCharts.Wpf;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Forms;
using NLog;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для WindowChart.xaml
    /// </summary>
    public partial class WindowChart : Window
    {

        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ReportLogicBuyer reportLogic;

        private readonly Logger logger;

        public WindowChart(ReportLogicBuyer reportLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
            logger = LogManager.GetCurrentClassLogger();
        }


        private void buttonCreateChart_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerFrom.SelectedDate == null || DatePickerTo.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DatePickerFrom.SelectedDate >= DatePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = reportLogic.GetInfoAboutPurchases(new ReportBindingModelBuyer
                {
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate,
                    BuyerId = App.Buyer.Id
                });

                //Заполняем нижние отметки дат
                string[] barLabels = new string[dataSource.Count];
                int i = 0;

                ChartValues<double> values = new ChartValues<double>();

                foreach (var purchaseDate in dataSource)
                {
                    barLabels[i] = purchaseDate.DatePurchase.ToShortDateString();
                    i++;

                    int count = 0;

                    foreach (var component in purchaseDate.Components)
                    {
                        count += component.Item2;
                    }

                    values.Add(count);
                }

                BarLabels = barLabels;
                SeriesCollection = new SeriesCollection();         

                if (values != null)
                {
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Количество компонентов",
                        Values = values,
                        Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0))
                    });
                }

                Formatter = value => value.ToString("N");
                DataContext = this;
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка вывода отчета в PDF на форму: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
