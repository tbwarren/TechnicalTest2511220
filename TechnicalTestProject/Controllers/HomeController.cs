using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechnicalTestProject.Models;
using TechnicalTestProject.Models.ProductBasketModels;
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

            if (viewModel.Chips == null)
            {
                viewModel.Chips = new ChipsModel();
            }


            return View(viewModel);
        }

        public IActionResult UpdateBasket(CompleteBasketModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Chips.Product.Quantity > 0)
                {
                    viewModel.TotalPrice = BasketUtils.AddToBasket(viewModel.TotalPrice, viewModel.Chips.Product);
                    //Reset the Qauntity to 0 after completing adding to basket
                    viewModel.Chips.Product.Quantity = 0;
                }
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
