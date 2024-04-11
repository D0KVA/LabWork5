using LabWork5.DataSet1TableAdapters;
using Microsoft.Win32;
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
using System.IO;

namespace LabWork5
{
    /// <summary>
    /// Логика взаимодействия для PageCheques.xaml
    /// </summary>
    public partial class PageCheques : Page
    {
        ChequesTableAdapter ch = new ChequesTableAdapter();
        public PageCheques()
        {
            InitializeComponent();
            dg_Cheq.ItemsSource = ch.GetData();
            tbxDateCheq.DisplayDateStart = DateTime.Today;
            tbxDateCheq.DisplayDateEnd = DateTime.Today.AddDays(31);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPriceCheq.Text) || string.IsNullOrEmpty(tbxDateCheq.Text))
            {
                MessageBox.Show("Заполните все поля перед добавлением");
            }
            else
            {
            try
            {
                ch.InsertCheq(Convert.ToDecimal(tbxPriceCheq.Text), tbxDateCheq.Text);
                dg_Cheq.ItemsSource = ch.GetData();
            }
            catch 
            {

            }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Cheq.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_Cheq.SelectedItem as DataRowView).Row[0];
                    ch.DeleteCheq(Convert.ToInt32(id));
                    dg_Cheq.ItemsSource = ch.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Пытаетесь удалить связанные данные");
                }
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Cheq.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxPriceCheq.Text) || string.IsNullOrEmpty(tbxDateCheq.Text))
            {
                MessageBox.Show("Заполните все поля перед добавлением");
            }
            else
            {
                try
                {
                    object id = (dg_Cheq.SelectedItem as DataRowView).Row[0];
                    ch.UpdateCheq(Convert.ToDecimal(tbxPriceCheq.Text), tbxDateCheq.Text, Convert.ToInt32(id));
                    dg_Cheq.ItemsSource = ch.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
            
        }

        private void dg_Cheq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_Cheq.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxPriceCheq.Text = row.Row["PriceCheq"].ToString();
                tbxDateCheq.Text = row.Row["DateCheq"].ToString();
            }
        }

        private void tbxPriceCheq_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ExportToCsv(DataGrid dg_Cheq, string filePath)
        {
            StringBuilder csv = new StringBuilder();

            // Заголовки столбцов
            foreach (var column in dg_Cheq.Columns)
            {
                csv.Append(column.Header);
                csv.Append(",");
            }
            csv.AppendLine();

            // Данные строк
            foreach (var item in dg_Cheq.Items)
            {
                var row = item as DataRowView;
                foreach (var column in dg_Cheq.Columns)
                {
                    var cellValue = row[column.Header.ToString()].ToString();
                    csv.Append(cellValue);
                    csv.Append(",");
                }
                csv.AppendLine();
            }
            File.WriteAllText(filePath, csv.ToString());
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                    ExportToCsv(dg_Cheq, filePath);
            }
        }
    }
}
