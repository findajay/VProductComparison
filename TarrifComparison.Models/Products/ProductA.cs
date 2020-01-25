using System;
using System.Collections.Generic;
using System.Text;

namespace TarrifComparison.Models
{
    /// <summary>
    /// Product A : Basic electricity tarrif
    /// </summary>
    public class ProductA : Tarrif
    {
        //private int? PrivateBaseAnnualCost;

        /// <summary>
        /// Consumption unit in kwh per year 
        /// </summary>
        public int ConsumedUnit { get; set; }

        /// <summary>
        /// Base monthly cost in euros
        /// </summary>
        public decimal BaseMonthlyCost => 5;

        /// <summary>
        /// Base Annual cost derived from monthly cost 
        /// </summary>
        public decimal BaseAnnualCost => 12 * BaseMonthlyCost;

        /// <summary>
        /// Consumption cost per unit in cents
        /// </summary>
        public decimal ConsumptionCostPerUnit =>  22 ;
    }
}
