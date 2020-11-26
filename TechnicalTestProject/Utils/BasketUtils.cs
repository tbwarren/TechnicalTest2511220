using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models;
using TechnicalTestProject.Models.ProductBasketModels;
using TechnicalTestProject.Models.ProductModels;

namespace TechnicalTestProject.Utils
{
    public static class BasketUtils
    {
        public static decimal AddToBasket(decimal CurrentValue, ProductDetailsModel NewItem)
        {
            //Get the extra price and add it to the existing total price
            decimal AdditionalPrice = (NewItem.Price * (decimal)NewItem.Quantity);

            if (NewItem.ProductName == "Pies")
            {
                if (((DateTime)NewItem.ExpiryDate) == DateTime.Now.Date)
                {
                    //No need for rounding as the prices are not odd numbers at present
                    AdditionalPrice = AdditionalPrice / 2;
                }
            }

            return CurrentValue + AdditionalPrice;
        }

        public static decimal AddToBasket(int chips, int pies, int piesNearExpiry)
        {
            List<ProductDetailsModel> products = new List<ProductDetailsModel>();

            for(int i=0; i<chips; i++)
            {
                ChipsModel chipsModel = new ChipsModel();
                products.Add(chipsModel.Product);
            }
            for (int i = 0; i < pies; i++)
            {
                PiesModel piesModel = new PiesModel();
                products.Add(piesModel.Product);
            }
            for (int i = 0; i < piesNearExpiry; i++)
            {
                PiesModel piesModel = new PiesModel();
                //just as an additional due to no database connection, i ahve added a rule here just to be safe during unit testing
                piesModel.Product.ExpiryDate = DateTime.Now.Date;
                piesModel.Product.Price = piesModel.Product.Price / 2;
                products.Add(piesModel.Product);
            }

            AdjustPricingBasedOnDiscounts(products, piesNearExpiry);

            return products.Sum(x => x.Price);
        }

        public static void AdjustPricingBasedOnDiscounts(List<ProductDetailsModel> Products, int piesNearExpiry)
        {
            var ChipsPortions = Products.Where(x => x.ProductName == "Portion of Chips");
            var PiesTotal = Products.Where(x => x.ProductName == "Pies");

            int NumberofDiscounts = 0;
            int NumberOfChips = ChipsPortions.Count();
            int NumberOfPies = PiesTotal.Count();

            if (IsPieExpiryBeterThanPieAndChipsDiscount())
            {
                NumberOfPies = NumberOfPies - piesNearExpiry;
            }

            //the number matching will always be the smaller number, so we find which one it is and update appropriately
            if(NumberOfChips> NumberOfPies)
            {
                NumberofDiscounts = NumberOfPies;
                
            }
            else
            {
                NumberofDiscounts = NumberOfChips;
            }

            for (int i = 0; i < NumberofDiscounts; i++)
            {
                ChipsPortions.ElementAt(i).Price = ChipsPortions.ElementAt(i).Price * (decimal)0.8;
                PiesTotal.ElementAt(i).Price = PiesTotal.ElementAt(i).Price * (decimal)0.8;
            }

        }

        private static bool IsPieExpiryBeterThanPieAndChipsDiscount()
        {
            //return an int based on which deal is better

            ChipsModel chips = new ChipsModel();
            PiesModel pies = new PiesModel();

            //see how much a half priced pie and a portion of chips are
            decimal pieDiscount = pies.Product.Price / 2;
            pieDiscount = pieDiscount + chips.Product.Price;

            //see how much the 20% off will be
            decimal pieandchips = (pies.Product.Price * (decimal)0.8) + (chips.Product.Price * (decimal)0.8);

            if (pieDiscount < pieandchips)
            {
                return true;
            }
            return false ;
        }
    }
}
