using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models;
using TechnicalTestProject.Models.ProductBasketModels;

namespace TechnicalTestProject.Utils
{
    public static class BasketUtils
    {
        public static decimal AddToBasket(decimal CurrentValue, ProductDetailsModel NewItem)
        {
            //Get the extra price and add it to the existing total price
            decimal AdditionalPrice = (NewItem.Price * (decimal)NewItem.Quantity);
            return CurrentValue + AdditionalPrice;
        }
    }
}
