using System.Collections.Generic;
using System.Web.Mvc;
using VideoWorld.Models;

namespace VideoWorld.Controllers
{
    public class HomePageController : Controller
    {
        private readonly Customer customer;
        private readonly MovieRepository movieRepository;

        public HomePageController(Customer customer, MovieRepository movieRepository)
        {
            this.customer = customer;
            this.movieRepository = movieRepository;
        }

        public ViewResult Index()
        {
            List<Movie> movies = movieRepository.FindAllMovies();
            return View("Index", new HomePageModel(movies, customer));
        }
    }
}