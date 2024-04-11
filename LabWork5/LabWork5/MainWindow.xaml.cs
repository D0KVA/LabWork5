using LabWork5.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateCTableAdapter ClientsTable = new DateCTableAdapter();
        DataRabTableAdapter RabTable = new DataRabTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var RabLogin = RabTable.GetData().Rows;

                foreach (DataRow row in RabLogin)
                {
                    if (row["LoginRab"].ToString() == LoginTbx.Text && row["PasswordRab"].ToString() == PasswordTbx.Password)
                    {
                        int? RabID = row.IsNull("ID_DataRab") ? null : (int?)row["ID_DataRab"];
                        if (RabID != null)
                        {
                            RabWindow rab = new RabWindow();
                            rab.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль");
                        }
                        return;
                    }
                }
                MessageBox.Show("Неверный логин или пароль");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ClientLogin = ClientsTable.GetData().Rows;

                foreach (DataRow row in ClientLogin)
                {
                    if (row["LoginC"].ToString() == LoginTbx.Text && row["PasswordC"].ToString() == PasswordTbx.Password)
                    {
                        int? ClientID = row.IsNull("ID_DateC") ? null : (int?)row["ID_DateC"];
                        if (ClientID != null)
                        {
                            ClientWindow client = new ClientWindow();
                            client.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль");
                        }
                        return;
                    }
                }
                MessageBox.Show("Неверный логин или пароль");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
