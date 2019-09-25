using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Models
{
    public class DynamicObjectsViewModel
    {
        [Required]
        public string Group { get; set; }
        [Required]
        public string Page { get; set; }
        public List<FieldsDetailViewModel> FieldsDetailViewModel { get; set; }
    }
}
