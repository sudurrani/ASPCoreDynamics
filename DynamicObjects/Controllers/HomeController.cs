using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicObjects.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace DynamicObjects.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        string directory = string.Empty;
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public JsonResult IndexPost([FromBody] DynamicObjectsViewModel dynamicObjectsViewModel)//List<DynamicCreationViewModel> dynamicCreationViewModels)
        {
            string message = string.Empty;
            object responseJSON;
            if (string.IsNullOrEmpty(dynamicObjectsViewModel.Service))
                responseJSON = new { isSuccess = false, message = "Service name is required" };
            else if (string.IsNullOrEmpty(dynamicObjectsViewModel.Page))
                responseJSON = new { isSuccess = false, message = "Page name is required" };
            else if (dynamicObjectsViewModel.FieldsDetailViewModel.Count > 0)
            {
                GenerateDynamics(dynamicObjectsViewModel);
                responseJSON = new { isSuccess = true, message = "Objects have been created successfully" };
            }
            else
                responseJSON = new { isSuccess = false, message = "Field(s) are required" };

            return Json(responseJSON);
        }
        private void GenerateDynamics(DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            bool isSuccessModelGenerated = Dynamics.ModelDynamics.Generate(GetDirectory("Models\\" + dynamicObjectsViewModel.Page), dynamicObjectsViewModel);
            if (isSuccessModelGenerated)
            {
                bool isSuccessContentAdded = Dynamics.ModelDynamics.Content(GetDirectory("Models\\" + dynamicObjectsViewModel.Page), dynamicObjectsViewModel);
                if (isSuccessContentAdded)
                {
                    bool isSuccessController = Dynamics.ControllerDynamics.Generate(GetDirectory("Controllers"), dynamicObjectsViewModel);
                    if (isSuccessController)
                    {
                        bool isSuccessRef = Dynamics.ControllerDynamics.AddRefernces(GetDirectory("Controllers"), dynamicObjectsViewModel);
                        if (isSuccessRef)
                        {
                            bool isSuccessIndex = Dynamics.ControllerDynamics.Index(GetDirectory("Controllers"), dynamicObjectsViewModel);
                            if (isSuccessIndex)
                            {
                                bool isSuccessGet = Dynamics.ControllerDynamics.Get(GetDirectory("Controllers"), dynamicObjectsViewModel);
                                if (isSuccessGet)
                                {
                                    bool isSuccessPost = Dynamics.ControllerDynamics.Post(GetDirectory("Controllers"), dynamicObjectsViewModel);
                                    if (isSuccessPost)
                                    {
                                        bool isSuccessViewGenerated = Dynamics.ViewDynamics.Generate(GetDirectory("Views\\" + dynamicObjectsViewModel.Page), dynamicObjectsViewModel);
                                        if (isSuccessViewGenerated)
                                        {
                                            Dynamics.ViewDynamics.AddContent(GetDirectory("Views\\" + dynamicObjectsViewModel.Page), dynamicObjectsViewModel);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
        private string GetDirectory(string name)
        {
            string projectRootPath = _hostingEnvironment.ContentRootPath;
            return projectRootPath + "\\" + name;
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
