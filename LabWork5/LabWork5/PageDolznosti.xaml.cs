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
    /// Логика взаимодействия для PageDolznosti.xaml
    /// </summary>
    public partial class PageDolznosti : Page
    {
        DolznostiTableAdapter dl = new DolznostiTableAdapter();
        public PageDolznosti()
        {
            InitializeComponent();
            dg_dl.ItemsSource = dl.GetData();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxSh.Text) || string.IsNullOrEmpty(tbxZP.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    dl.InsertDolz(tbxName.Text, tbxSh.Text, Convert.ToDecimal(tbxZP.Text));
                    dg_dl.ItemsSource = dl.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_dl.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_dl.SelectedItem as DataRowView).Row[0];
                    dl.DeleteDolz(Convert.ToInt32(id));
                    dg_dl.ItemsSource = dl.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_dl.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxSh.Text) || string.IsNullOrEmpty(tbxZP.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_dl.SelectedItem as DataRowView).Row[0];
                    dl.UpdateDolz(tbxName.Text, tbxSh.Text, Convert.ToDecimal(tbxZP.Text), Convert.ToInt32(id));
                    dg_dl.ItemsSource = dl.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void dg_dl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_dl.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxName.Text = row.Row["NameDolznosti"].ToString();
                tbxSh.Text = row.Row["ScheduleWork"].ToString();
                tbxZP.Text = row.Row["ZP"].ToString();
            }
        }

        private void tbxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxSh_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9/]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxZP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
