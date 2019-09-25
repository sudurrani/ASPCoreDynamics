
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DynamicObjects.Models.Referral
{
	public class Group2ReferralViewModel
	{
		[MaxLength(50),MinLength(1)]
		[Required]
		public string FirstName {get;set;}

		[MaxLength(50),MinLength(1)]
		public string MiddleName {get;set;}

		[MaxLength(50),MinLength(1)]
		[Required]
		public string LastName {get;set;}

		[MaxLength(50),MinLength(1)]
		[Required]
		public string Email {get;set;}

		[Range(1,50)]
		[Required]
		public int Age {get;set;}

	}
}
