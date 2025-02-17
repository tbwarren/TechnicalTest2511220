﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTestProject.Models.ProductBasketModels
{
    public class ProductDetailsModel : IValidatableObject
    {
        public ProductDetailsModel()
        {
            Quantity = 0;
        }

        public ProductDetailsModel(string _productName, decimal _price)
        {
            ProductName = _productName;
            Price = _price;
            Quantity = 0;
        }
        public ProductDetailsModel(string _productName, decimal _price, DateTime? _expiryDate)
        {
            ProductName = _productName;
            Price = _price;
            Quantity = 0;
            ExpiryDate = _expiryDate;
        }

        [Required]
        public string ProductName { get; set; }
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool Validated { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Quantity<0)
            {
                results.Add(new ValidationResult("The Quantity cannot be negative", new[] { "Quantity" }));
            }
            if (Price < 0)
            {
                results.Add(new ValidationResult("The Price Assigned cannot be negative", new[] { "Price" }));
            }

            if (ProductName == "Pies")
            {
                if (ExpiryDate == null)
                {
                    results.Add(new ValidationResult("Pies Require an Expiry Date", new[] { "ExpiryDate" }));
                    Validated = false;
                }
                else if (((DateTime)ExpiryDate).Date < DateTime.Now.Date)
                {
                    results.Add(new ValidationResult("The number of Pies requested is lower than the number that have not Expired", new[] { "ExpiryDate" }));
                    Validated = false;
                }
                else
                {
                    Validated = true;
                }
            }
            return results;
        }
    }
}
