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
    /// Логика взаимодействия для PageGames.xaml
    /// </summary>
    public partial class PageGames : Page
    {
        GamesTableAdapter g = new GamesTableAdapter();
        ZhanresTableAdapter z = new ZhanresTableAdapter();
        public PageGames()
        {
            InitializeComponent();
            dg_gm.ItemsSource = g.GetData();
            cbxZhID.ItemsSource = z.GetData();
            cbxZhID.DisplayMemberPath = "ID_Zhanre";
        }
        private void dg_gm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_gm.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxName.Text = row.Row["NameGame"].ToString();
                tbxPr.Text = row.Row["PriceGame"].ToString();
                cbxZhID.Text = row.Row["Zhanre_ID"].ToString();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxPr.Text) || string.IsNullOrEmpty(cbxZhID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    g.InsertGame(tbxName.Text, Convert.ToDecimal(tbxPr.Text), Convert.ToInt32(cbxZhID.Text));
                    dg_gm.ItemsSource = g.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_gm.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_gm.SelectedItem as DataRowView).Row[0];
                    g.DeleteGame(Convert.ToInt32(id));
                    dg_gm.ItemsSource = g.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_gm.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxPr.Text) || string.IsNullOrEmpty(cbxZhID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_gm.SelectedItem as DataRowView).Row[0];
                    g.UpdateGame(tbxName.Text, Convert.ToDecimal(tbxPr.Text), Convert.ToInt32(cbxZhID.Text), Convert.ToInt32(id));
                    dg_gm.ItemsSource = g.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
            
        }

        private void tbxPr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
