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
using Library;


namespace WPF_GUI.ProductManager
{


    /// <summary>
    /// Interaction logic for ProductManagerUC.xaml
    /// </summary>
    public partial class ProductManagerUC : UserControl
    {
        private StoreModel Store { get; set; } = PublicVariables.Store;

        private StaffModel staff = PublicVariables.Staff;

        private List<StockModel> AllStocks { get; set; } 

        public ProductManagerUC()
        {
            InitializeComponent();

            AllStocks = GlobalConfig.Connection.FilterStocksByStore(Store);
        }
    }
}
