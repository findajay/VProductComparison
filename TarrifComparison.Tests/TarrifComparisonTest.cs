using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TariffComparison.Controllers;
using TariffComparison.Services.Contract;
using TarrifComparison.Models;
using Xunit;

namespace TarrifComparison.Tests
{
    public class TarrifComparisonTest
    {
        TarrifController _controller;
        IProductCompare _service;
        private readonly ILogger<TarrifController> _logger;

        public TarrifComparisonTest()
        {
            _service = new TarrifComparisonServiceFake();
            _controller = new TarrifController(_logger, _service);
        }
        [Fact]
        public void GetById_NegtiveNumberPassed_ReturnsNotFoundResult()
        {
            var services = new ServiceCollection()
        .AddLogging(config => config.AddConsole())      // can add any logger(s)
        .BuildServiceProvider();
            using (var loggerFactory = services.GetRequiredService<ILoggerFactory>())
            {
                _controller = new TarrifController(loggerFactory.CreateLogger<TarrifController>(), _service);

                // Arrange
                int consumptionUnit = -1;

                // Act
                var notFoundResult = _controller.Get(consumptionUnit);

                // Assert
                Assert.IsType<NotFoundResult>(notFoundResult.Result);
            }
        }

        [Fact]
        public void GetById_ValidPassed_ReturnsOkResult()
        {
            // Arrange
            int consumptionUnit = 3500;

            // Act
            var okResult = _controller.Get(consumptionUnit);

            // Assert
            Assert.IsType<List<Tarrif>>(okResult.Value);
        }
    }
}
