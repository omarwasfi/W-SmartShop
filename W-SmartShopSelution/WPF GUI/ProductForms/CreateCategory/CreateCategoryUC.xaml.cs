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
using Library;
    

namespace WPF_GUI.CreateCategory
{
    /// <summary>
    /// Interaction logic for CreateCategoryUC.xaml
    /// </summary>
    public partial class CreateCategoryUC : UserControl
    {


        #region Set Initial Values
        public CreateCategoryUC()
        {
            InitializeComponent();
            SetInitialValues();
        }


        private void SetInitialValues()
        {

            
            CategoryName.Text = "";
        }



        #endregion

        #region Hole UC events

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();

        }
        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryModel category = new CategoryModel();
            category.Name = CategoryName.Text;

            GlobalConfig.CategoryValidator = new CategoryValidator();

            ValidationResult result = GlobalConfig.CategoryValidator.Validate(category);

            if (result.IsValid == false)
            {

                MessageBox.Show(result.Errors[0].ErrorMessage);

            }
            else
            {
                GlobalConfig.Connection.AddCategoryToTheDatabase(category);
                SetInitialValues();
            }
        }


        #endregion

      
   
    }
}
