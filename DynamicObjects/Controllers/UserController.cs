using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObjects.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserViewModel userViewModel)
        {
            //HttpContext.Session.Set()
            if (userViewModel.UserName.ToLower().Equals("tenant1"))
                TempData["Group"] = "Group1";
            if (userViewModel.UserName.ToLower().Equals("tenant2"))
                TempData["Group"] = "Group2";
            
            return RedirectToAction("Index", "Referral");
        }
    }
}