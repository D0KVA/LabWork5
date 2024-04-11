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
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        ClientsTableAdapter cl = new ClientsTableAdapter();
        DateCTableAdapter dc = new DateCTableAdapter();
        public PageClients()
        {
            InitializeComponent();
            dg_cl.ItemsSource = cl.GetData();
            cbxdrID.ItemsSource = dc.GetData();
            cbxdrID.DisplayMemberPath = "ID_DateC";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSurname.Text) || string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxMiddleName.Text) || string.IsNullOrEmpty(tbxdID.Text) || string.IsNullOrEmpty(cbxdrID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
            try
            {
                cl.InsertClients(tbxSurname.Text, tbxName.Text, tbxMiddleName.Text, tbxdID.Text, Convert.ToInt32(cbxdrID.Text));
                dg_cl.ItemsSource = cl.GetData();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка: У вас повторяется клиент");
            }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dg_cl.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_cl.SelectedItem as DataRowView).Row[0];
                    cl.DeleteClients(Convert.ToInt32(id));
                    dg_cl.ItemsSource = cl.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Вы пытаетесь удалить связанные данные");
                }
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (dg_cl.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxSurname.Text) || string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxMiddleName.Text) || string.IsNullOrEmpty(tbxdID.Text) || string.IsNullOrEmpty(cbxdrID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_cl.SelectedItem as DataRowView).Row[0];
                    cl.UpdateClients(tbxSurname.Text, tbxName.Text, tbxMiddleName.Text, tbxdID.Text, Convert.ToInt32(cbxdrID.Text), Convert.ToInt32(id));
                    dg_cl.ItemsSource = cl.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
            
        }

        private void dg_cl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_cl.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxSurname.Text = row.Row["SurnameC"].ToString();
                tbxName.Text = row.Row["NameC"].ToString();
                tbxMiddleName.Text = row.Row["MiddleNameC"].ToString();
                tbxdID.Text = row.Row["MailC"].ToString();
                cbxdrID.Text = row.Row["DateC_ID"].ToString();
            }
        }

        private void tbxSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxMiddleName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
