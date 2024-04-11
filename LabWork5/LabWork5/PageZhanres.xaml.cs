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
    /// Логика взаимодействия для PageZhanres.xaml
    /// </summary>
    public partial class PageZhanres : Page
    {
        ZhanresTableAdapter zh = new ZhanresTableAdapter();
        public PageZhanres()
        {
            InitializeComponent();
            dg_zh.ItemsSource = zh.GetData();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxDesc.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    zh.InsertZhanres(tbxName.Text, tbxDesc.Text);
                    dg_zh.ItemsSource = zh.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Повторяется название жанра");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_zh.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_zh.SelectedItem as DataRowView).Row[0];
                    zh.DeleteZhanres(Convert.ToInt32(id));
                    dg_zh.ItemsSource = zh.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Вы пытаетесь удалить связанные данные");
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_zh.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxDesc.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_zh.SelectedItem as DataRowView).Row[0];
                    zh.UpdateZhanres(tbxName.Text, tbxDesc.Text, Convert.ToInt32(id));
                    dg_zh.ItemsSource = zh.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void dg_zh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_zh.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxName.Text = row.Row["NameZhanre"].ToString();
                tbxDesc.Text = row.Row["DescriptionZhanre"].ToString();
            }
        }

        private void tbxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^а-яА-Я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
