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
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace WPF_GUI.CreateBrand
{
    /// <summary>
    /// Interaction logic for CreateBrandUC.xaml
    /// </summary>
    public partial class CreateBrandUC : UserControl
    {


        #region Set Initial Values

        public CreateBrandUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {

            BrandNameValue.Text = "";


        }






        #endregion

        #region Hole UC events

        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            BrandModel brand = new BrandModel();
            brand.Name = BrandNameValue.Text;

            GlobalConfig.BrandValidator = new BrandValidator();

            ValidationResult result = GlobalConfig.BrandValidator.Validate(brand);

            if (result.IsValid == false)
            {

                MessageBox.Show(result.Errors[0].ErrorMessage);

            }
            else
            {
                GlobalConfig.Connection.AddBrandToTheDatabase(brand);
                SetInitialValues();
            }

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }




        #endregion

      
    }
}
