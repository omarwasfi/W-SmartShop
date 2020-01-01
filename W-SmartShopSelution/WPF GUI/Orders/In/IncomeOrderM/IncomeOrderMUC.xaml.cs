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
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace WPF_GUI
{

    
    /// <summary>
    /// Interaction logic for IncomeOrderMUC.xaml
    /// </summary>
    public partial class IncomeOrderMUC : UserControl
    {

        #region Main variables

        /// <summary>
        /// The orignal Order
        /// </summary>
        private IncomeOrderModel IncomeOrder { get; set; }

        /// <summary>
        /// The Modified Order
        /// </summary>
        private IncomeOrderModel ModifiedIncomedOrder { get; set; }
        #endregion

        #region Help Variables


        /// <summary>
        /// The Removed order Products 
        /// </summary>
        private List<IncomeOrderProductModel> RemovedIncomeOrderProducts { get; set; }
        #endregion

        #region set the initianl values

        public IncomeOrderMUC(IncomeOrderModel incomeOrder)
        {
            InitializeComponent();

            IncomeOrder = incomeOrder;

            SetInitialValues();
        }


        private void SetInitialValues()
        {
            ModifiedIncomedOrder = CloneObject.CloneObjectSerializable<IncomeOrderModel>(IncomeOrder);

            RemovedIncomeOrderProducts = new List<IncomeOrderProductModel>();

            // Order info
            IncomeOrderIdValue.Text = IncomeOrder.Id.ToString();
            IncomeOrderDateValue.Text = IncomeOrder.Date.ToString();
            StaffNameValue.Text = IncomeOrder.Staff.Person.FullName;
            StoreNameValue.Text = IncomeOrder.Store.Name;
            SupplierNameValue.Text = IncomeOrder.Supplier.Person.FullName;

            IncomeOrderTotalPriceValue.Value = IncomeOrder.GetTotalPrice;
            TotalPriceAfterChangesValue.Value = IncomeOrder.GetTotalPrice;

            IncomeOrderDetailsValue.Text = IncomeOrder.Details;

            //Income Order Payments
            IncomeOrderPaymentsList.ItemsSource = null;
            IncomeOrderPaymentsList.ItemsSource = IncomeOrder.IncomeOrderPayments;

            IncomeOrderProductList.ItemsSource = null;
            IncomeOrderProductList.ItemsSource = ModifiedIncomedOrder.IncomeOrderProducts;

            RemovedIncomeOrderProductList.ItemsSource = null;
            RemovedIncomeOrderProductList.ItemsSource = RemovedIncomeOrderProducts;

            SelectedIncomeOrderProductQuantityValue.Value = 0;

            TotalPaidValue.Value = IncomeOrder.GetTotalPaid;
            ShoppeeWalletValue.Value = PublicVariables.Store.GetShopeeWallet;

            if (ModifiedIncomedOrder.GetIncomeOrderState == "DONE")
            {
                StoreShouldPayValue.Value = 0;
                StoreShouldReceiveValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;

               SupplierWillPayNowValue.Value = 0;
               SupplierWillPayLaterValue.Value = 0;
            }
            else if (ModifiedIncomedOrder.GetIncomeOrderState == "Store Should Pay")
            {
                StoreShouldPayValue.Value = ModifiedIncomedOrder.GetTotalNotPaid;
                StoreShouldReceiveValue.Value = 0;

                StoreWillPayNowValue.Value = ModifiedIncomedOrder.GetTotalNotPaid;
                StoreWillPayLaterValue.Value = 0;

                SupplierWillPayNowValue.Value = 0;
                SupplierWillPayLaterValue.Value = 0;
            }
            else if (ModifiedIncomedOrder.GetIncomeOrderState == "Store Should Receive")
            {
                StoreShouldPayValue.Value = 0;
                StoreShouldReceiveValue.Value = ModifiedIncomedOrder.GetStoreShouldReceive;

                SupplierWillPayNowValue.Value = ModifiedIncomedOrder.GetStoreShouldReceive;
                SupplierWillPayLaterValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;
            }
            else
            {
                StoreShouldPayValue.Value = 0;
                StoreShouldReceiveValue.Value = 0;
            }
        }

        #endregion



        #region Hole User Grid Functions & Events

        private void UpdateIncomeOrderProducts()
        {
            IncomeOrderProductList.ItemsSource = null;
            IncomeOrderProductList.ItemsSource = ModifiedIncomedOrder.IncomeOrderProducts;

            RemovedIncomeOrderProductList.ItemsSource = null;
            RemovedIncomeOrderProductList.ItemsSource = RemovedIncomeOrderProducts;

            SelectedIncomeOrderProductQuantityValue.Value = 0;

            if (ModifiedIncomedOrder.GetIncomeOrderState == "DONE")
            {
                StoreShouldPayValue.Value = 0;
                StoreShouldReceiveValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;

                SupplierWillPayNowValue.Value = 0;
                SupplierWillPayLaterValue.Value = 0;
            }
            else if (ModifiedIncomedOrder.GetIncomeOrderState == "Store Should Pay")
            {
                StoreShouldPayValue.Value = ModifiedIncomedOrder.GetTotalNotPaid;
                StoreShouldReceiveValue.Value = 0;

                StoreWillPayNowValue.Value = ModifiedIncomedOrder.GetTotalNotPaid;
                StoreWillPayLaterValue.Value = 0;

                SupplierWillPayNowValue.Value = 0;
                SupplierWillPayLaterValue.Value = 0;
            }
            else if (ModifiedIncomedOrder.GetIncomeOrderState == "Store Should Receive")
            {
                StoreShouldPayValue.Value = 0;
                StoreShouldReceiveValue.Value = ModifiedIncomedOrder.GetStoreShouldReceive;

                SupplierWillPayNowValue.Value = ModifiedIncomedOrder.GetStoreShouldReceive;
                SupplierWillPayLaterValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;
            }
            else
            {
                StoreShouldPayValue.Value = 0;
                StoreShouldReceiveValue.Value = 0;
            }

            TotalPriceAfterChangesValue.Value = ModifiedIncomedOrder.GetTotalPrice;


        }

        private void SaveTheIncomeOrder()
        {

            if (RemovedIncomeOrderProducts.Count == 0)
            {

                if (StoreWillPayNowValue.Value > 0)
                {
                    IncomeOrderPaymentModel incomeOrderPayment = new IncomeOrderPaymentModel();
                    incomeOrderPayment.Staff = PublicVariables.Staff;
                    incomeOrderPayment.Store = PublicVariables.Store;
                    incomeOrderPayment.Paid = StoreWillPayNowValue.Value.Value;
                    incomeOrderPayment.Date = DateTime.Now;

                    GlobalConfig.IncomeOrderPaymentValidator = new IncomeOrderPaymentValidator();

                    ValidationResult result = GlobalConfig.IncomeOrderPaymentValidator.Validate(incomeOrderPayment);

                    if (result.IsValid == false)
                    {

                        MessageBox.Show(result.Errors[0].ErrorMessage);

                    }
                    else
                    {
                        GlobalConfig.Connection.AddIncomeOrderPaymentToTheDatabase(IncomeOrder, incomeOrderPayment);
                    }
                }
                else if (StoreShouldReceiveValue.Value > 0)
                {
                    GlobalConfig.Connection.SupplierPayment(IncomeOrder, SupplierWillPayNowValue.Value.Value);
                }

                SetInitialValues();
            }
            else
            {

              /*  if (CustomerWillPayNowValue.Value > 0)
                {
                    OrderPaymentModel orderPayment = new OrderPaymentModel();
                    orderPayment.Staff = PublicVariables.Staff;
                    orderPayment.Store = PublicVariables.Store;
                    orderPayment.Paid = CustomerWillPayNowValue.Value.Value;
                    orderPayment.Date = DateTime.Now;

                    GlobalConfig.OrderPaymentValidator = new OrderPaymentValidator();

                    ValidationResult result = GlobalConfig.OrderPaymentValidator.Validate(orderPayment);

                    if (result.IsValid == false)
                    {

                        MessageBox.Show(result.Errors[0].ErrorMessage);

                    }
                    else
                    {

                        GlobalConfig.Connection.AddOrderPaymentToTheDatabase(Order, orderPayment);

                        if (MessageBox.Show("Do you want to print the order ?", "Printing...", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            PrintTheOrder();
                        }

                    }
                }
                else if (StoreWillPayNowValue.Value > 0)
                {

                    GlobalConfig.Connection.StorePayment(Order, StoreWillPayNowValue.Value.Value);
                }

                GlobalConfig.Connection.UpdateOrder(Order, RemovedOrderProducts);



                SetInitialValues();*/

            }


        }


        #region Events

        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            SaveTheIncomeOrder();
        }
        private void SupplierWillPayNowValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payNow = SupplierWillPayNowValue.Value.Value;

            if (payNow > StoreShouldReceiveValue.Value)
            {
                SupplierWillPayNowValue.Value = StoreShouldReceiveValue.Value;
                SupplierWillPayLaterValue.Value = 0;

            }
            else if (payNow == 0)
            {
                SupplierWillPayNowValue.Value = 0;
                SupplierWillPayLaterValue.Value = StoreShouldReceiveValue.Value;
            }
            else
            {
                SupplierWillPayLaterValue.Value = StoreShouldReceiveValue.Value - payNow;
            }
        }
        private void SupplierWillPayLaterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payLater = SupplierWillPayLaterValue.Value.Value;

            if (payLater > StoreShouldReceiveValue.Value)
            {
                SupplierWillPayLaterValue.Value = StoreShouldReceiveValue.Value;
                SupplierWillPayNowValue.Value = 0;
            }
            else if (payLater == 0)
            {
                SupplierWillPayLaterValue.Value = 0;
                SupplierWillPayNowValue.Value = StoreShouldReceiveValue.Value;
            }
            else
            {
                SupplierWillPayNowValue.Value = StoreShouldReceiveValue.Value - payLater;
            }
        }
        private void StoreWillPayNowValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payNow = StoreWillPayNowValue.Value.Value;

            if (payNow > StoreShouldPayValue.Value)
            {
                StoreWillPayNowValue.Value = StoreShouldPayValue.Value;
                StoreWillPayLaterValue.Value = 0;

            }
            else if (payNow == 0)
            {
                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = StoreShouldPayValue.Value;
            }
            else if (payNow > ShoppeeWalletValue.Value.Value)
            {
                StoreWillPayNowValue.Value = ShoppeeWalletValue.Value.Value;
                StoreWillPayLaterValue.Value = StoreShouldPayValue.Value - ShoppeeWalletValue.Value.Value;
            }
            else
            {
                StoreWillPayLaterValue.Value = StoreShouldPayValue.Value - payNow;
            }
        }
        private void StoreWillPayLaterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payLater = StoreWillPayLaterValue.Value.Value;

            if (payLater > StoreShouldPayValue.Value)
            {
                StoreWillPayLaterValue.Value = StoreShouldPayValue.Value;
                StoreWillPayNowValue.Value = 0;


            }
            else if (payLater == 0)
            {
                StoreWillPayLaterValue.Value = 0;
                StoreWillPayNowValue.Value = StoreShouldPayValue.Value;
            }
            else
            {
                StoreWillPayNowValue.Value = StoreShouldPayValue.Value - payLater;
            }
        }
        private void MoveSelectedToRemovedProductsGridButton_Click(object sender, RoutedEventArgs e)
        {
            IncomeOrderProductModel incomeOrderProduct = (IncomeOrderProductModel)IncomeOrderProductList.SelectedItem;
            if (incomeOrderProduct != null)
            {
                if (SelectedIncomeOrderProductQuantityValue.Value > 0)
                {
                    IncomeOrderProductModel incomeOrderProductModel = new IncomeOrderProductModel();
                    incomeOrderProductModel = incomeOrderProduct.CloneObjectSerializable();
                    incomeOrderProductModel.Quantity = (float)SelectedIncomeOrderProductQuantityValue.Value;

                    if (RemovedIncomeOrderProducts.Exists(x => x.Product.Id == incomeOrderProductModel.Product.Id))
                    {
                        RemovedIncomeOrderProducts.Find(x => x.Product.Id == incomeOrderProductModel.Product.Id).Quantity += incomeOrderProductModel.Quantity;
                    }
                    else
                    {
                        RemovedIncomeOrderProducts.Add(incomeOrderProductModel);
                    }


                    incomeOrderProduct.Quantity -= incomeOrderProductModel.Quantity;
                    if (incomeOrderProduct.Quantity == 0)
                    {
                        ModifiedIncomedOrder.IncomeOrderProducts.Remove(incomeOrderProduct);
                    }

                    UpdateIncomeOrderProducts();
                }
            }
        }
        private void IncomeOrderProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IncomeOrderProductModel incomeOrderProduct = (IncomeOrderProductModel)IncomeOrderProductList.SelectedItem;
            if (incomeOrderProduct != null)
            {
                SelectedIncomeOrderProductQuantityValue.Value = incomeOrderProduct.Quantity;
            }
        }
        private void SelectedIncomeOrderProductQuantityValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            IncomeOrderProductModel incomeOrderProduct = (IncomeOrderProductModel)IncomeOrderProductList.SelectedItem;
            if (incomeOrderProduct != null)
            {
                if (SelectedIncomeOrderProductQuantityValue.Value > incomeOrderProduct.Quantity)
                {
                    SelectedIncomeOrderProductQuantityValue.Value = incomeOrderProduct.Quantity;
                }

            }
            else
            {
                SelectedIncomeOrderProductQuantityValue.Value = 0;
            }
        }
        private void MoveSelectedToNotRemovedProductsButton_Click(object sender, RoutedEventArgs e)
        {
            IncomeOrderProductModel incomeOrderProduct = (IncomeOrderProductModel)RemovedIncomeOrderProductList.SelectedItem;
            if (incomeOrderProduct != null)
            {

                IncomeOrderProductModel incomeOrderProductModel = new IncomeOrderProductModel();
                incomeOrderProductModel = incomeOrderProduct.CloneObjectSerializable();


                if (ModifiedIncomedOrder.IncomeOrderProducts.Exists(x => x.Product.Id == incomeOrderProductModel.Product.Id))
                {
                    ModifiedIncomedOrder.IncomeOrderProducts.Find(x => x.Product.Id == incomeOrderProductModel.Product.Id).Quantity += incomeOrderProductModel.Quantity;
                }
                else
                {
                    ModifiedIncomedOrder.IncomeOrderProducts.Add(incomeOrderProductModel);
                }


                incomeOrderProduct.Quantity -= incomeOrderProductModel.Quantity;
                if (incomeOrderProduct.Quantity == 0)
                {
                    RemovedIncomeOrderProducts.Remove(incomeOrderProduct);
                }

                UpdateIncomeOrderProducts();


            }
        }
        private void MoveAllProductsToRemovedProductsGridButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (IncomeOrderProductModel incomeOrderProductModel in ModifiedIncomedOrder.IncomeOrderProducts)
            {
                if (RemovedIncomeOrderProducts.Exists(x => x.Product.Id == incomeOrderProductModel.Product.Id))
                {
                    RemovedIncomeOrderProducts.Find(x => x.Product.Id == incomeOrderProductModel.Product.Id).Quantity += incomeOrderProductModel.Quantity;
                }
                else
                {
                    RemovedIncomeOrderProducts.Add(incomeOrderProductModel);
                }
                if (ModifiedIncomedOrder.IncomeOrderProducts.Count == 0)
                {
                    break;
                }
            }
            ModifiedIncomedOrder.IncomeOrderProducts = new List<IncomeOrderProductModel>();
            UpdateIncomeOrderProducts();

        }
        private void ResetListsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (IncomeOrderProductModel incomeOrderProductModel in RemovedIncomeOrderProducts)
            {
                if (ModifiedIncomedOrder.IncomeOrderProducts.Exists(x => x.Product.Id == incomeOrderProductModel.Product.Id))
                {
                    ModifiedIncomedOrder.IncomeOrderProducts.Find(x => x.Product.Id == incomeOrderProductModel.Product.Id).Quantity += incomeOrderProductModel.Quantity;
                }
                else
                {
                    ModifiedIncomedOrder.IncomeOrderProducts.Add(incomeOrderProductModel);
                }
                if (RemovedIncomeOrderProducts.Count == 0)
                {
                    break;
                }
            }
            RemovedIncomeOrderProducts = new List<IncomeOrderProductModel>();
            UpdateIncomeOrderProducts();
        }



        #endregion

        #endregion

       
    }
}
