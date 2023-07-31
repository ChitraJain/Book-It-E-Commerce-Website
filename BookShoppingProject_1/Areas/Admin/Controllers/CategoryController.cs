using BookShoppingProject_1.DataAccess.Repository.IRepository;
using BookShoppingProject_1.Models;
using BookShoppingProject_1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShoppingProject_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public CategoryController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int?id)
        {
            Category category = new Category();
            if (id == null) return View(category);
            category = _unitofWork.Category.Get(id.GetValueOrDefault());
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (category == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (category.Id == 0)
                _unitofWork.Category.Add(category);
            else
                _unitofWork.Category.Update(category);
            _unitofWork.Save();
            return RedirectToAction(nameof(Index));
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var categorylist = _unitofWork.Category.GetAll();
                return Json(new { data = categorylist });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryInDb = _unitofWork.Category.Get(id);
            if (categoryInDb == null)
                return Json(new { success = false, message = "SomeThing went wrong when Delete Item!!!" });
            _unitofWork.Category.Remove(categoryInDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Data Successfully Deleted" });
        }
        #endregion
    }
}

