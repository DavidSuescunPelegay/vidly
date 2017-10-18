using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {name="Test"};
            var customers = new List<Customer>
            {
                new Customer {name = "Customer 1"},
                new Customer {name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                movie = movie,
                Customers = customers
            };

            //ViewData["RandomMovie"] = movie;
            //ViewBag.RandomMovie = movie;

            var viewResult=new ViewResult();
            //viewResult.ViewData.Model;

            return View(movie);

            //return View(movie);
            //return Content("Hello world");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy="name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //movies
        //int? hacer parametro nullable (opcional)
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}