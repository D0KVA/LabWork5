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
    /// Логика взаимодействия для PageStock.xaml
    /// </summary>
    public partial class PageStock : Page
    {
        StockTableAdapter st = new StockTableAdapter();
        public PageStock()
        {
            InitializeComponent();
            dg_St.ItemsSource = st.GetData();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxAddress.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    st.InsertStock(tbxName.Text, tbxAddress.Text);
                    dg_St.ItemsSource = st.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: У вас повторяется название склада");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_St.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_St.SelectedItem as DataRowView).Row[0];
                    st.DeleteStock(Convert.ToInt32(id));
                    dg_St.ItemsSource = st.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Вы пытаетесь удалить связанные данные");
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_St.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxAddress.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_St.SelectedItem as DataRowView).Row[0];
                    st.UpdateStock(tbxName.Text, tbxAddress.Text, Convert.ToInt32(id));
                    dg_St.ItemsSource = st.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void dg_St_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_St.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxName.Text = row.Row["NameStock"].ToString();
                tbxAddress.Text = row.Row["AddressStock"].ToString();
            }
        }

        private void tbxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-яA-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
