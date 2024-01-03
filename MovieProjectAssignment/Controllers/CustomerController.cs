using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieProjectAssignment.Models;
using MovieProjectAssignment.Models.ViewModels;

namespace MovieProjectAssignment.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

           /*  Notes
            *  The requirement: "Each order for the user should then be displayed together with the movies belonging to the order (orderrows).
            *   Also, the total cost for the order should be displayed". "Each order should be rendered using a partial view".
            *   
            *   I have used nestled lists. List of NewViewOrdersVM that contains List of MovieNameAndPrice.
            *   NewViewOrderVM contains multiple orders. Every order has usually contains multiple movies.
            *   This is done primaraly to satisfy the partial view requirement. 
            *   
            *   I'm aware that the primary LINQ-query could include OrderDate. 
            */
        public ActionResult Details(int? id) // Id in this case is Customer Id
        {
            Customer customer = db.Customers.Find(id);

            // List of distinct Orders from Customers
            var OrdersOfCustomers = db.Orders.Where(CId => CId.CustomerId == id).Select(x => x.Id).Distinct().ToList();

            // Get MovieTitle, Price and OrderId for Customer with id as parameter
            var TitlePriceOrdId = db.OrderRows.Join(db.Orders, m => m.OrderId, r => r.Id, (m, r) => new { m, r })
                 .Join(db.Movies, mr => mr.m.MovieId, o => o.Id, (mr, o) => new { mr, o })
                 .Where(mrx => mrx.mr.r.CustomerId == id)
              .Select(mro => new MovieNameAndPrice { MovieName = mro.o.Title, Price = mro.mr.m.Price, OrderId = mro.mr.m.OrderId }).ToList();

            List<ViewOrdersVM> ListOfVMs = new List<ViewOrdersVM>();

            ViewOrdersVM TempVM;
            foreach(var n in OrdersOfCustomers) // Populate list of orders from customer
            {
                TempVM = new ViewOrdersVM();
                TempVM.OrderDate = db.Orders.Where(x => x.Id == n).Select(y => y.OrderDate).FirstOrDefault(); // OrderDate in Order Model
                TempVM.OrderNumber = n; // OrderID in Order Model
                TempVM.ListOfMoviesAndPrice = TitlePriceOrdId.Where(x => x.OrderId == n).ToList(); // List of Movie titles and Price
                ListOfVMs.Add(TempVM);
            }

            return View(ListOfVMs);
        }
    }
}
