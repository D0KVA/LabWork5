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
    /// Логика взаимодействия для PageDataRab.xaml
    /// </summary>
    public partial class PageDataRab : Page
    {
        DataRabTableAdapter dtr = new DataRabTableAdapter();
        public PageDataRab()
        {
            InitializeComponent();
            dg_Rab.ItemsSource = dtr.GetData();
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
                    dtr.InsertDRab(tbxLogin.Text, tbxLogin.Text);
                    dg_Rab.ItemsSource = dtr.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: у вас повторяются данные");
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Rab.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            try
            {
                object id = (dg_Rab.SelectedItem as DataRowView).Row[0];
                dtr.DeleteDRab(Convert.ToInt32(id));
                dg_Rab.ItemsSource = dtr.GetData();
            }
            catch 
            {
                MessageBox.Show("Произошла ошибка: Вы пытаетесь удалить связанные данные");
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxLogin.Text) || string.IsNullOrEmpty(tbxLogin.Text))
            {
                MessageBox.Show("Заполните все поля перед изменением");
            }
            else if (dg_Rab.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else
            {
                try
                {
                    object id = (dg_Rab.SelectedItem as DataRowView).Row[0];
                    dtr.UpdateDRab(tbxLogin.Text, tbxLogin.Text, Convert.ToInt32(id));
                    dg_Rab.ItemsSource = dtr.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
            
        }

        private void dg_Rab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_Rab.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxLogin.Text = row.Row["LoginRab"].ToString();
                tbxPassword.Text = row.Row["PasswordRab"].ToString();
            }
        }

        private void tbxLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
