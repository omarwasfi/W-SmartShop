using Library;
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
using WPF_GUI.Inventory;
using WPF_GUI.ProductManager;
using WPF_GUI.Sell;

namespace WPF_GUI
{

    // TODO - Add Permetions System to contol the menu

    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

       /// <summary>
       ///  close the application
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #region Menu Events

        private void SellViewItem_Selected(object sender, RoutedEventArgs e)
        {
            SellUC sellUc = new SellUC();
            TabItem sellTab = new TabItem { Header = "Sell Tab" };
            sellTab.Content = sellUc;
            MainTab.Items.Add(sellTab);
        }

        private void InventoryViewItem_Selected(object sender, RoutedEventArgs e)
        {
            InventoryUC inventoryUC = new InventoryUC();
            TabItem inventoryTab = new TabItem { Header = "Inventory Tab" };
            inventoryTab.Content = inventoryUC;
            MainTab.Items.Add(inventoryTab);
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
        #endregion
    }
}
