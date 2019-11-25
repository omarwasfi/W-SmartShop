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
    /// Interaction logic for TransformUC.xaml
    /// </summary>
    public partial class TransformUC : UserControl
    {

        #region Main Variables
        /// <summary>
        /// the new transform Model
        /// </summary>
        TransformModel Transform;


        #endregion

        #region Set Inital Values

        public TransformUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            StoreList.ItemsSource = null;
            StoreList.ItemsSource = PublicVariables.Stores;
            FreeMoneyValue.Value = PublicVariables.Organization.GetFreeMoney;
            TransformValue.Value = 0;
        }



        #endregion

        #region Hole Form Events and Functions

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
                Transform = new TransformModel();
                Transform.Staff = PublicVariables.Staff;
                Transform.Store = PublicVariables.Store;
                Transform.Date = DateTime.Now;
                Transform.TotalMoney = (decimal)TransformValue.Value;
                Transform.ToStore = store;

                GlobalConfig.TransformValidator = new TransformValidator();
                ValidationResult result = GlobalConfig.TransformValidator.Validate(Transform);

                if (result.IsValid == false)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage);
                }
                else
                {
                    GlobalConfig.Connection.AddTransformToTheDatase(Transform);
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
