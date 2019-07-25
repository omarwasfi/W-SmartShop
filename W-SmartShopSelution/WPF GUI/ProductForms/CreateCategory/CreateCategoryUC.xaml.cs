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
    

namespace WPF_GUI.CreateCategory
{
    /// <summary>
    /// Interaction logic for CreateCategoryUC.xaml
    /// </summary>
    public partial class CreateCategoryUC : UserControl
    {
        private List<CategoryModel> Categories { get; set; }


        #region Set Initial Values
        public CreateCategoryUC()
        {
            InitializeComponent();
            SetInitialValues();
        }


        private void SetInitialValues()
        {

            UpdateCategoriesFromTheDatabase();
            CategoryName_CreateCategoryUC.Text = "";
        }

        /// <summary>
        /// Update The Categories and the public variables(catergories from the database)
        /// </summary>
        private void UpdateCategoriesFromTheDatabase()
        {
            Categories = GlobalConfig.Connection.GetCategories();
            PublicVariables.Categories = null;
            PublicVariables.Categories = Categories;
        }

        #endregion

        #region Hole UC events


        /// <summary>
        /// Add the category to the database , Update the public variable by reset the UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_CreateCategoryUC_Click(object sender, RoutedEventArgs e)
        {
            if(CategoryName_CreateCategoryUC.Text.Length > 0)
            {
                if (GlobalConfig.Connection.CheckIfTheCategoryNameUnique(Categories, CategoryName_CreateCategoryUC.Text))
                {
                    CategoryModel newCategory = new CategoryModel();
                    newCategory.Name = CategoryName_CreateCategoryUC.Text;
                    newCategory =  GlobalConfig.Connection.AddCategoryToTheDatabase(newCategory);

                    
                    SetInitialValues();


                }
                else
                {
                    MessageBox.Show("This Category is in the database !");
                }
            }
            else
            {
                MessageBox.Show("Create new category name");
            }

        }

        #endregion

        /// <summary>
        /// Clear the window by set the initial values again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_CreateCategoryUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_CreateCategoryUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }
    }
}
