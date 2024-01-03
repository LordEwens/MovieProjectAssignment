using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProjectAssignment.Models.ViewModels
{
    public class MostExpensiveOrderVM
    {
        public Customer ExpCustomer { get; set; }
        public Order ExpOrder { get; set; }
        public decimal TotalPrice { get; set; }
    }
}