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
    /// Interaction logic for InvestUC.xaml
    /// </summary>
    public partial class InvestUC : UserControl
    {
        #region Main Variables

        /// <summary>
        /// The New Investment
        /// </summary>
        InvestmentModel Investment { get; set; }

        #endregion


        #region Set Inital Values

        public InvestUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            OwnerList.ItemsSource = null;
            OwnerList.ItemsSource = PublicVariables.Owners;
            InvestmentValue.Value = 0;
        }

        #endregion

        #region Hole Form Events and Functions
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerModel owner = (OwnerModel)OwnerList.SelectedItem;
            if (owner != null)
            {
                Investment = new InvestmentModel();
                Investment.Staff = PublicVariables.Staff;
                Investment.Store = PublicVariables.Store;
                Investment.Date = DateTime.Now;
                Investment.TotalMoney = (decimal)InvestmentValue.Value;

                GlobalConfig.InvestmentValidator = new InvestmentValidator();
                ValidationResult result = GlobalConfig.InvestmentValidator.Validate(Investment);

                if (result.IsValid == false)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage);
                }
                else
                {
                    GlobalConfig.Connection.AddInvestmentToTheDatabase(Investment, owner);
                    SetInitialValues();
                }
            }
            else
            {
                MessageBox.Show("Select Owner Please");
            }
            

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }
        #endregion


    }
}
