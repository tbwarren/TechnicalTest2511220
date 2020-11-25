using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalTestProject.Models.BasketModels;
using TechnicalTestProject.Models.ProductBasketModels;
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
            BasketModel model = new BasketModel();
            ChipsModel product = new ChipsModel();
            product.Product.Quantity = 1;
            BasketUtils.AddToBasket(model, product.Product);

            Assert.IsTrue(model.Products.Sum(x => x.Quantity) == 1);
            Assert.IsTrue((decimal)1.80 == model.TotalPrice);
        }

        //Add two portions of chips
        [TestMethod]
        public void AssertThatAddingMultipleItemsToBasketWorks()
        {
            BasketModel model = new BasketModel();
            ChipsModel product = new ChipsModel();
            product.Product.Quantity = 2;
            BasketUtils.AddToBasket(model, product.Product);

            Assert.IsTrue(model.Products.Sum(x => x.Quantity) == 2);
            Assert.IsTrue((decimal)3.60 == model.TotalPrice);
        }

        //Add one, then add another and check the total equals 2
        [TestMethod]
        public void AssertThatAddingToBasketThenAddingAnotherItemWorks()
        {
            BasketModel model = new BasketModel();
            ChipsModel product = new ChipsModel();
            product.Product.Quantity = 1;
            BasketUtils.AddToBasket(model, product.Product);

            Assert.IsTrue(model.Products.Sum(x => x.Quantity) == 1);
            Assert.IsTrue((decimal)1.80 == model.TotalPrice);

            ChipsModel productTwo = new ChipsModel();
            productTwo.Product.Quantity = 1;
            BasketUtils.AddToBasket(model, productTwo.Product);

            Assert.IsTrue(model.Products.Sum(x => x.Quantity) == 2);
            Assert.IsTrue((decimal)3.60 == model.TotalPrice);
        }
    }
}
