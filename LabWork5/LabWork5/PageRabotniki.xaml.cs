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
    /// Логика взаимодействия для PageRabotniki.xaml
    /// </summary>
    public partial class PageRabotniki : Page
    {
        RabotnikiTableAdapter rb = new RabotnikiTableAdapter();
        DolznostiTableAdapter dz = new DolznostiTableAdapter();
        DataRabTableAdapter dr = new DataRabTableAdapter();
        public PageRabotniki()
        {
            InitializeComponent();
            dg_rb.ItemsSource = rb.GetData();
            cbxdID.ItemsSource = dz.GetData();
            cbxdrID.ItemsSource = dr.GetData();
            cbxdID.DisplayMemberPath = "ID_Dolznosti";
            cbxdrID.DisplayMemberPath = "ID_DataRab";
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSurname.Text) || string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxMiddleName.Text) || string.IsNullOrEmpty(cbxdrID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    rb.InsertRab(tbxSurname.Text, tbxName.Text, tbxMiddleName.Text, Convert.ToInt32(cbxdID.Text), Convert.ToInt32(cbxdrID.Text));
                    dg_rb.ItemsSource = rb.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_rb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_rb.SelectedItem as DataRowView).Row[0];
                    rb.DeleteRab(Convert.ToInt32(id));
                    dg_rb.ItemsSource = rb.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_rb.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxSurname.Text) || string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxMiddleName.Text) || string.IsNullOrEmpty(cbxdrID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_rb.SelectedItem as DataRowView).Row[0];
                    rb.UpdateRab(tbxSurname.Text, tbxName.Text, tbxMiddleName.Text, Convert.ToInt32(cbxdID.Text), Convert.ToInt32(cbxdrID.Text), Convert.ToInt32(id));
                    dg_rb.ItemsSource = rb.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
                
        }

        private void dg_rb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_rb.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxSurname.Text = row.Row["SurnameRab"].ToString();
                tbxName.Text = row.Row["NameRab"].ToString();
                tbxMiddleName.Text = row.Row["MiddleNameRab"].ToString();
                cbxdID.Text = row.Row["Dolznosti_ID"].ToString();
                cbxdrID.Text = row.Row["DataRab_ID"].ToString();
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
