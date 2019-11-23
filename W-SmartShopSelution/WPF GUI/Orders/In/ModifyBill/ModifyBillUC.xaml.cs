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
namespace WPF_GUI.Orders.In.ModifyBill
{
    /// <summary>
    /// Interaction logic for ModifyBillUC.xaml
    /// </summary>
    public partial class ModifyBillUC : UserControl
    {


        #region Main Variables

        /// <summary>
        /// The shopModel that we want to modify or delete
        /// </summary>
        ShopBillModel ShopBill { get; set; } = new ShopBillModel();

        /// <summary>
        /// All the operations in the database
        /// </summary>
        List<OperationModel> Operations { get; set; } = new List<OperationModel>();

        #endregion

        #region set the initianl values


        /// <summary>
        /// Modify the bill or delete it from the database
        /// </summary>
        /// <param name="shopBill"></param>
        public ModifyBillUC(ShopBillModel shopBill)
        {
            InitializeComponent();

            ShopBill = shopBill;

            SetInitialValues();
        }

        private void SetInitialValues()
        {
            UpdateTheOperationsFromThePublicVariables();

            Operations = PublicVariables.Operations;

            DateValue_ModifyBillUC.SelectedDate = ShopBill.Date;
            DateValue_ModifyBillUC.DisplayDateStart = new DateTime(2010, 1, 1);
            DateValue_ModifyBillUC.DisplayDateEnd = DateTime.Now;

            TotalPriceValue_ModifyBillUC.Text = ShopBill.TotalMoney.ToString();
            BillDetailsValue_ModifyBillUC.Text = ShopBill.Details;

            
            StaffNameValue_ModifyBillUC.Text = PublicVariables.Staff.Person.FullName;
        }

        /// <summary>
        /// Update and set the operations , Update all kind of orders
        /// </summary>
        private void UpdateTheOperationsFromThePublicVariables()
        {
            PublicVariables.Orders = GlobalConfig.Connection.GetOrders();
            PublicVariables.IncomeOrders = GlobalConfig.Connection.GetIncomeOrders();
            PublicVariables.ShopBills = GlobalConfig.Connection.GetShopBills();

           // PublicVariables.Operations = GlobalConfig.Connection.GetOperations();
            Operations = null;
            Operations = PublicVariables.Operations;
        }


        #endregion




        #region Hole Form

        /// <summary>
        /// Money validation for any text accepts money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyValidation(object sender, TextCompositionEventArgs e)
        {
            GlobalConfig.NumberValidation.MoneyValidationTextBox(sender, e);
        }

        /// <summary>
        /// Check if the Shopbill Valid to save in the database
        /// </summary>
        /// <returns></returns>
        private Boolean IsValid()
        {
            if (string.IsNullOrWhiteSpace(TotalPriceValue_ModifyBillUC.Text) == false)
            {

            }
            else
            {
                MessageBox.Show("Enter the Total Price !");
                return false;
            }


            return true;
        }


        private void ConfirmButton_ModifyBillUC_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                

                // Setting the dateTime
                int hours = DateTime.Now.Hour;
                int minutes = DateTime.Now.Minute;
                int second = DateTime.Now.Second;

                DateTime selectedDate = new DateTime();
                selectedDate = (DateTime)DateValue_ModifyBillUC.SelectedDate;

                DateTime shopBillDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hours, minutes, second);

                ShopBill.Date = shopBillDateTime;

                ShopBill.Details = BillDetailsValue_ModifyBillUC.Text;

                ShopBill.TotalMoney = decimal.Parse(TotalPriceValue_ModifyBillUC.Text);

                


                OperationModel operation = new OperationModel();
               /* operation = GlobalConfig.Connection.GetOperationByShopBill(ShopBill, Operations);

                //operation.Date = shopBillDateTime;
                operation.AmountOfMoney = ShopBill.TotalMoney;

                // Modify the shopbill changes to the database
                ShopBill = GlobalConfig.Connection.UpdateShopBillData(ShopBill);

                // Modify the operations changes to the database
                GlobalConfig.Connection.UpdateOperationData(operation);
                */

                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }
            }

        }

        private void DeleteButton_ModifyBillUC_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("This bill will be deleted completly", "Are you sure ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

               // GlobalConfig.Connection.RemoveOperation(GlobalConfig.Connection.GetOperationByShopBill(ShopBill, Operations));
                GlobalConfig.Connection.RemoveShopBill(ShopBill);


                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }
            }

        }

        #endregion


    }
}
