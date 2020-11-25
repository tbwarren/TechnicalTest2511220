using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTestProject.Models.ProductBasketModels;
using TechnicalTestProject.Models.ProductModels;

namespace TechnicalTestProjectTests
{
    [TestClass]
    public class ProductsTests
    {
        [TestMethod]
        public void AssertThatProductsModalQuanitytIsSetToZero()
        {
            ProductDetailsModel model = new ProductDetailsModel();
            Assert.AreEqual(0, model.Quantity, "Quantity is not defaulted to 0");
        }

        [TestMethod]
        public void AssertThatModelDataTypesAreCorrect()
        {
            ProductDetailsModel model = new ProductDetailsModel();
            Assert.IsTrue(Type.GetTypeCode(model.Price.GetType()) == TypeCode.Decimal);
            Assert.IsTrue(Type.GetTypeCode(model.Quantity.GetType()) == TypeCode.Int32);
        }

        [TestMethod]
        public void AssertPortionOfChipsIsSetUpCorrect()
        {
            ChipsModel model = new ChipsModel();
            Assert.AreEqual("Portion of Chips", model.Product.ProductName);
            Assert.AreEqual((decimal)1.80, model.Product.Price);
            Assert.AreEqual(0, model.Product.Quantity);
        }

        [TestMethod]
        public void AssesrtPiesIsSetUpCorrectly()
        {
            //Ensure the expiry Date is not today for this test
            PiesModel model = new PiesModel(DateTime.Now.AddDays(2));
            Assert.AreEqual("Pies", model.Product.ProductName);
            Assert.AreEqual((decimal)3.20, model.Product.Price);
            Assert.AreEqual(0, model.Product.Quantity);
        }

        [TestMethod]
        public void AssesrtPiesGoingOutOfDateTodayIsSetUpCorrectly()
        {
            //Ensure the expiry Date is not today for this test
            PiesModel model = new PiesModel(DateTime.Now);
            Assert.AreEqual("Pies", model.Product.ProductName);
            Assert.AreEqual((decimal)1.60, model.Product.Price);
            Assert.AreEqual(0, model.Product.Quantity);
        }

        [TestMethod]
        public void AssesrtExpiredPiesIsSetUpCorrectly()
        {
            //Ensure the expiry Date is not today for this test
            PiesModel model = new PiesModel(DateTime.Now.AddDays(-2));
            Assert.IsFalse(model.Validated);
        }
    }
}
