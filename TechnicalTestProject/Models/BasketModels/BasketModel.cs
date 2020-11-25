using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models.ProductBasketModels;

namespace TechnicalTestProject.Models.BasketModels
{
    public class BasketModel
    {
        public BasketModel()
        {
            Products = new List<ProductDetailsModel>();
        }

        public List<ProductDetailsModel> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
