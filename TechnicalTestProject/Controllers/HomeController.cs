using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechnicalTestProject.Models;
using TechnicalTestProject.Models.ProductBasketModels;
using TechnicalTestProject.Models.ProductModels;
using TechnicalTestProject.Utils;

namespace TechnicalTestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(CompleteBasketModel viewModel)
        {
            if (viewModel == null)
            { 
                viewModel = new CompleteBasketModel();
            }

            viewModel.Chips = new ChipsModel();

            viewModel.Pies = new PiesModel();
            return View(viewModel);
        }

        public IActionResult UpdateBasket(CompleteBasketModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Chips.Product.Quantity > 0)
                {
                    viewModel.CurrentNumberOfChips += viewModel.Chips.Product.Quantity;
                    //Reset the Quantity to 0 after completing adding to basket
                    viewModel.Chips.Product.Quantity = 0;
                }
                if (viewModel.Pies.Product.Quantity > 0)
                {
                    if (((DateTime)viewModel.Pies.Product.ExpiryDate).Date == DateTime.Now.Date)
                    {
                        viewModel.CurrentNumberOfNearlyExpiredPies += viewModel.Pies.Product.Quantity;
                    }
                    else
                    {
                        viewModel.CurrentNumberOfPies += viewModel.Pies.Product.Quantity;
                    }
                    //Reset the Quantity to 0 after completing adding to basket
                    viewModel.Pies.Product.Quantity = 0;
                }

                viewModel.TotalPrice = BasketUtils.AddToBasket(viewModel.CurrentNumberOfChips, viewModel.CurrentNumberOfPies, viewModel.CurrentNumberOfNearlyExpiredPies);
            }
            else
            {
                return View("Index",viewModel);
            }

            return RedirectToAction("Index", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
