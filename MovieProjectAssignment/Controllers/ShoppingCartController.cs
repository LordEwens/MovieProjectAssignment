using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProjectAssignment.Models;

namespace MovieProjectAssignment.Controllers
{
    public class ShoppingCartController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ViewCart()
        {
            InitCart();
            ShoppingCart tempCart = Session["Cart"] as ShoppingCart;
            return View(tempCart.MoviesInCart);
        }

        public ActionResult EmptyCart()
        {
            Session["Cart"] = null;
            InitCart();
            ShoppingCart tempCart = Session["Cart"] as ShoppingCart;
            return RedirectToAction("ViewCart");
        }
        public ActionResult PlaceOrderNewCustomer()
        {
            Customer emptyCustomer = new Customer();
            return View(emptyCustomer);
        }

        [HttpPost]
        public ActionResult PlaceOrderNewCustomer(Customer submitCustomer)
        {
            // Add new customer to database
            db.Customers.Add(submitCustomer);
            db.SaveChanges();

            // Get the newly added customer, we need to know the id
            Customer latestCustomerFromDB = db.Customers.ToList().LastOrDefault();
            int newCustomerId = latestCustomerFromDB.Id;
            
            // Load shoppingcart from session
            ShoppingCart tempCart = Session["Cart"] as ShoppingCart;

            // Create order and orderrow objects
            Order newOrder = new Order();
            OrderRow newOrderRow;

            newOrder.OrderDate = DateTime.Now;
            newOrder.CustomerId = newCustomerId;
            db.Orders.Add(newOrder); // Add the new order
            db.SaveChanges();

            // We need to know the id of the newly created order
            Order latestOrder = db.Orders.ToList().LastOrDefault();
            int latestOrderId = latestOrder.Id;

            // add movies from shopping cart to orderrows, one by one
            foreach (Movie tempMovie in tempCart.MoviesInCart)
            {
                newOrderRow = new OrderRow();
                newOrderRow.OrderId = latestOrderId;
                newOrderRow.MovieId = tempMovie.Id;
                newOrderRow.Price = tempMovie.Price;
                db.OrderRows.Add(newOrderRow);
            }

            db.SaveChanges();

            return RedirectToAction("PlaceOrderSuccess");
        }

        // Place order for existing user
        public ActionResult PlaceOrderExistingCustomer()
        {
            Customer emptyCustomer = new Customer();
            return View(emptyCustomer);
        }

        [HttpPost]
        public ActionResult PlaceOrderExistingCustomer(Customer submitCustomer)
        {
            Customer findCustomer = db.Customers.Where(eMail => eMail.EmailAddress == submitCustomer.EmailAddress).FirstOrDefault();

            if (findCustomer == null) // If email is not found, goto form for new user
            {
                return RedirectToAction("PlaceOrderNewCustomer");
            }

            ShoppingCart tempCart = Session["Cart"] as ShoppingCart;

            // Id, OrderDate, CustomerId
            Order newOrder = new Order();
            OrderRow newOrderRow;

            newOrder.OrderDate = DateTime.Now;
            newOrder.CustomerId = findCustomer.Id;
            db.Orders.Add(newOrder); // Create a new order entry
            db.SaveChanges();

            Order latestOrder = db.Orders.ToList().LastOrDefault();
            int latestOrderId = latestOrder.Id;

            // Id, OrderId, MovieId, Price
            foreach (Movie tempMovie in tempCart.MoviesInCart) // add movies from shopping cart to orderrows, one by one
            {
                newOrderRow = new OrderRow();
                newOrderRow.OrderId = latestOrderId;
                newOrderRow.MovieId = tempMovie.Id;
                newOrderRow.Price = tempMovie.Price;
                db.OrderRows.Add(newOrderRow);
            }

            db.SaveChanges();
            return RedirectToAction("PlaceOrderSuccess");
        }

        public ActionResult PlaceOrderSuccess()
        {
            // Clear cart when order is placed
            Session["Cart"] = null;
            InitCart();

            return View();
        }

        // Add another item to shopping cart
        public ActionResult AddItem(int? id)
        {
            ShoppingCart tempCart = Session["Cart"] as ShoppingCart;

            var item = tempCart.MoviesInCart.FirstOrDefault(x => x.Id == id);
            if (item != null)
                tempCart.MoviesInCart.Add(item);

            Session["Cart"] = tempCart;
            
            return View("ViewCart", tempCart.MoviesInCart);
        }

        // Remove item from shopping cart
        public ActionResult RemoveItem(int? id)
        {
            ShoppingCart tempCart = Session["Cart"] as ShoppingCart;

            var item = tempCart.MoviesInCart.FirstOrDefault(x => x.Id == id);
            if (item != null)
                tempCart.MoviesInCart.Remove(item);

            // Save changes
            Session["Cart"] = tempCart;

            return View("ViewCart", tempCart.MoviesInCart);
        }

        public void InitCart()
        {
            if (Session["Cart"] == null)
            {
                ShoppingCart tempCart = new ShoppingCart();
                tempCart.MoviesInCart = new List<Movie>();
                Session["Cart"] = tempCart;
            }
        }
    }
}