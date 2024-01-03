using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProjectAssignment.Models
{
	public class Customer
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Firstname { get; set; }

		[Required]
		[StringLength(50)]
		public string Lastname { get; set; }

		[Required]
		[StringLength(50)]
		public string BillingAddress { get; set; }

		[Required]
		[StringLength(50)]
		public string BillingZip { get; set; }

		[Required]
		[StringLength(50)]
		public string BillingCity { get; set; }

		[Required]
		[StringLength(50)]
		public string DeliveryAddress { get; set; }

		[Required]
		[StringLength(50)]
		public string DeliveryZip { get; set; }

		[Required]
		[StringLength(50)]
		public string DeliveryCity { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[Required]
		[StringLength(50)]
		public string PhoneNo { get; set; }
	}
}