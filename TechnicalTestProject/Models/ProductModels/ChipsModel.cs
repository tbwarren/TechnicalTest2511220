using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTestProject.Models.ProductBasketModels
{
    public class ChipsModel
    {
        public ChipsModel()
        {
            Product = new ProductDetailsModel("Portion of Chips", (decimal)1.80);
        }
        public ProductDetailsModel Product {get;set;}

    }
}
