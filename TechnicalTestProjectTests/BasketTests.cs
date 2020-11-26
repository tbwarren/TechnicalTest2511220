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
            model.TotalPrice = BasketUtils.AddToBasket(1,0,0);

            Assert.IsTrue((decimal)1.80 == model.TotalPrice);
        }

        //Add two portions of chips
        [TestMethod]
        public void AssertThatAddingMultipleItemsToBasketWorks()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            model.TotalPrice = BasketUtils.AddToBasket(2,0,0);

            Assert.IsTrue((decimal)3.60 == model.TotalPrice);
        }

        //Add one, then add another and check the total equals 2
        [TestMethod]
        public void AssertThatAddingToBasketThenAddingAnotherItemWorks()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int total = 1;
            model.TotalPrice = BasketUtils.AddToBasket(total,0,0);

            Assert.IsTrue((decimal)1.80 == model.TotalPrice);

            total ++;
            model.TotalPrice = BasketUtils.AddToBasket(total,0,0);

            Assert.IsTrue((decimal)3.60 == model.TotalPrice);
        }

        //Test the rules for 1 of each product where the expiry date is a few days from now - 20% discount should be applied only
        [TestMethod]
        public void AssertThatAddingBothProductsAppliesTheDiscountWhenNotNearExpiryIndividually()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, 0);

            Assert.IsTrue((decimal)1.80 == model.TotalPrice);

            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, piestotal, 0);

            Assert.IsTrue((decimal)4.00 == model.TotalPrice);
        }

        [TestMethod]
        public void AssertThatAddingBothProductsAppliesTheDiscountWhenNotNearExpiryTogether()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 1;
            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, piestotal, 0);

            Assert.IsTrue((decimal)4.00 == model.TotalPrice);
        }

        //Test the rules for 1 of each product where the expirty date is today - 50% off the pie should be applied only
        [TestMethod]
        public void AssertThatAddingBothProductsDoesNotApplyTheDiscountWhenNotNearExpiryIndividually()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, 0);

            Assert.IsTrue((decimal)1.80 == model.TotalPrice);

            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, piestotal);

            Assert.IsTrue((decimal)3.40 == model.TotalPrice);
        }

        [TestMethod]
        public void AssertThatAddingBothProductsDoesNotApplyTheDiscountWhenNotNearExpiryTogether()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 1;
            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, piestotal);

            Assert.IsTrue((decimal)3.40 == model.TotalPrice);
        }
        //Test for 2 of chips and one of pies with the expiry date a few days in the future - 20% of one chips and pie should be applied only
        [TestMethod]
        public void AssertThatAddingBothProductsAndOneExtraAppliesTheDiscountWhenNotNearExpiryIndividually()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 2;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, 0);

            Assert.IsTrue((decimal)3.60 == model.TotalPrice);

            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, piestotal, 0);

            Assert.IsTrue((decimal)5.80 == model.TotalPrice);
        }

        [TestMethod]
        public void AssertThatAddingBothProductsAndOneExtraAppliesTheDiscountWhenNotNearExpiryTogether()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 2;
            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, piestotal, 0);

            Assert.IsTrue((decimal)5.80 == model.TotalPrice);
        }
        //Test for 2 chips and one pie where the expiry date is today - 50% off the pie the pie should be applied only
        [TestMethod]
        public void AssertThatAddingBothProductsAndOneExtraDoesNotApplyTheDiscountWhenNotNearExpiryIndividually()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 2;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, 0);

            Assert.IsTrue((decimal)3.60 == model.TotalPrice);

            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, piestotal);

            Assert.IsTrue((decimal)5.20 == model.TotalPrice);
        }

        [TestMethod]
        public void AssertThatAddingBothProductsAndOneExtraDoesNotApplyTheDiscountWhenNotNearExpiryTogether()
        {
            CompleteBasketModel model = new CompleteBasketModel();
            int chipstotal = 2;
            int piestotal = 1;
            model.TotalPrice = BasketUtils.AddToBasket(chipstotal, 0, piestotal);

            Assert.IsTrue((decimal)5.20 == model.TotalPrice);
        }
    }
}
