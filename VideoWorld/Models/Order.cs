// --------------------------------------------------------------------------------
// 	$Id: $
// --------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace VideoWorld.Models
{
	/// <summary></summary>
	public sealed class Order
	{
		/// <summary>Initializes a new instance of the <see cref="Order"/> class.</summary>
		public Order(IList<Rental> rentals)
		{
			this.Rentals = rentals;
			this.Points = this.Rentals.Sum(x => x.Points);
		}

		public int Points { get; private set; }

		public IList<Rental> Rentals { get; private set; }
	}
}
