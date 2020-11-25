using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models.ProductBasketModels;

namespace TechnicalTestProject.Models.ProductModels
{
    public class PiesModel : IValidatableObject
    {
        public PiesModel(DateTime? expiryDate)
        {
            Product = new ProductDetailsModel("Pies", (decimal)3.20, expiryDate);
        }
        public ProductDetailsModel Product { get; set; }
        public bool Validated { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Product.ExpiryDate == null)
            {
                results.Add(new ValidationResult("Pies Require an Expiry Date", new[] { "ExpiryDate" }));
                Validated = false;
            }
            else if (((DateTime)Product.ExpiryDate).Date >= DateTime.Now.Date)
            {
                results.Add(new ValidationResult("Pie has Expired", new[] { "ExpiryDate" }));
                Validated = false;
            }
            else
            {
                Validated = true;
            }

            return results;
        }
    }
}
