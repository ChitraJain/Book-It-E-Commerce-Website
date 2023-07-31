using BookShoppingProject_1.DataAccess.Repository.IRepository;
using BookShoppingProject_1.Models;
using BookShoppingProject_1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookShoppingProject_1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if(claim!=null)
            {
                var count = _unitofWork.ShoppingCart.GetAll(u => u.ApplicationId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.SS_CartSessionCount,count);
            } 
            var productlist = _unitofWork.Product.GetAll(includeProperties: "Category,CoverType");
            return View(productlist);
        }
        public IActionResult Details(int id)
        {
            //Session
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitofWork.ShoppingCart.GetAll(u => u.ApplicationId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.SS_CartSessionCount, count);
            }
            var productInDb = _unitofWork.Product.FirstOrDefault(P=>P.Id==id, includeProperties: "Category,CoverType");
            if (productInDb == null) return NotFound();
            var shoppingCart = new ShoppingCart()
            {
                Product=productInDb,
                ProductId=productInDb.Id              
            };
            return View(shoppingCart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            shoppingCart.Id = 0;
            if(ModelState.IsValid)
            {
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationId = claim.Value;
                var shoppingcartInDb = _unitofWork.ShoppingCart.FirstOrDefault(u => u.ApplicationId == claim.Value && u.ProductId == shoppingCart.ProductId);
                if(shoppingcartInDb==null)
                {
                    //Add
                    _unitofWork.ShoppingCart.Add(shoppingCart);
                }
                else
                {
                    //update
                    shoppingcartInDb.Count += shoppingCart.Count;
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var productInDb = _unitofWork.Product.FirstOrDefault(P => P.Id == shoppingCart.ProductId, includeProperties: "Category,CoverType");
                if (productInDb == null) return NotFound();
                var shoppingCartedit = new ShoppingCart()
                {
                    Product = productInDb,
                    ProductId = productInDb.Id
                };
                return View(shoppingCartedit);
            }
                  
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
