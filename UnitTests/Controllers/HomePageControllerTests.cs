using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using VideoWorld.Controllers;
using VideoWorld.Models;

namespace UnitTests.Controllers
{
    public class HomePageControllerTests
    {
        private HomePageController controller;
        private Customer customer;

        [SetUp]
        public void SetUp()
        {
            var mockRepo = new Mock<MovieRepository>();
            var movies = new List<Movie>
                             {
                                 new Movie("Avatar"),
                                 new Movie("Up in the Air"),
                                 new Movie("Finding Nemo"),
                                 new Movie("Ping Pong")
                             };
            mockRepo.Setup(repo => repo.FindAllMovies()).Returns(movies);
            customer = new Customer("John Smith");
            controller = new HomePageController(customer, mockRepo.Object);
        }

        [Test]
        public void ShouldShowIndexView()
        {
            ViewResult result = controller.Index();
            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void ViewShouldShowAListOfMovies()
        {
            ViewResult result = controller.Index();
            var model = (HomePageModel) result.Model;
            List<Movie> movies = model.Movies;
            Assert.That(movies.Count, Is.EqualTo(4));
        }

        [Test]
        public void ModelShouldIncludeCart()
        {
            ViewResult result = controller.Index();
            var model = (HomePageModel) result.Model;
            Assert.That(model.Cart, Is.SameAs(customer.Cart));
        }
    }
}