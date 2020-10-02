using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WiredBrainCoffee.CupOrderAdmin.Core.Model;
using WiredBrainCoffee.CupOrderAdmin.Core.Services.OrderCreation;

namespace WiredBrainCoffee.CupOrderAdmin.Core.Tests.Services.OrderCreation
{
    [TestClass]
    public class OrderCreationServiceTests
    {
        [TestMethod]
        public async void ShouldStoreCreatedOrderInOrderCreationResult()
        {
            var orderCreationService = new OrderCreationService(null, null);

            var numberOfOrderedCups = 1;
            var customer = new Customer();

            var orderCreationResult = await orderCreationService.CreateOrderAsync(customer, numberOfOrderedCups);
        }
    }
}
