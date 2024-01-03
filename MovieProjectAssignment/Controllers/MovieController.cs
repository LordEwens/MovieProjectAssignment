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
    public class MovieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //[HttpGet]
        public ActionResult ListMovies()
        {

            // ShoppingCartController.InitCart();
            //RedirectToAction("InitCart", "ShoppingCart");

            //ShoppingCartController callInit = new ShoppingCartController();
            //callInit.InitCart();

            if (Session["Cart"] == null)
            {
                ShoppingCart tempCart = new ShoppingCart();
                tempCart.MoviesInCart = new List<Movie>();
                Session["Cart"] = tempCart;
            }

            return View(db.Movies.ToList());
        }

        public ActionResult ListMoviesAddToCart(int? id)
        {
            //Session["Cart"] += id.ToString() + " ";
            Movie movie = db.Movies.Find(id);
            ShoppingCart tempCart = Session["Cart"] as ShoppingCart;
            tempCart.MoviesInCart.Add(movie);
            Session["Cart"] = tempCart;

            return View("ListMovies", db.Movies.ToList());
        }

        // string ViewCart works

        //public string ViewCart()
        //{
        //    ShoppingCart tempCart = Session["Cart"] as ShoppingCart;
        //    var returnString = "";
        //    foreach(var item in tempCart.MoviesInCart)
        //    {
        //        returnString += item.Id.ToString() + "\n";
        //        returnString += item.Title.ToString() + "\n";
        //        returnString += item.Director.ToString() + "\n";
        //        returnString += item.ReleaseYear.ToString() + "\n";
        //        returnString += item.Price.ToString() + "\n";
        //    }
        //    return returnString;
        //}

        // I'm unsure how to make the shopping cart with an overloaded ListMovies that uses HttpPost
        // The model is used to display the movies already. So a Form-submit would not work

        // Couldnt get Overloaded ListMovies to work, the one with int? id. Results in error ambigous reference
        // Changeing Action-name does not work

        //[HttpPost]
        //[ActionName("ListMoviesWithId")]
        //public ActionResult ListMovies(int? id)
        //{
        //    ShoppingCart tempCart = new ShoppingCart();
        //    Session["Cart"] += id.ToString();
        //    return View(db.Movies.ToList());
        //}


        // Requirements, add a movie with title, director, release year and price
        [HttpGet]
        public ActionResult AddMovie()
        {
            Movie refMovie = new Movie();

            return View(refMovie);
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            ViewBag.Message = "The Movie was added.";

            return View(movie);
        }
    }
}