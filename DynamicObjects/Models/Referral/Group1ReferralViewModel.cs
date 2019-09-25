
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DynamicObjects.Models.Referral
{
	public class Group1ReferralViewModel
	{
		[MaxLength(50),MinLength(1)]
		[Required]
		public string FullName {get;set;}

		[MaxLength(50),MinLength(1)]
		public string Email {get;set;}

		[Range(1,50)]
		[Required]
		public int Age {get;set;}

	}
}
