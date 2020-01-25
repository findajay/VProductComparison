using System;
using System.Collections.Generic;
using System.Text;

namespace TarrifComparison.Models
{
    /// <summary>
    /// Product B : Packaged tarrif
    /// </summary>
    public class ProductB : Tarrif
    {
        public decimal BaseAnnualCost { get; set; } = 800;

        /// <summary>
        /// Total yearly unit consumed in kwh
        /// </summary>
        public int ConsumedUnit { get; set; }

        /// <summary>
        /// Additional cost per unit in cents
        /// </summary>
        public decimal AdditionalCostPerKWH => 30;
    }

}
