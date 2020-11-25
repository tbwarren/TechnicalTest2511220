using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models.BasketModels;
using TechnicalTestProject.Models.ProductBasketModels;

namespace TechnicalTestProject.Utils
{
    public static class BasketUtils
    {
        public static void AddToBasket(BasketModel modal, ProductDetailsModel NewItem)
        {
            //Add to Basket
            modal.Products.Add(NewItem);

            //Get the extra price and add it to the existing total price
            decimal AdditionalPrice = (NewItem.Price * (decimal)NewItem.Quantity);
            modal.TotalPrice = modal.TotalPrice + AdditionalPrice;
        }
    }
}
