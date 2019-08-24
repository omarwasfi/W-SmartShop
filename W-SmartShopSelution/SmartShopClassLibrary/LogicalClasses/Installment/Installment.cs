using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Installment
    {
        /// <summary>
        /// Calculate the EMI of loan When create the installment order
        /// { If the rateOfInterest  = 1 OR less -> 1 = 100% , 0.5 = 50% }
        /// EMI = [(p*r/12) (1+r/12)^n]/[(1+r/12)^n – 1 ]
        /// where p = principal amount(primary loan amount)
        /// r = rate of interest per year
        /// n = Total number of Years
        /// </summary>
        /// <param name="loanAmount"> The Amount of money </param>
        /// <param name="rateOfInterest"> rate Of Interest per year </param>
        /// <param name="numberOfMonths"> Number Of months or PaymentPeriods  </param>
        /// <returns></returns>
        public static decimal CalculateTheEMI_RateOfInterestByYear(decimal loanAmount , double rateOfInterest , int numberOfMonths )
        {
            double EMIInDouble = new double();
            double loanAmountInDouble = (double)loanAmount;

            if(rateOfInterest > 1)
            {
                rateOfInterest = rateOfInterest / 100;
            }

            
            
            EMIInDouble = (loanAmountInDouble * Math.Pow((rateOfInterest / 12) + 1,
                 (numberOfMonths)) * rateOfInterest / 12) / (Math.Pow
                 (rateOfInterest / 12 + 1, (numberOfMonths)) - 1);


            return (decimal)EMIInDouble;
        }

             

    }

    

}
