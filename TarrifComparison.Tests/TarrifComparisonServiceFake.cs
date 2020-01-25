using System;
using System.Collections.Generic;
using System.Text;
using TariffComparison.Services.Contract;
using TarrifComparison.Models;

namespace TarrifComparison.Tests
{
    public class TarrifComparisonServiceFake : IProductCompare
    {
        private readonly List<Tarrif> tarrifs;

        /// <summary>
        /// Build fake items in product 
        /// </summary>
        public TarrifComparisonServiceFake()
        {
            tarrifs = new List<Tarrif>()
            {
                new ProductA() { Name = "basic electricity tarrif", AnnualCost = 800, ConsumedUnit =3500 },
                new ProductB() { Name = "Packaged tarrif", AnnualCost=830, ConsumedUnit=3500}

            };
        }

        /// <summary>
        /// Get fake products for tests
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public List<Tarrif> GetProductsByConsumptionUnit(int units)
        {
            return tarrifs;
        }
    }
}
