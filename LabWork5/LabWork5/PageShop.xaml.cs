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
    /// Логика взаимодействия для PageShop.xaml
    /// </summary>
    public partial class PageShop : Page
    {
        ShopTableAdapter shop = new ShopTableAdapter();
        public PageShop()
        {
            InitializeComponent();
            dg_Shop.ItemsSource = shop.GetData();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxShop.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    shop.InsertShop(tbxShop.Text);
                    dg_Shop.ItemsSource = shop.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: У вас повторяется магазин");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Shop.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_Shop.SelectedItem as DataRowView).Row[0];
                    shop.DeleteShop(Convert.ToInt32(id));
                    dg_Shop.ItemsSource = shop.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Shop.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(tbxShop.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_Shop.SelectedItem as DataRowView).Row[0];
                    shop.UpdateShop(tbxShop.Text, Convert.ToInt32(id));
                    dg_Shop.ItemsSource = shop.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }  
        }

        private void dg_Shop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_Shop.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxShop.Text = row.Row["NameShop"].ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<ClassShop> forImport = LabaConvertor.DeserializeObject<List<ClassShop>>();
            try
            {
                if (forImport != null)
                {
                    foreach (var item in forImport)
                    {
                        shop.InsertShop(item.NameShop);
                    }
                    dg_Shop.ItemsSource = null;
                    dg_Shop.ItemsSource = shop.GetData();
                }
                else if (forImport == null)
                {
                    MessageBox.Show("Вы не выбрали файл(((((");
                }
            }
            catch
            {
                MessageBox.Show("Вы выбрали не тот файл");
            }

        }

        private void tbxShop_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-яA-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
