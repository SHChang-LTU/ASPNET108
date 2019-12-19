using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNET108.Models;
using ASPNET108.ViewModels;

namespace ASPNET108.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New(int id)
        {

            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();


            // 該顧客所租借的影片
            var customerRentedMovies =
                _context.Rentals
                    .Where(c => c.CustomerId == id)
                    .Select(x => x.Movie).ToList();

            RentalViewModel rentalViewModel = new RentalViewModel
            {
                Customer = customer,
                CustomerMovies = customerRentedMovies
            };


            return View(rentalViewModel);
        }

        public ActionResult CartAdd(int id)
        {
            // Using List<Movie> will cause problems when
            // doing List.Remove()
            if (Session["cart"] == null)
                Session["cart"] = new Dictionary<int, string>();

            var moviesInCart = Session["cart"] as Dictionary<int, string>;

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviesInCart != null && movie != null)
                moviesInCart.Add(movie.Id, movie.Name);

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult CartRemove(int id)
        {
            if (Session["cart"] == null)
                Session["cart"] = new Dictionary<int, string>();

            var moviesInCart = Session["cart"] as Dictionary<int, string>;

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviesInCart != null && movie != null)
                moviesInCart.Remove(movie.Id);

            return RedirectToAction("Index", "Movies");
        }
    }
}