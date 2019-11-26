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
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using WPF_GUI.CreateProduct;
using WPF_GUI.ModifyProduct;

namespace WPF_GUI.ProductManager
{


    /// <summary>
    /// Interaction logic for ProductManagerUC.xaml
    /// </summary>
    public partial class ProductManagerUC : UserControl
    {

        #region Main Variables

        StiReport Report;

        


        #endregion

        #region Help variables

      
        #endregion

        #region set the initianl values


        public ProductManagerUC()
        {
            InitializeComponent();

            SetInitialValues();

        }

        /// <summary>
        /// Get variables from the database
        /// set each related Gui to this variables
        /// /// </summary>
        private void SetInitialValues()
        {
            ProductList.ItemsSource = null;
            ProductList.ItemsSource = PublicVariables.Products;

           
        }


        #endregion




        #region Hole Form Events




        #endregion

        #region Grid Events

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            Report = new StiReport();
            UserGrid.Visibility = Visibility.Collapsed;
            PrintGrid.Visibility = Visibility.Visible;
            Report.Load(@"ProductsReport.mrt");
            Report.Compile();
            Report.Render();
            ProductsReportPrint.Report = Report;
        }


        private void CreateNewProductButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            CreateNewProductGrid.Visibility = Visibility.Visible;

        }
        private void BackToUserGridButton_FromCreateNewProductGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            CreateNewProductGrid.Visibility = Visibility.Collapsed;

            SetInitialValues();
        }


        #endregion


    }
}
