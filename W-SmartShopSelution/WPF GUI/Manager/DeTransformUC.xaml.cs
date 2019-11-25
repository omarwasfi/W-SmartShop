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

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for DeTransformUC.xaml
    /// </summary>
    public partial class DeTransformUC : UserControl
    {
        #region Main Variables
        /// <summary>
        /// the new transform Model
        /// </summary>
        DeTransformModel DeTransform;


        #endregion


        #region Set Inital Values

        public DeTransformUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            StoreList.ItemsSource = null;
            StoreList.ItemsSource = PublicVariables.Stores;
            StoreShoppeWallet.Value = 0;
            StoreList.SelectedItem = null;
            DeTransformValue.Value = 0;
        }

        #endregion

        #region Hole Form Events and Functions
        private void StoreList_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            StoreModel store = (StoreModel)StoreList.SelectedItem;
            if (store != null)
                StoreShoppeWallet.Value = store.GetShopeeWallet;

        }
        #endregion

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            StoreModel store = (StoreModel)StoreList.SelectedItem;
            if (store != null)
            {
                DeTransform = new DeTransformModel();
                DeTransform.Staff = PublicVariables.Staff;
                DeTransform.Store = PublicVariables.Store;
                DeTransform.Date = DateTime.Now;
                DeTransform.TotalMoney = (decimal)DeTransformValue.Value;
                DeTransform.FromStore = store;

                GlobalConfig.DeTransformValidator = new DeTransformValidator();
                ValidationResult result = GlobalConfig.DeTransformValidator.Validate(DeTransform);

                if (result.IsValid == false)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage);
                }
                else
                {
                    GlobalConfig.Connection.AddDeTransformToTheDabase(DeTransform);
                    SetInitialValues();
                }
            }
            else
            {
                MessageBox.Show("Select Store Please");
            }
        }

      
    }
}
