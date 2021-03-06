﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using UnitTests.Models;
using VideoWorld.Controllers;
using VideoWorld.Models;

namespace UnitTests.Controllers
{
    class CartControllerTests
    {
        [Test]
        public void ShouldredirectToHomePageWhenAMovieIsAdded()
        {
            var controller = new CartController(new Customer("John Smith"));

            RedirectResult result = controller.RentMovie("Avatar", 1, false, false);
            Assert.That(result.Url, Is.EqualTo("/"));
        }

        [Test]
        public void ShouldAddMovieToCart()
        {
            var customer = new Customer("John Smith");
            var controller = new CartController(customer);
			controller.RentMovie("Avatar", 1, false, false);
            IList<Rental> rentals = customer.Cart.order.Rentals;
            Assert.That(rentals.Any(r => r.Movie.Title == "Avatar"));
        }

        [Test]
        public void ShouldCreateRentalForOneDay()
        {
            var customer = new Customer("John Smith");
            var controller = new CartController(customer);
			controller.RentMovie("Avatar", 1, false, false);
            IList<Rental> rentals = customer.Cart.order.Rentals;
            Assert.That(rentals.First(r => r.Movie.Title == "Avatar").Period, Is.EqualTo(1));
        }


        [Test]
        public void ShouldCountMultipleMovies()
        {
            var customer = new Customer("John Smith");
            var controller = new CartController(customer);
			controller.RentMovie("Avatar", 1, false, false);
            Assert.That(customer.Cart.Count, Is.EqualTo(1));
			controller.RentMovie("Waterworld", 1, false, false);
            Assert.That(customer.Cart.Count, Is.EqualTo(2));
        }

        [Test]
        public void IndexShouldShowCurrentCart()
        {
            var customer = new Customer("John Smith");
            var controller = new CartController(customer);
            ViewResult result = controller.Index();
            Assert.That(result.Model, Is.SameAs(customer.Cart));
        }
    }
}
