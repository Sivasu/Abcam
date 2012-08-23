using System;
using System.Collections.Generic;

namespace VideoWorld.Models
{
    public class Cart
    {
        // private List<Rental> rentals = new List<Rental>();
		public Cart()
		{
			this.order = new Order();
		}

		public Order order { get; private set; }

        public bool Contains(Rental movie)
        {
            return this.order.Contains(movie);
        }

        public int Count
        {
			get { return this.order.Count(); }
        }

    	public void AddMovie(Movie movie, int period)
        {
            order.Add(new Rental(movie, period));
        }

		public void EmptyCart()
		{
			this.order = new Order();
		}
    }
}