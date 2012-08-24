using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoWorld.Models
{
	public class Statement
	{
		public Statement(Order order, Customer customer)
		{
			this.Order = order;
			this.Customer = customer;
		}

		public Order Order { get; private set; }

		public Customer Customer { get; private set; }

		public decimal TotalAmount(IList<Rental> newRentals)
		{
			return newRentals.Sum(newRental => newRental.Movie.GetCharge(newRental.Period));
		}

		public double GetTotalValue()
		{
			return (double)this.Order.Rentals.Sum(x => x.Movie.GetCharge(x.Period));
		}
	}
}