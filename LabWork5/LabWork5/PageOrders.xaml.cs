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
    /// Логика взаимодействия для PageOrders.xaml
    /// </summary>
    public partial class PageOrders : Page
    {
        OrdersTableAdapter or = new OrdersTableAdapter();
        ClientsTableAdapter cl = new ClientsTableAdapter();
        ChequesTableAdapter ch = new ChequesTableAdapter();
        StatTableAdapter st = new StatTableAdapter();
        RabotnikiTableAdapter rb = new RabotnikiTableAdapter();
        SootGSTableAdapter sgs = new SootGSTableAdapter();
        public PageOrders()
        {
            InitializeComponent();
            dg_or.ItemsSource = or.GetData();
            tbxclID.ItemsSource = cl.GetData();
            tbxchID.ItemsSource = ch.GetData();
            tbxstID.ItemsSource = st.GetData();
            tbxrbID.ItemsSource = rb.GetData();
            tbxsgs.ItemsSource = sgs.GetData();

            tbxclID.DisplayMemberPath = "ID_Client";
            tbxchID.DisplayMemberPath = "ID_Cheque";
            tbxstID.DisplayMemberPath = "ID_Status";
            tbxrbID.DisplayMemberPath = "ID_Rabotnik";
            tbxsgs.DisplayMemberPath = "ID_SootGS";
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxDateO.Text) || string.IsNullOrEmpty(tbxclID.Text) || string.IsNullOrEmpty(tbxchID.Text) || string.IsNullOrEmpty(tbxstID.Text) || string.IsNullOrEmpty(tbxrbID.Text) || string.IsNullOrEmpty(tbxsgs.Text))
            {
                MessageBox.Show("У вас есть пустые поля");
            }
            else
            {
                try
                {
                    or.InsertOr(tbxDateO.Text, Convert.ToInt32(tbxclID.Text), Convert.ToInt32(tbxchID.Text), Convert.ToInt32(tbxstID.Text), Convert.ToInt32(tbxrbID.Text), Convert.ToInt32(tbxsgs.Text));
                    dg_or.ItemsSource = or.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg_or.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для удаления");
            }
            else
            {
                try
                {
                    object id = (dg_or.SelectedItem as DataRowView).Row[0];
                    or.DeleteOr(Convert.ToInt32(id));
                    dg_or.ItemsSource = or.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxDateO.Text) || string.IsNullOrEmpty(tbxclID.Text) || string.IsNullOrEmpty(tbxchID.Text) || string.IsNullOrEmpty(tbxstID.Text) || string.IsNullOrEmpty(tbxrbID.Text) || string.IsNullOrEmpty(tbxsgs.Text))
                {
                    MessageBox.Show("У вас есть пустые поля");
                }
            else if (dg_or.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали данные для изменения");
            }
            else {
                 try
                 {
                    object id = (dg_or.SelectedItem as DataRowView).Row[0];
                    or.UpdateOr(tbxDateO.Text, Convert.ToInt32(tbxclID.Text), Convert.ToInt32(tbxchID.Text), Convert.ToInt32(tbxstID.Text), Convert.ToInt32(tbxrbID.Text), Convert.ToInt32(tbxsgs.Text), Convert.ToInt32(id));
                    dg_or.ItemsSource = or.GetData();
                 }
                 catch (Exception ex)
                 {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                 }
            }
            
        }

        private void dg_or_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dg_or.SelectedItem as DataRowView;
            if (row != null)
            {
                tbxDateO.Text = row.Row["DateO"].ToString();
                tbxclID.Text = row.Row["Client_ID"].ToString();
                tbxchID.Text = row.Row["Cheque_ID"].ToString();
                tbxstID.Text = row.Row["Status_ID"].ToString();
                tbxrbID.Text = row.Row["Rabotnik_ID"].ToString();
                tbxsgs.Text = row.Row["SootGS_ID"].ToString();
            }
        }
    }
}
