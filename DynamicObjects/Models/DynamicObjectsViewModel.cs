using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Models
{
    public class DynamicObjectsViewModel
    {
        public string Group { get; set; }
        public string Page { get; set; }
        public List<FieldsDetailViewModel> FieldsDetailViewModel { get; set; }
    }
}
