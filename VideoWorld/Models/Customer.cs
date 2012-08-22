using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace VideoWorld.Models
{
    public class Customer
    {
        private readonly Cart cart = new Cart();

        public Customer(string name)
        {
            Name = name;
        }

        [Inject]
        public Customer()
        {
            Name = "Unknown Customer";
        }

        public Cart Cart
        {
            get { return  cart; }
        }

        public string Name { get; private set; } 
    }
}