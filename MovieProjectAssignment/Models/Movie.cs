using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProjectAssignment.Models
{
	public class Movie
	{
		// Identity, Primary Key will be added automaticly
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 0)]
		public string Title { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 0)]
		public string Director { get; set; }

		[Required]
		public int ReleaseYear { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
	}
}