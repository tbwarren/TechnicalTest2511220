using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalTestProject.Models;
using TechnicalTestProject.Models.ProductBasketModels;
using TechnicalTestProject.Models.ProductModels;
using TechnicalTestProject.Utils;

namespace TechnicalTestProjectTests
{
    [TestClass]
    public class BasketTests
    {
        //Add one portion of chips
        [TestMethod]
        public void AssertThatAddingToBasketWorks()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            ChipsModel product = new ChipsModel();
            product.Product.Quantity = 1;
            model.TotalPrice = BasketUtils.AddToBasket(model.TotalPrice, product.Product);

            Assert.IsTrue((decimal)1.80 == model.TotalPrice);
        }

        //Add two portions of chips
        [TestMethod]
        public void AssertThatAddingMultipleItemsToBasketWorks()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            ChipsModel product = new ChipsModel();
            product.Product.Quantity = 2;
            model.TotalPrice = BasketUtils.AddToBasket(model.TotalPrice, product.Product);

            Assert.IsTrue((decimal)3.60 == model.TotalPrice);
        }

        //Add one, then add another and check the total equals 2
        [TestMethod]
        public void AssertThatAddingToBasketThenAddingAnotherItemWorks()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            ChipsModel product = new ChipsModel();
            product.Product.Quantity = 1;
            model.TotalPrice = BasketUtils.AddToBasket(model.TotalPrice, product.Product);

            Assert.IsTrue((decimal)1.80 == model.TotalPrice);

            ChipsModel productTwo = new ChipsModel();
            productTwo.Product.Quantity = 1;
            model.TotalPrice = BasketUtils.AddToBasket(model.TotalPrice, productTwo.Product);

            Assert.IsTrue((decimal)3.60 == model.TotalPrice);
        }

        //Add two different products
        [TestMethod]
        public void AssertThatAddingToBasketThenAddingADifferentItemWorks()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            ChipsModel product = new ChipsModel();
            product.Product.Quantity = 1;
            model.TotalPrice = BasketUtils.AddToBasket(model.TotalPrice, product.Product);

            Assert.IsTrue((decimal)1.80 == model.TotalPrice);

            PiesModel productTwo = new PiesModel(DateTime.Now.AddDays(2));
            productTwo.Product.Quantity = 1;
            model.TotalPrice = BasketUtils.AddToBasket(model.TotalPrice, productTwo.Product);

            Assert.IsTrue((decimal)5.00 == model.TotalPrice);
        }
    }
}
