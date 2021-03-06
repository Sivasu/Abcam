﻿using System;
using System.Web.Mvc;
using VideoWorld.Models;

namespace VideoWorld.Controllers
{
    public class CartController : Controller
    {
        private readonly Customer customer;

        public CartController(Customer customer)
        {
            this.customer = customer;
        }

        [AcceptVerbs(HttpVerbs.Post), ActionName("Index")]
        public RedirectResult RentMovie(string title, int period, bool isNew, bool isChildrens)
        {
            customer.Cart.AddMovie(new Movie(title, isNew, isChildrens), period);
            return Redirect("/");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Index()
        {
            return View("Index", customer.Cart);
        }
    }
}