using MovieProjectAssignment.Models;
using MovieProjectAssignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProjectAssignment.Controllers
{
	public class HomeController : Controller
	{
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        // Show 3 most popular movies 
        public ActionResult PopularMovies() {
            List<Movie> MostPopularMovies = new List<Movie>();

            // Results in MovieId in the first column and the number of times the movie was orderd in the second column.
            var PopularMoviesList = db.OrderRows.GroupBy(q => q.MovieId).Select(x => new { x.Key, Cnt = x.Count()}).OrderByDescending(w => w.Cnt).Take(3).ToList();
            foreach(var n in PopularMoviesList)
            {
                MostPopularMovies.Add(db.Movies.Find(n.Key));
            }

			return View(MostPopularMovies);
		}

        public ActionResult NewestMovies()
        {
            List<Movie> NewestMoviesListOfObjects = new List<Movie>();
            NewestMoviesListOfObjects = db.Movies.OrderByDescending(y => y.ReleaseYear).Take(5).ToList();

            return View("Top5Movies", NewestMoviesListOfObjects);
        }

        public ActionResult OldestMovies()
        {
            List<Movie> OldestMoviesListOfObjects = new List<Movie>();
            OldestMoviesListOfObjects = db.Movies.OrderBy(y => y.ReleaseYear).Take(5).ToList();

            return View("Top5Movies", OldestMoviesListOfObjects);
        }

        public ActionResult CheapestMovies()
        {
            List<Movie> CheapestMoviesListOfObjects = new List<Movie>();
            CheapestMoviesListOfObjects = db.Movies.OrderBy(y => y.Price).Take(5).ToList();

            return View("Top5Movies", CheapestMoviesListOfObjects);
        }

        public ActionResult CustomerMostExpensiveOrder()
        {
            // select OrderId, SUM(Price) as Amount from OrderRows group by OrderId
            // Get the OrderId of the most expensive order
            int MostExpOrderId = db.OrderRows.GroupBy(x => x.OrderId).Select(x => new { TPrice = x.Sum(b => b.Price), OId = x.Key }).OrderByDescending(q => q.TPrice).Select(x =>  x.OId ).FirstOrDefault();
            decimal TotalPrice = db.OrderRows.GroupBy(x => x.OrderId).Select(x => new { TPrice = x.Sum(b => b.Price), OId = x.Key }).OrderByDescending(q => q.TPrice).Select(x => x.TPrice).FirstOrDefault();

            MostExpensiveOrderVM ExpVM = new MostExpensiveOrderVM();
            ExpVM.ExpOrder = db.Orders.Find(MostExpOrderId);
            ExpVM.ExpCustomer = db.Customers.Find(ExpVM.ExpOrder.CustomerId);
            ExpVM.TotalPrice = TotalPrice;

            return View(ExpVM);
        }
	}
}