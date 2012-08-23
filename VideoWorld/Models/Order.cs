// --------------------------------------------------------------------------------
// 	$Id: $
// --------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoWorld.Models
{
	/// <summary></summary>
	public sealed class Order
	{

		/// <summary>Initializes a new instance of the <see cref="Order"/> class.</summary>
		public Order()
		{
			this.Rentals = new List<Rental>();
		}

		public int GetPoints()
		{
			return this.Rentals.Sum(m => m.Points);
		}

		public int Count()
		{
			return this.Rentals.Count;
		}

		public IList<Rental> Rentals { get; private set; }

		public bool Contains(Rental movie)
		{
			return this.Rentals.Contains(movie);
		}

		public void Add(Rental rental)
		{
			this.Rentals.Add(rental);
		}
	}
}
