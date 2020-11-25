using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models.ProductBasketModels;

namespace TechnicalTestProject.Models
{
    public class CompleteBasketModel
    {
        public ChipsModel Chips { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
