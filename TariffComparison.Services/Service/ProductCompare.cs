using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Services.Constant;
using TariffComparison.Services.Contract;
using TarrifComparison.Models;

namespace TariffComparison.Services
{
    public class ProductCompare : IProductCompare
    {
        private readonly ILogger<ProductCompare> _logger;

        public ProductCompare(ILogger<ProductCompare> logger)
        {
            _logger = logger;
        }

        public List<Tarrif> GetProductsByConsumptionUnit(int units)
        {
            List<Tarrif> ProductList = new List<Tarrif>();
            try
            {
                ProductList.Add(GetProductADetails(units));
                ProductList.Add(GetProductBDetails(units));
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, ex);
            }
            var list = ProductList.OrderBy(i => i.AnnualCost).ToList();
            return list;
        }

        private Tarrif GetProductBDetails(int units)
        {
            ProductB productB = new ProductB()
            {
                ConsumedUnit = units
            };

            decimal annualCost = productB.BaseAnnualCost;
            if (units > Constants.BASEUNITSFORPKGTARRIF)
            {
                int extraUnits = units - Constants.BASEUNITSFORPKGTARRIF;
                annualCost += (extraUnits * (productB.AdditionalCostPerKWH/100));
            }

            return new Tarrif
            {
                Name = Constants.PRODUCTBNAME,
                AnnualCost = annualCost
            };
        }

        private Tarrif GetProductADetails(int units)
        {
            ProductA productA = new ProductA
            {
                ConsumedUnit = units
            };

            decimal annualCost = productA.BaseAnnualCost + (units * (productA.ConsumptionCostPerUnit/100));
            return new Tarrif
            {
                Name = Constants.PRODUCTANAME,
                AnnualCost = Convert.ToInt32(annualCost)
            };
        }
    }
}
