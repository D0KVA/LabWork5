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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        List<string> data = new List<string> { "Жанры игр", "Игры" };
        public ClientWindow()
        {
            InitializeComponent();
            cbxRab.ItemsSource = data;
        }

        private void Comeback_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            Close();
        }

        private void cbxCl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string data = cbxRab.SelectedItem.ToString();

            if (data == "Жанры игр")
            {
                PageFrameRab.Content = new ClientZhanres();
            }
            else if (data == "Игры")
            {
                PageFrameRab.Content = new ClientGames();
            }
        }
    }
}
