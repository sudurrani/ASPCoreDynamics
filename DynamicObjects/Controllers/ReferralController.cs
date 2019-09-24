using System.Threading.Tasks;
using DynamicObjects.Models;
using Microsoft.AspNetCore.Mvc;
namespace DynamicObjects.Controllers
{
	public class ReferralController : Controller
	{

		[HttpGet]
		public IActionResult Index()
		{
 
			string viewName = string.Empty; 
			viewName = TempData["Group"]+"Referral";
			TempData.Keep("Group");
			return View(viewName);
		}

		[HttpGet]
		public IActionResult Group1Referral()
		{
			 return View();
		}

		[HttpPost]
		public IActionResult Group1Referral(Models.Referral.Group1ReferralViewModel group1ReferralViewModel)
		{
			return View();
		}

		[HttpGet]
		public IActionResult Group2Referral()
		{
			 return View();
		}

		[HttpPost]
		public IActionResult Group2Referral(Models.Referral.Group2ReferralViewModel group2ReferralViewModel)
		{
			return View();
		}
	}
}
