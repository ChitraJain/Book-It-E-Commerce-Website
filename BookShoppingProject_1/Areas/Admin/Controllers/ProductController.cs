using BookShoppingProject_1.DataAccess.Repository.IRepository;
using BookShoppingProject_1.Models;
using BookShoppingProject_1.Models.ViewModels;
using BookShoppingProject_1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookShoppingProject_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Product_VM product_VM = new Product_VM()
            {
                Product = new Product(),
                CategoryList = _unitofWork.Category.GetAll().Select(cl => new SelectListItem()
                {
                    Text = cl.Name,
                    Value = cl.Id.ToString()
                }),
                CoverTypeList = _unitofWork.CoverType.GetAll().Select(cl => new SelectListItem()
                {
                    Text = cl.Name,
                    Value = cl.Id.ToString()
                })
            };
            if (id == null) return View(product_VM);
            product_VM.Product = _unitofWork.Product.Get(id.GetValueOrDefault());
            return View(product_VM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Product_VM product_VM)
        {
            if (ModelState.IsValid)
            {
                var WebRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var extantion = Path.GetExtension(files[0].FileName);
                    var uploads = Path.Combine(WebRootPath, @"images\products");
                    if (product_VM.Product.Id != 0)
                    {
                        var imageExists = _unitofWork.Product.Get(product_VM.Product.Id).imageUrl;
                        product_VM.Product.imageUrl = imageExists;
                    }
                    if (product_VM.Product.imageUrl != null)
                    {
                        var imagePath = Path.Combine(WebRootPath, product_VM.Product.imageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var FileStream = new FileStream(Path.Combine(uploads, fileName + extantion), FileMode.Create))
                    {
                        files[0].CopyTo(FileStream);
                    }
                    product_VM.Product.imageUrl = @"\images\products\" + fileName + extantion;
                }
                else
                {
                    if (product_VM.Product.Id != 0)
                    {
                        var imageExists = _unitofWork.Product.Get(product_VM.Product.Id).imageUrl;
                        product_VM.Product.imageUrl = imageExists;
                    }
                }
                if (product_VM.Product.Id == 0)
                    _unitofWork.Product.Add(product_VM.Product);
                else
                    _unitofWork.Product.Update(product_VM.Product);
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                product_VM = new Product_VM()
                {
                    Product = new Product(),
                    CategoryList = _unitofWork.Category.GetAll().Select(cl => new SelectListItem()
                    {
                        Text = cl.Name,
                        Value = cl.Id.ToString()
                    }),
                    CoverTypeList = _unitofWork.CoverType.GetAll().Select(cl => new SelectListItem()
                    {
                        Text = cl.Name,
                        Value = cl.Id.ToString()
                    })
                };
                if (product_VM.Product.Id!=0)
                {
                    product_VM.Product = _unitofWork.Product.Get(product_VM.Product.Id);
                }
                return View(product_VM);
            }
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Product.GetAll(includeProperties: "Category,CoverType") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var productinDb = _unitofWork.Product.Get(id);
          
            if (productinDb == null)
                return Json(new { success = false, message = "SomeThing went wrong when Delete Item!!!" });
            if(productinDb.imageUrl!=null)
            {
                var WebRootPath = _webHostEnvironment.WebRootPath;
                var imagePath = Path.Combine(WebRootPath, productinDb.imageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            _unitofWork.Product.Remove(productinDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Data Successfully Deleted" });
        }
        #endregion
    }
}
