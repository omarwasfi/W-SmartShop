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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_GUI.CreateBrand
{
    /// <summary>
    /// Interaction logic for CreateBrandUC.xaml
    /// </summary>
    public partial class CreateBrandUC : UserControl
    {


        private List<BrandModel> Brands { get; set; }

        #region Set Initial Values

        public CreateBrandUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {

            UpdateBrandsFromTheDatabase();
            BrandNameValue_CreateBrandUC.Text = "";


        }

        /// <summary>
        /// Update The Brands and the public variables(Brands from the database)
        /// </summary>
        private void UpdateBrandsFromTheDatabase()
        {
            Brands = GlobalConfig.Connection.GetBrands();
            PublicVariables.Brands = null;
            PublicVariables.Brands = Brands;
        }
        #endregion

        #region Hole UC events

        /// <summary>
        /// Add the Brand to the database , Update the public variable by reset the UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_CreateBrandUC_Click(object sender, RoutedEventArgs e)
        {
            if(BrandNameValue_CreateBrandUC.Text.Length > 0)
            {
                if (GlobalConfig.Connection.CheckIfTheBrandNameUnique(Brands, BrandNameValue_CreateBrandUC.Text))
                {
                    BrandModel newBrand = new BrandModel();
                    newBrand.Name = BrandNameValue_CreateBrandUC.Text;
                    newBrand = GlobalConfig.Connection.AddBrandToTheDatabase(newBrand);

                    SetInitialValues();

                }
                else
                {
                    MessageBox.Show("This Brand is in the database !");

                }
            }
            else
            {
                MessageBox.Show("Create new Brand name");

            }
        }


        /// <summary>
        /// Clear the window by set the initial values again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_CreateBrandUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();

        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_CreateBrandUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }
        #endregion

    
        



    }
}
