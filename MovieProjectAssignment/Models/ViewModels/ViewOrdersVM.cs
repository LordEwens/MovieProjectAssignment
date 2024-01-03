using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProjectAssignment.Models.ViewModels
{
    public class ViewOrdersVM
    {
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public List<MovieNameAndPrice> ListOfMoviesAndPrice { get; set; }
    }

    public class MovieNameAndPrice
    {
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}