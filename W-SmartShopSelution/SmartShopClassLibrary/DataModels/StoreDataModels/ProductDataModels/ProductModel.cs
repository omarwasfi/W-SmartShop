using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Product model cotains:
    /// Database Id , Name , CategoryModel , BrandModel ,current sale price, Current Income Price
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product Name ( Not has to be Unique ) (200 char)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The quantity type
        /// </summary>
        public string QuantityType { get; set; }

        /// <summary>
        /// The size of the product if it exist ( not Has to be Unique ) Or Null , can't be set if the first one is null (200 char)
        /// </summary>
        public string Size { get; set; }


        /// <summary>
        /// Has To be unique , not null (200 char)
        /// </summary>
        public string BarCode { get; set; }


        /// <summary>
        /// Product SerialNumber ( not Has to be Unique ) Or Null (200 char)
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Product SerialNumber ( not Has to be Unique ) Or Null , can't be set if the first one is null (200 char)
        /// </summary>
        public string SerialNumber2 { get; set; }



        /// <summary>
        /// The Details of a product For any additional Info (500 Char)
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Current Sale Price of the product
        /// </summary>
        public decimal SalePrice { get; set;}

        /// <summary>
        /// Current Income price of the product
        /// </summary>
        public decimal IncomePrice { get; set; }

        /// <summary>
        /// The time of the expiration in hours
        /// </summary>
        public int ExpirationPeriod { get; set; }

        /// <summary>
        /// The quantity that the user need a notification to increase the number of this product in the stock
        /// </summary>
        public int AlarmQuantity { get; set; }

        /// <summary>
        /// Category Model of this product
        /// </summary>
        public CategoryModel Category { get; set;}

        /// <summary>
        /// brand model of this Product
        /// </summary>
        public BrandModel Brand { get; set; }


        /// <summary>
        /// Get fist three litter of category , brand , Name In a Uppercase
        /// used When create a new barcode
        /// </summary>
        public string GetFirstThreeLitterBarCode { get {

                string barCode = Category.Name.Substring(0,1) + Brand.Name.Substring(0,1) + Name.Substring(0,1);
                barCode =  barCode.ToUpper();
                return barCode;
            } }
    }
}
