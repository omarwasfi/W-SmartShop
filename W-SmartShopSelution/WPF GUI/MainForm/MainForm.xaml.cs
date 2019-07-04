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
using System.Windows.Shapes;
using WPF_GUI.CreateProduct;
using WPF_GUI.ProductManager;
using WPF_GUI.Sell;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
        }

       
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void SellViewItem_Selected(object sender, RoutedEventArgs e)
        {
            SellUC sellUc = new SellUC();
            TabItem sellTab = new TabItem { Header = "Sell Tab" };
            sellTab.Content = sellUc;
            MainTab.Items.Add(sellTab);
        }

        private void InventoryViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsViewItem_Selected(object sender, RoutedEventArgs e)
        {
            ProductManagerUC productManagerUC = new ProductManagerUC();
            TabItem productManagerTab = new TabItem { Header = "Products Tab" };
            productManagerTab.Content = productManagerUC;
            MainTab.Items.Add(productManagerTab);
        }

        private void CraeteNewProductViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CreateProductUC createProductUC = new CreateProductUC();
            TabItem CreateProductTab = new TabItem { Header = "Create Product Tab" };
            CreateProductTab.Content = createProductUC;
            MainTab.Items.Add(CreateProductTab);
        }
    }
}
