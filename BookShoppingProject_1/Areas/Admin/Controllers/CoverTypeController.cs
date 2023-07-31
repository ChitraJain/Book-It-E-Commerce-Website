using BookShoppingProject_1.DataAccess.Repository.IRepository;
using BookShoppingProject_1.Models;
using BookShoppingProject_1.Utility;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShoppingProject_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public CoverTypeController(IUnitofWork unitofWork)
        {
             _unitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if (id == null) return View(coverType);
            //***sporc
            var param = new DynamicParameters();
            param.Add("@Id", id.GetValueOrDefault());
            coverType = _unitofWork.SP_CALL.OneRecord<CoverType>(SD.Proc_GetCoverType, param);
            //***
            //coverType = _unitofWork.CoverType.Get(id.GetValueOrDefault());
            if (coverType == null) return NotFound();
            return View(coverType);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (coverType == null) return NotFound();
            if (!ModelState.IsValid) return View();
            var param = new DynamicParameters();
            param.Add("@Name", coverType.Name);
            if (coverType.Id == 0)
                //_unitofWork.CoverType.Add(coverType);
                _unitofWork.SP_CALL.Execute(SD.Proc_CreateCoverType, param);
            else
            {
                param.Add("@Id", coverType.Id);
                _unitofWork.SP_CALL.Execute(SD.Proc_UpdateCoverType, param);
            }
            //    _unitofWork.CoverType.Update(coverType);
            //_unitofWork.Save();
            return RedirectToAction(nameof(Index));
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var coverTypelist = _unitofWork.SP_CALL.List<CoverType>(SD.Proc_GetCoverTypes);
            //var coverTypelist = _unitofWork.CoverType.GetAll();
            return Json(new { data = coverTypelist });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var coverTypeInDb = _unitofWork.CoverType.Get(id);
            if (coverTypeInDb == null)
            return Json(new { success = false, message = "SomeThing went wrong when Delete Item!!!" });
            var param = new DynamicParameters();
            param.Add("@Id", coverTypeInDb.Id);
            _unitofWork.SP_CALL.Execute(SD.Proc_DeleteCoverType, param);
            //_unitofWork.CoverType.Remove(coverTypeInDb);
            //_unitofWork.Save();
            return Json(new { success = true, message = "Data Successfully Deleted" });
        }
        #endregion
    }
}
