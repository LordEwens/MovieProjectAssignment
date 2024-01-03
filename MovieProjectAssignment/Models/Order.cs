using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProjectAssignment.Models
{
	public class Order
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public DateTime OrderDate { get; set; }


		// C#/Visual studio understads foreign key relation
		// CustomerId is understod as same, from Customer table. CustomerNo will create one primary key and one foreign key.
		[Required]
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
	}
}