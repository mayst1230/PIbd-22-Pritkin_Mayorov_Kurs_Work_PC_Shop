using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using LiveCharts;
using LiveCharts.Wpf;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Forms;
using NLog;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для WindowChartSeller.xaml
    /// </summary>
    public partial class WindowChartSeller : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ReportLogic reportLogic;

        private readonly Logger logger;

        public WindowChartSeller(ReportLogic reportLogic)
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
                var dataSource = reportLogic.GetComponentProductAssembly(new ReportBindingModel
                {
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate,
                    SellerId = App.Seller.Id
                });

                string[] barLabels = new string[dataSource.Count];

                ChartValues<double> values = new ChartValues<double>();

                //Ключ - комплектующее, Значение количество сборок/товаров в которых он используется
                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                foreach (var date in dataSource)
                {
                    if (dictionary.ContainsKey(date.Component))
                    {
                        dictionary[date.Component] += 1;
                    } else
                    {
                        dictionary.Add(date.Component, 1);
                    }
                }

                int i = 0;
                foreach (var d in dictionary)
                {
                    barLabels[i] = d.Key;
                    values.Add(d.Value);
                    i++;
                }

                BarLabels = barLabels;

                SeriesCollection = new SeriesCollection();

                if (values != null)
                {
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Количество вхождений в сборки/товары",
                        Values = values,
                        Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0))
                    });
                }
                else
                {
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Formatter = value => value.ToString("N");
                DataContext = null;
                DataContext = this;
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка формирования диаграммы: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
