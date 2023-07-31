using BookShoppingProject_1.Data;
using BookShoppingProject_1.Models;
using BookShoppingProject_1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShoppingProject_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var userlist = _context.ApplicationUsers.Include(c => c.Company).ToList();//AspNetUser
            var roles = _context.Roles.ToList();//AspNEtRole
            var userRole = _context.UserRoles.ToList();//AspNetUserRole
            foreach (var user in userlist)
            {
                var roleId = userRole.FirstOrDefault(u =>u.UserId==user.Id).RoleId;
                user.Role = roles.FirstOrDefault(r => r.Id == roleId).Name;
                if(user.Company==null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }
            //if(!User.IsInRole(SD.Role_Admin))
                var adminUser = userlist.FirstOrDefault(u => u.Role == SD.Role_Admin);
                userlist.Remove(adminUser);
            //}
            return Json(new { data = userlist });
        }
        [HttpPost]
        public IActionResult LockUnLock([FromBody]string id)
        {
            bool isLocked = false;
            var UserInDb = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (UserInDb == null)
                return Json(new { success = false, message = "SomeThing went wrong while lock or unlock users" });
            if(UserInDb!=null && UserInDb.LockoutEnd>DateTime.Now)
            {
                UserInDb.LockoutEnd = DateTime.Now;
                isLocked = false;
            }
            else
            {
                UserInDb.LockoutEnd = DateTime.Now.AddYears(100);
                isLocked = true;
            }
            _context.SaveChanges();
            return Json(new { success = true, message = isLocked == true ? "User Successfully locked" : "User Successfully Unlocked" });
        }
        #endregion
    }
}
