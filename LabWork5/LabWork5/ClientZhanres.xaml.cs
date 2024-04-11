using LabWork5.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
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

namespace LabWork5
{
    /// <summary>
    /// Логика взаимодействия для ClientZhanres.xaml
    /// </summary>
    public partial class ClientZhanres : Page
    {
        ZhanresTableAdapter zh = new ZhanresTableAdapter();
        public ClientZhanres()
        {
            InitializeComponent();
            dg_zh.ItemsSource = zh.GetData();
        }
    }
}
