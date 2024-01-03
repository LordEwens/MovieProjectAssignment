using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProjectAssignment.Models
{
	public class OrderRow
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public int OrderId { get; set; }
		public Order Order { get; set; }

		[Required]
		public int MovieId { get; set; }
		public Movie Movie { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

	}
}