using DynamicObjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Dynamics
{
    public static class ModelDynamics
    {

        public static bool Generate(string directory, DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            //directory = GetDirectory("Models\\" + dynamicObjectsViewModel.Page);
            try
            {
                var file = Path.Combine(directory, dynamicObjectsViewModel.Service + dynamicObjectsViewModel.Page + "ViewModel.cs");
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
        public static bool Content(string directory, DynamicObjectsViewModel dynamicObjectsViewModel)
        {
            try
            {
                var file = Path.Combine(directory, dynamicObjectsViewModel.Service + dynamicObjectsViewModel.Page + "ViewModel.cs");
                using (TextWriter text = new StreamWriter(file))
                {
                    text.WriteLine(@""
                                    + "\nusing System;"
                                    + "\nusing System.Collections.Generic;"
                                    + "\nusing System.Linq;"
                                    + "\nusing System.Threading.Tasks;"
                                    + "\nusing System.ComponentModel.DataAnnotations;"
                                    + "\nnamespace DynamicObjects.Models." + dynamicObjectsViewModel.Page + "" + "\n{" +
                                "\n\tpublic class " + dynamicObjectsViewModel.Service + dynamicObjectsViewModel.Page + "ViewModel" +
                                "\n\t{"
                                  );
                    text.WriteLine("\t\t[Key]\n\t\t[ScaffoldColumn(true)]");
                    text.WriteLine("\t\tpublic int Id {get;set;}");
                }
                foreach (var row in dynamicObjectsViewModel.FieldsDetailViewModel)
                {
                    using (StreamWriter text = new StreamWriter(file, true))
                    {
                        if (row.FieldType.Equals("string"))
                        {
                            text.WriteLine("\t\t[MaxLength(" + row.MaxLength + "),MinLength(" + row.MinLength + ")]");
                        }
                        else
                        {
                            text.WriteLine("\t\t[Range(" + row.MinLength + "," + row.MaxLength + ")]");
                        }
                        if (row.IsRequired)
                            text.WriteLine("\t\t[Required]");

                        text.WriteLine("\t\tpublic " + row.FieldType + " " + row.FieldName + " {get;set;}");
                        text.WriteLine();
                    }
                }
                using (StreamWriter text = new StreamWriter(file, true))
                {
                    text.WriteLine("\t}");
                    text.WriteLine("}");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }
    }
}
