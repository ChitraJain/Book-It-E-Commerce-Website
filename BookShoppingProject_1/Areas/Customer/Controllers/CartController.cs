using BookShoppingProject_1.DataAccess.Repository.IRepository;
using BookShoppingProject_1.Models;
using BookShoppingProject_1.Models.ViewModels;
using BookShoppingProject_1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BookShoppingProject_1.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private static bool isEmailConfirm = false;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<IdentityUser> _userManager;
        public CartController(IUnitofWork unitofWork,IEmailSender emailSender,UserManager<IdentityUser>userManager)
        {
            _unitofWork = unitofWork;
            _emailSender = emailSender;
            _userManager = userManager;
        }
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                ShoppingCartVM = new ShoppingCartVM()
                {
                    listCart = new List<ShoppingCart>()
                };
                //********
                return View(ShoppingCartVM);
            }
            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                listCart = _unitofWork.ShoppingCart.
                GetAll(sp => sp.ApplicationId == claim.Value, 
                includeProperties: "Product")
            };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            ShoppingCartVM.OrderHeader.ApplicationUser = 
                _unitofWork.ApplicationUser.FirstOrDefault(v => v.Id == 
                claim.Value, includeProperties: "Company");
            foreach (var list in ShoppingCartVM.listCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, 
                    list.Product.Price, list.Product.Price50, list.Product.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Count * list.Price);
                if (list.Product.Description.Length > 100)
                {
                    list.Product.Description = 
                        list.Product.Description.Substring(0, 99) + "....";
                }
            }
            if (isEmailConfirm)
            {
                ViewBag.EmailMessage = "Email has been sent Kindly verify your email !";
                ViewBag.EmailCss = "text-success";
                isEmailConfirm = false;
            }
            else
            {
                ViewBag.EmailMessage = "Email must be confirm for authorize customer !";
                ViewBag.EmailCss = "test-danger";
            }

            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexPost()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var user = _unitofWork.ApplicationUser.FirstOrDefault(u => u.Id == claim.Value);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email is Empty");
            }
            else
            {
                // Email Confirmation
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = user.Id, code = code},
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                isEmailConfirm = true;
            }
            return RedirectToAction(nameof(Index));
        }
            public IActionResult plus(int cartId)
        {
            var cart = _unitofWork.ShoppingCart.FirstOrDefault(sc => sc.Id == cartId);
            cart.Count += 1;
            _unitofWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult minus(int cartId)
        {
            var cart = _unitofWork.ShoppingCart.FirstOrDefault(sc => sc.Id == cartId);
            if (cart.Count == 1)
            {
                cart.Count = 1;
            }
            else
            {
                cart.Count -= 1;
            }
            _unitofWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult delete(int cartId)
        {
            var cart = _unitofWork.ShoppingCart.FirstOrDefault(sc => sc.Id == cartId);
            _unitofWork.ShoppingCart.Remove(cart);
            _unitofWork.Save();
            //session
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitofWork.ShoppingCart.GetAll(u => u.ApplicationId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.SS_CartSessionCount, count);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Summary()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                listCart = _unitofWork.ShoppingCart.GetAll(sc => sc.ApplicationId == claim.Value, includeProperties: "Product")
            };
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitofWork.ApplicationUser.FirstOrDefault(u => u.Id == claim.Value, includeProperties: "Company");
            foreach (var list in ShoppingCartVM.listCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, list.Product.Price, list.Product.Price50, list.Product.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
                list.Product.Description = SD.ConvertToRowHtml(list.Product.Description);
            }
            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPost(string stripeToken)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitofWork.ApplicationUser.FirstOrDefault(u => u.Id == claim.Value, includeProperties: "Company");
            ShoppingCartVM.listCart = _unitofWork.ShoppingCart.GetAll(sc => sc.ApplicationId == claim.Value, includeProperties: "Product");
            ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.OrderStatusPending;
            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = claim.Value;
            _unitofWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
            _unitofWork.Save();
            foreach (var list in ShoppingCartVM.listCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, list.Product.Price, list.Product.Price50, list.Product.Price100);
                OrderDetail orderDetail = new OrderDetail()
                {
                    ProductId = list.ProductId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Price = list.Price,
                    Count=list.Count
                };
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
                _unitofWork.OrderDetail.Add(orderDetail);
                _unitofWork.Save();
            }
            _unitofWork.ShoppingCart.RemoveRange(ShoppingCartVM.listCart);
            _unitofWork.Save();

           HttpContext.Session.SetInt32(SD.SS_CartSessionCount, 0);
            #region Stripe
            if (stripeToken == null)
            {
                ShoppingCartVM.OrderHeader.PaymentDueDate = DateTime.Now.AddDays(30);
                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusDelayPayment;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.OrderStatusApproved;
            }
            else
            {
                //PaymentProcess
                var options = new ChargeCreateOptions()
                {
                    Amount = Convert.ToInt32(ShoppingCartVM.OrderHeader.OrderTotal),
                    Currency = "usd",
                    Description = "OrderId:" + ShoppingCartVM.OrderHeader.Id,
                    Source = stripeToken
                };
                //Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                if (charge.BalanceTransactionId == null)
                    ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusReject;
                else
                    ShoppingCartVM.OrderHeader.TransactionId = charge.BalanceTransactionId;
                if (charge.Status.ToLower()=="succeeded")
                {
                    ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
                    ShoppingCartVM.OrderHeader.OrderStatus = SD.OrderStatusApproved;
                    ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
                }
                _unitofWork.Save();
            }
            #endregion

            return RedirectToAction("OrderConfirmation", "Cart", new { id = ShoppingCartVM.OrderHeader.Id });
        }
        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }
    }
}
