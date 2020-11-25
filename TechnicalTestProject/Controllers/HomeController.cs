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

            if (viewModel.Chips == null)
            {
                viewModel.Chips = new ChipsModel();
            }

            if (viewModel.Pies == null)
            {
                viewModel.Pies = new PiesModel();
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
                if (viewModel.Pies.Product.Quantity > 0)
                {
                    viewModel.TotalPrice = BasketUtils.AddToBasket(viewModel.TotalPrice, viewModel.Pies.Product);
                    //Reset the Qauntity to 0 after completing adding to basket
                    viewModel.Pies.Product.Quantity = 0;
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

//pass current total in the redirect instead of full viewModel

//when there is a pie and chips together, make a 20% discount to both items
//as many as there are where they are the same
//exclude those that are not paired
//do the matsh to check that the discount to be provided is the lowest, so if the pie is 5% off, pick that, otherwise pick the 20% off, but do rules for this