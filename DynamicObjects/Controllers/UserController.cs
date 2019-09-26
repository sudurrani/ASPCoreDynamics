using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicObjects.Models.User;
using Microsoft.AspNetCore.Http;
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
            if (userViewModel.UserName.ToLower().Equals("tenant1"))
            {
                HttpContext.Session.SetString("Service", "Service1");
                HttpContext.Session.SetString("Tenant", "TenantKTH");                
            }
            if (userViewModel.UserName.ToLower().Equals("tenant2"))
            {
                HttpContext.Session.SetString("Service", "Service2");
               HttpContext.Session.SetString("Tenant", "TenantLRH"); 
            }            
            return RedirectToAction("Index", "Referral");
        }
    }
}