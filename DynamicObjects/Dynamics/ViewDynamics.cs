using DynamicObjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Dynamics
{
    public class ViewDynamics
    {
        public static bool Generate(string directory,DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            try
            {
                var file = Path.Combine(directory, dynamicObjectsViewModel.Group + dynamicObjectsViewModel.Page + ".cshtml");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                
                if (!System.IO.File.Exists(file))
                    System.IO.File.Create(file).Dispose();                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }
        public static bool AddContent(string directory, DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            //directory = GetDirectory("Views\\Home");            

            var file = Path.Combine(directory, dynamicObjectsViewModel.Group + dynamicObjectsViewModel.Page + ".cshtml");
            using (TextWriter text = new StreamWriter(file))
            {
                text.WriteLine("@model DynamicObjects.Models." + dynamicObjectsViewModel.Page + "." + dynamicObjectsViewModel.Group + dynamicObjectsViewModel.Page + "ViewModel");
                text.WriteLine();
                text.WriteLine("<div class=" + "row" + ">");
                text.WriteLine(EmptyColumns(4));
                text.WriteLine("\t\t<div class=" + "col-md-4" + ">");
                text.WriteLine("\t\t\t<form asp-action=" + dynamicObjectsViewModel.Group + dynamicObjectsViewModel.Page + ">");
                text.WriteLine("\t\t\t\t<div asp-validation-summary=" + "ModelOnly" + " class=" + "text-danger" + "></div>");
            }
            foreach (var row in dynamicObjectsViewModel.FieldsDetailViewModel)
            {
                using (StreamWriter text = new StreamWriter(file, true))
                {
                    text.WriteLine(FormGroup());
                    text.WriteLine(LabelFor(row.FieldName));
                    text.WriteLine(TextBoxFor(row.FieldName));
                    text.WriteLine(ErrorFor(row.FieldName));
                    text.WriteLine(CLoseDiv("\t\t\t\t"));
                }
            }
            using (StreamWriter text = new StreamWriter(file, true))
            {
                text.WriteLine(FormGroup());
                text.WriteLine(SubmitButtonFor("Save"));
                text.WriteLine(CLoseDiv("\t\t\t\t"));
            }
            using (StreamWriter text = new StreamWriter(file, true))
            {
                text.WriteLine(@""
                                +"\n\t\t</form>"
                                +"\n\t</div>"
                                +"\n</div>"
                               );
            }
            
            return true;
        }
        private static string FormGroup()
        {
            return "\t\t\t\t<div class=" + "form-group" + ">";
        }
        private static string LabelFor(string name)
        {
            return "\t\t\t\t\t<label asp-for=" + name + " class=" + "control-label" + "></label>";
        }
        private static string TextBoxFor(string name)
        {
            return "\t\t\t\t\t<input asp-for=" + name + " class=" + "form-control" + " />";
        }
        private static string ErrorFor(string name)
        {
            return "\t\t\t\t\t<span asp-validation-for=" + name + " class=" + "text-danger" + "></span>";
        }
        private static string SubmitButtonFor(string name)
        {
            return string.Format("\t\t\t\t\t<input type=submit value=\"{0}\" class=\"{1}\" />", name, "btn btn-primary");
        }
        private static string EmptyColumns(int columns)
        {
            return string.Format("<div class=\"{0}\"></div>", "col-md-" + columns + "");
        }
        private static string CLoseDiv(string sequence)
        {
            return string.Format(sequence+"</div>");
        }
    }
}
