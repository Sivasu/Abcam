using System;
using System.Collections.Generic;

namespace VideoWorld.Models
{
    public class Cart
    {
        private List<Rental> rentals = new List<Rental>();

        public bool Contains(Rental movie)
        {
            return rentals.Contains(movie);
        }

        public int Count
        {
            get { return rentals.Count; }
        }

		public List<Rental> Rentals
		{
			get
			{
				return rentals;
			}
			set { rentals = value; }
		}

    	public void AddMovie(Movie movie, int period)
        {
            rentals.Add(new Rental(movie, period));
        }

		public void EmptyCart()
		{
			this.Rentals = new List<Rental>();
		}
    }
}