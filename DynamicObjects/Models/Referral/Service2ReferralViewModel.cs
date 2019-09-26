
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DynamicObjects.Models.Referral
{
	public class Service2ReferralViewModel
	{
		[Key]
		[ScaffoldColumn(true)]
		public int Id {get;set;}
		[MaxLength(50),MinLength(5)]
		[Required]
		public string FullName {get;set;}

		[MaxLength(50),MinLength(9)]
		[Required]
		public string Contact {get;set;}

		[Range(0,50)]
		public int Age {get;set;}

	}
}
