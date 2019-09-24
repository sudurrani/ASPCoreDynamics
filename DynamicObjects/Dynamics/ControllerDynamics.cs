using DynamicObjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Dynamics
{
    public static class ControllerDynamics
    {
        public static bool Generate(string directory, DynamicObjectsViewModel dynamicObjectsViewModel) 
        {
            try
            {
                var file = Path.Combine(directory, dynamicObjectsViewModel.Page + "Controller.cs");
                if (!System.IO.File.Exists(file))
                    System.IO.File.Create(file).Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;                
            }
            return true;

        }
        public static bool AddRefernces(string directory, DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            try
            {
                var file = Path.Combine(directory, dynamicObjectsViewModel.Page + "Controller.cs");               
                string references = @""
                                 + "using System.Threading.Tasks;\n"
                                 + "using DynamicObjects.Models;\n"
                                 + "using Microsoft.AspNetCore.Mvc;\n"
                                 + "namespace DynamicObjects.Controllers\n{"
                                 + "\n\tpublic class " + dynamicObjectsViewModel.Page + "Controller : Controller\n\t{"
                                 + "\n\t}\n}"
                                 + ""
                                 ;
                var txtLines = System.IO.File.ReadAllLines(file).ToList();
                int actionIndexToBeAdded = txtLines.Count();// - 3;
                if (!txtLines.Contains("namespace DynamicObjects.Controllers"))
                {
                    txtLines.Insert(actionIndexToBeAdded, references);
                    System.IO.File.WriteAllLines(file, txtLines);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;                
            }
            return true;
        }
        public static bool Index(string directory,DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            try
            {
                string responsibleView = "\n\t\t" + @"[HttpGet]" +
                "\n\t\tpublic IActionResult Index()" +
                "\n\t\t{\n " +
                "\n\t\t\tstring viewName = string.Empty; " +
                "\n\t\t\tviewName = TempData[\"Group\"]+" + "\"" + dynamicObjectsViewModel.Page + "\";" +
                "\n\t\t\tTempData.Keep(\"Group\");" +
                "\n\t\t\treturn View(" + "viewName" + ");\n\t\t}";
                var file = Path.Combine(directory, dynamicObjectsViewModel.Page + "Controller.cs");
                var txtLines = System.IO.File.ReadAllLines(file).ToList();
                int actionIndexToBeAdded = txtLines.Count() - 2;
                if (!txtLines.Contains("\t\tpublic IActionResult Index()"))
                {
                    txtLines.Insert(actionIndexToBeAdded, responsibleView);
                    System.IO.File.WriteAllLines(file, txtLines);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;                
            }
            return true;
        }
        public static bool Get(string directory, DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            try
            {
                string getAction = "\n\t\t[HttpGet]\n\t\tpublic IActionResult " + dynamicObjectsViewModel.Group + dynamicObjectsViewModel.Page + "()\n\t\t{\n\t\t\t return View();\n\t\t}";
                var file = Path.Combine(directory, dynamicObjectsViewModel.Page + "Controller.cs");
                var txtLines = System.IO.File.ReadAllLines(file).ToList();
                int actionIndexToBeAdded = txtLines.Count() - 2;
                if (!txtLines.Contains(getAction))
                {
                    txtLines.Insert(actionIndexToBeAdded, getAction);
                    System.IO.File.WriteAllLines(file, txtLines);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }
        public static bool Post(string directory, DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            try
            {
                string postAction = "\n\t\t[HttpPost]\n\t\tpublic IActionResult " + dynamicObjectsViewModel.Group + dynamicObjectsViewModel.Page + "(Models." + dynamicObjectsViewModel.Page + "." + dynamicObjectsViewModel.Group + dynamicObjectsViewModel.Page + "ViewModel " + dynamicObjectsViewModel.Group.ToLower() + dynamicObjectsViewModel.Page + "ViewModel" + ")\n\t\t{\n\t\t\treturn View();\n\t\t}";
                var file = Path.Combine(directory, dynamicObjectsViewModel.Page + "Controller.cs");
                var txtLines = System.IO.File.ReadAllLines(file).ToList();
                int actionIndexToBeAdded = txtLines.Count() - 2;
                if (!txtLines.Contains(postAction))
                {
                    txtLines.Insert(actionIndexToBeAdded, postAction);
                    System.IO.File.WriteAllLines(file, txtLines);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }
        //public static bool Close(string directory,DynamicObjectsViewModel dynamicObjectsViewModel)
        //{
        //    try
        //    {
        //        var file = Path.Combine(directory, dynamicObjectsViewModel.Page + "Controller.cs");
        //        var txtLines = System.IO.File.ReadAllLines(file).ToList();                
        //        int actionIndexToBeAdded = txtLines.Count();// - 3;
        //        txtLines.Insert(actionIndexToBeAdded, "\t}\n}");
        //        System.IO.File.WriteAllLines(file, txtLines);
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception.Message);
        //        return false;
        //    }
        //    return true;
        //}
        
    }
}
