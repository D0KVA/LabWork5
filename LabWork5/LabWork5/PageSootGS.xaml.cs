using LabWork5.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для PageSootGS.xaml
    /// </summary>
    public partial class PageSootGS : Page
    {
        SootGSTableAdapter sgs = new SootGSTableAdapter();
        GamesTableAdapter gm = new GamesTableAdapter();
        StockTableAdapter st = new StockTableAdapter();
        ShopTableAdapter sh = new ShopTableAdapter();
        public PageSootGS()
        {
            InitializeComponent();
            dg_sgs.ItemsSource = sgs.GetData();
            cbxGameID.ItemsSource = gm.GetData();
            cbxStockID.ItemsSource = st.GetData();
            cbxShopID.ItemsSource = sh.GetData();
            cbxGameID.DisplayMemberPath = "ID_Game";
            cbxStockID.DisplayMemberPath = "ID_Stock";
            cbxShopID.DisplayMemberPath = "ID_Shop";
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbxGameID.Text) || string.IsNullOrEmpty(cbxStockID.Text) || string.IsNullOrEmpty(cbxShopID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    sgs.InsertSGS(Convert.ToInt32(cbxGameID.Text), Convert.ToInt32(cbxStockID.Text), Convert.ToInt32(cbxShopID.Text));
                    dg_sgs.ItemsSource = sgs.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: У вас повторяется соотношение");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_sgs.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_sgs.SelectedItem as DataRowView).Row[0];
                    sgs.DeleteSGS(Convert.ToInt32(id));
                    dg_sgs.ItemsSource = sgs.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_sgs.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else if (string.IsNullOrEmpty(cbxGameID.Text) || string.IsNullOrEmpty(cbxStockID.Text) || string.IsNullOrEmpty(cbxShopID.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    object id = (dg_sgs.SelectedItem as DataRowView).Row[0];
                    sgs.UpdateSGS(Convert.ToInt32(cbxGameID.Text), Convert.ToInt32(cbxStockID.Text), Convert.ToInt32(cbxShopID.Text), Convert.ToInt32(id));
                    dg_sgs.ItemsSource = sgs.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void dg_sgs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_sgs.SelectedItem as DataRowView;
            if (row != null)
            {
                cbxGameID.Text = row.Row["Game_ID"].ToString();
                cbxStockID.Text = row.Row["Stock_ID"].ToString();
                cbxShopID.Text = row.Row["Shop_ID"].ToString();
            }
        }
    }
}
