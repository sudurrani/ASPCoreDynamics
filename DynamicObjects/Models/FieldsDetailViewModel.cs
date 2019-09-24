using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Models
{
    public class FieldsDetailViewModel
    {         
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public bool IsRequired { get; set; }
    }
}
