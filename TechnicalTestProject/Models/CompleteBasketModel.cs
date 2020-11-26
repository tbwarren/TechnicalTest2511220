using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTestProject.Models.ProductBasketModels;
using TechnicalTestProject.Models.ProductModels;

namespace TechnicalTestProject.Models
{
    public class CompleteBasketModel
    {
        public ChipsModel Chips { get; set; }
        public PiesModel Pies { get; set; }
        public decimal TotalPrice { get; set; }
        public int CurrentNumberOfChips { get; set; }
        public int CurrentNumberOfPies { get; set; }
        public int CurrentNumberOfNearlyExpiredPies { get; set; }
    }
}
