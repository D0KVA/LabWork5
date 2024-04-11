using LabWork5.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageDateC.xaml
    /// </summary>
    public partial class PageDateC : Page
    {
        DateCTableAdapter dtc = new DateCTableAdapter();
        public PageDateC()
        {
            InitializeComponent();
            dg_C.ItemsSource = dtc.GetData();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxLogin.Text) || string.IsNullOrEmpty(tbxLogin.Text))
            {
                MessageBox.Show("Заполните все поля перед добавлением");
            }
            else
            {
                try
                {
                    dtc.InsertDC(tbxLogin.Text, tbxPassword.Text);
                    dg_C.ItemsSource = dtc.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Вы пытаетесь добавить одинаковых пользователей");
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_C.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_C.SelectedItem as DataRowView).Row[0];
                    dtc.DeleteDC(Convert.ToInt32(id));
                    dg_C.ItemsSource = dtc.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Вы удаляете связанные данные");
                }
            }
            
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxLogin.Text) || string.IsNullOrEmpty(tbxLogin.Text))
            {
                MessageBox.Show("Заполните все поля перед изменением");
            }
            else if (dg_C.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else
            {
                try
                {
                    object id = (dg_C.SelectedItem as DataRowView).Row[0];
                    dtc.UpdateDC(tbxLogin.Text, tbxPassword.Text, Convert.ToInt32(id));
                    dg_C.ItemsSource = dtc.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
            
        }

        private void dg_C_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_C.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxLogin.Text = row.Row["LoginC"].ToString();
                tbxPassword.Text = row.Row["PasswordC"].ToString();
            }
        }

        private void tbxLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
                Regex regex = new Regex("[^A-Za-z0-9]+");
                e.Handled = regex.IsMatch(e.Text);
        }
    }
}
