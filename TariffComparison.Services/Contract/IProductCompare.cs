using System;
using System.Collections.Generic;
using System.Text;
using TarrifComparison.Models;

namespace TariffComparison.Services.Contract
{
    public interface IProductCompare
    {
        public List<Tarrif> GetProductsByConsumptionUnit(int units);
    }
}
