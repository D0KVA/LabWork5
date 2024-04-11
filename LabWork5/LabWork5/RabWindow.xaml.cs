using LabWork5.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LabWork5
{
    /// <summary>
    /// Логика взаимодействия для RabWindow.xaml
    /// </summary>
    public partial class RabWindow : Window
    {
        QueriesTableAdapter backups = new QueriesTableAdapter();
        List<string> data = new List<string> { "Данные для входа рабочих", "Данные для входа клиентов", "Должности", "Работники", "Клиенты", "Чеки", "Жанры", "Игры", "Склады", "Магазины", "Связь игр, складов и магазинов", "Статусы заказов", "Заказы" };

        public RabWindow()
        {
            InitializeComponent();
            cbxRab.ItemsSource = data;
        }
        private void cbxRab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string data = cbxRab.SelectedItem.ToString();

            if (data == "Данные для входа рабочих")
            {
                PageFrameRab.Content = new PageDataRab();
            }
            else if (data == "Данные для входа клиентов")
            {
                PageFrameRab.Content = new PageDateC();
            }
            else if (data == "Должности")
            {
                PageFrameRab.Content = new PageDolznosti();
            }
            else if (data == "Работники")
            {
                PageFrameRab.Content = new PageRabotniki();
            }
            else if (data == "Чеки")
            {
                PageFrameRab.Content = new PageCheques();
            }
            else if (data == "Жанры")
            {
                PageFrameRab.Content = new PageZhanres();
            }
            else if (data == "Игры")
            {
                PageFrameRab.Content = new PageGames();
            }
            else if (data == "Склады")
            {
                PageFrameRab.Content = new PageStock();
            }
            else if (data == "Магазины")
            {
                PageFrameRab.Content = new PageShop();
            }
            else if (data == "Связь игр, складов и магазинов")
            {
                PageFrameRab.Content = new PageSootGS();
            }
            else if (data == "Статусы заказов")
            {
                PageFrameRab.Content = new PageStat();
            }
            else if (data == "Заказы")
            {
                PageFrameRab.Content = new PageOrders();
            }
            else if (data == "Клиенты")
            {
                PageFrameRab.Content = new PageClients();
            }
        }

        private void Backupik_Click(object sender, RoutedEventArgs e)
        {
            backups.Backup_Delat();
            MessageBox.Show("Вы сделали бэкап");
        }

        private void Comeback_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            Close();
        }
    }
}
