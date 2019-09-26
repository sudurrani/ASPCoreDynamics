using System.Threading.Tasks;
using DynamicObjects.Common;
using DynamicObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DynamicObjects.Controllers
{
	public class ReferralController : Controller
	{

		[HttpGet]
		public IActionResult Index()
		{
 
			string viewName = string.Empty; 
			viewName = HttpContext.Session.GetString("Service")+"Referral";
			return View(viewName);
		}

		[HttpGet]
		public IActionResult Service1Referral()
		{
			 return View();
		}

		[HttpPost]
		public IActionResult Service1Referral(Models.Referral.Service1ReferralViewModel service1ReferralViewModel)
		{
            dynamic dbContext = DbContext.Instance(HttpContext.Session.GetString("Tenant"));
            dbContext.Service1Referrals.Add(service1ReferralViewModel);
            int result = dbContext.SaveChanges();
            return View();
		}

		[HttpGet]
		public IActionResult Service2Referral()
		{
			 return View();
		}

		[HttpPost]
		public IActionResult Service2Referral(Models.Referral.Service2ReferralViewModel service2ReferralViewModel)
		{
            dynamic dbContext = DbContext.Instance(HttpContext.Session.GetString("Tenant"));
            dbContext.Service2Referrals.Add(service2ReferralViewModel);
            int result = dbContext.SaveChanges();
            return View();
		}
	}
}
