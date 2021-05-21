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
using System.Collections.Generic;

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

        /// <summary>
        /// График количества комплектующих в определенную дату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                SeriesCollection = new SeriesCollection();

                var dataSource = reportLogic.GetInfoAboutPurchases(new ReportBindingModelBuyer
                {
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate,
                    BuyerId = App.Buyer.Id
                });

                //Заполняем нижние отметки дат
                string[] barLabels = new string[dataSource.Count];

                //Ключ - комплектующее, Значение количество сборок/товаров в которых он используется
                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                foreach (var purchaseDate in dataSource)
                {
                    int count = 0;

                    foreach (var component in purchaseDate.Components)
                    {
                        count += component.Item2;
                    }

                    if (dictionary.ContainsKey(purchaseDate.DatePurchase.ToShortDateString()))
                    {
                        dictionary[purchaseDate.DatePurchase.ToShortDateString()] += count;
                    }
                    else
                    {
                        dictionary.Add(purchaseDate.DatePurchase.ToShortDateString(), count);
                    }
                }

                ChartValues<double> values = new ChartValues<double>();

                int i = 0;
                foreach (var d in dictionary)
                {
                    barLabels[i] = d.Key;
                    values.Add(d.Value);
                    i++;
                }

                BarLabels = barLabels;

                if (values != null)
                {
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Количество комплектующих",
                        Values = values,
                        Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0)),
                        Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 0))
                    });
                }

                Formatter = value => value.ToString("N");

                DataContext = null;

                DataContext = this;
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка формирования диаграммы" + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateSecondChartBuyer_Click(object sender, RoutedEventArgs e)
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
                SeriesCollection = new SeriesCollection();

                var dataSource = reportLogic.GetInfoAboutPurchases(new ReportBindingModelBuyer
                {
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate,
                    BuyerId = App.Buyer.Id
                });

                //Заполняем нижние отметки дат
                string[] barLabels = new string[dataSource.Count];

                //Ключ - покупка, Значение количество комплектующих
                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                foreach (var purchaseDate in dataSource)
                {
                    int count = 0;

                    foreach (var component in purchaseDate.Components)
                    {
                        count += component.Item2;
                    }

                    if (dictionary.ContainsKey(purchaseDate.PurchaseName))
                    {
                        dictionary[purchaseDate.PurchaseName] += count;
                    }
                    else
                    {
                        dictionary.Add(purchaseDate.PurchaseName, count);
                    }
                }

                ChartValues<double> values = new ChartValues<double>();

                int i = 0;
                foreach (var d in dictionary)
                {
                    barLabels[i] = d.Key;
                    values.Add(d.Value);
                    i++;
                }

                BarLabels = barLabels;

                if (values != null)
                {
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Количество комплектующих",
                        Values = values,
                        Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0)),
                    });
                }

                Formatter = value => value.ToString("N");
                DataContext = null;
                DataContext = this;
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка формирования диаграммы" + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  
    }
}
