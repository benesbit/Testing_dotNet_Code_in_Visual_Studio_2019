﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using WiredBrainCoffee.CupOrderAdmin.Core.DataInterfaces;
using WiredBrainCoffee.CupOrderAdmin.Core.Model;
using WiredBrainCoffee.CupOrderAdmin.Core.Services.OrderCreation;

namespace WiredBrainCoffee.CupOrderAdmin.Core.Tests.Services.OrderCreation
{
    [TestClass]
    public class OrderCreationServiceTests
    {
        private OrderCreationService _orderCreationService;

        [TestInitialize]
        public void TestInitialize()
        {
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.SaveAsync(It.IsAny<Order>())).ReturnsAsync((Order x) => x);

            var coffeeCupRepositoryMock = new Mock<ICoffeeCupRepository>();

            _orderCreationService = new OrderCreationService(orderRepositoryMock.Object, coffeeCupRepositoryMock.Object);
        }

        [TestMethod]
        public async Task ShouldStoreCreatedOrderInOrderCreationResult()
        {
            var numberOfOrderedCups = 1;
            var customer = new Customer { Id = 99 };

            var orderCreationResult = await _orderCreationService.CreateOrderAsync(customer, numberOfOrderedCups);

            Assert.AreEqual(OrderCreationResultCode.Success, orderCreationResult.ResultCode);
            Assert.IsNotNull(orderCreationResult.CreatedOrder);
            Assert.AreEqual(customer.Id, orderCreationResult.CreatedOrder.CustomerId);
        }

        [TestMethod]
        public void ShouldStoreRemainingCupsInStockInOrderCreationResult()
        {

        }
    }
}
