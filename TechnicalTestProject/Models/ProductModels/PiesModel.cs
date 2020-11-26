using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models.ProductBasketModels;

namespace TechnicalTestProject.Models.ProductModels
{
    public class PiesModel 
    {
        public PiesModel(DateTime? expiryDate)
        {
            //This is currently being used in the unit tests, this is where the database will be used with an expiry date
            Product = new ProductDetailsModel("Pies", (decimal)3.20, expiryDate);
        }

        public PiesModel()
        {
            //Defaulting to a specific datetime when no datetime is set, this is due to having no database connectuion, if we had this we could use this when settign up the db
            Product = new ProductDetailsModel("Pies", (decimal)3.20, DateTime.Now.AddDays(1));
        }

        public ProductDetailsModel Product { get; set; }

    }
}
