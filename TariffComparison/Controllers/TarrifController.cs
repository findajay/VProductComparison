using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TarrifComparison.Models;
using TariffComparison.Services.Contract;
using System.Net;

namespace TariffComparison.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarrifController : ControllerBase
    {        
        private readonly ILogger<TarrifController> _logger;
        IProductCompare _productCompare;

        /// <summary>
        /// Initialize constructor with dependencies 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productCompare"></param>
        public TarrifController(ILogger<TarrifController> logger, IProductCompare productCompare)
        {
            _logger = logger;
            _productCompare = productCompare;
        }

        /// <summary>
        /// Get Product list by consumption
        /// </summary>
        /// <param name="consumptionPerYear">consumption in kwh per year</param>
        /// <returns></returns>
        [HttpGet("{consumptionPerYear}")]
        public ActionResult<List<Tarrif>> Get(int consumptionPerYear)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("Request parameter is missing.", consumptionPerYear);
                    return BadRequest();
                }
                if (consumptionPerYear < 0)
                {
                    _logger.LogInformation("product information not found.", consumptionPerYear);
                    return NotFound();
                }
                var Products = _productCompare.GetProductsByConsumptionUnit(consumptionPerYear);

                if (Products == null)
                {
                    _logger.LogInformation("product information not found.", consumptionPerYear);
                    return NotFound();
                }
                return Products;
        }
            catch (AggregateException ae)
            {
                _logger.LogDebug(ae.Message, ae);
                throw;
            }
            catch (FluentValidation.ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, ex);
                throw;
            }

        }
    }
}

