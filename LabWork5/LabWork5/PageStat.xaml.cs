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
using System.Xml.Linq;

namespace LabWork5
{
    /// <summary>
    /// Логика взаимодействия для PageStat.xaml
    /// </summary>
    public partial class PageStat : Page
    {
        StatTableAdapter dtr = new StatTableAdapter();
        public PageStat()
        {
            InitializeComponent();
            dg_Stat.ItemsSource = dtr.GetData();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxStat.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    dtr.InsertSt(tbxStat.Text);
                    dg_Stat.ItemsSource = dtr.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: У вас повторяется статус");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Stat.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_Stat.SelectedItem as DataRowView).Row[0];
                    dtr.DeleteSt(Convert.ToInt32(id));
                    dg_Stat.ItemsSource = dtr.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Вы пытаетесь удалить связанные данные");
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Stat.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxStat.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_Stat.SelectedItem as DataRowView).Row[0];
                    dtr.UpdateSt(tbxStat.Text, Convert.ToInt32(id));
                    dg_Stat.ItemsSource = dtr.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }
        private void dg_Stat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_Stat.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxStat.Text = row.Row["NameStatus"].ToString();
            }
        }

        private void ImportD_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                List<ClassStat> forImport = LabaConvertor.DeserializeObject<List<ClassStat>>();
                if (forImport != null)
                {
                    foreach (var item in forImport)
                    {
                        dtr.InsertSt(item.NameStat);
                    }
                    dg_Stat.ItemsSource = null;
                    dg_Stat.ItemsSource = dtr.GetData();
                }
                else if (forImport == null)
                {
                    MessageBox.Show("Вы не выбрали файл((((");
                }
            }
            catch
            {
                MessageBox.Show("Вы выбрали не тот файл");
            }

        }

        private void tbxStat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
