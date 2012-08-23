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
			this.Text = GetText();
		}

		public Order Order { get; private set; }

		public Customer Customer { get; private set; }

		public string Text { get; private set; }

		public string GetText()
		{
			return PrintHeader() + PrintBody(this.Order.Rentals) + PrintFooter(this.Order.Rentals);
		}

		private string PrintHeader()
		{
			return "Rental Record for " + Customer.Name + "\n";
		}

		private string PrintFooter(IList<Rental> newRentals)
		{
			return "Amount charged is $" + String.Format("{0:0.00}", TotalAmount(newRentals)) + "\n";
		}

		private static string PrintDays(Rental rental)
		{
			return " Days rented: " + rental.Period + " Free days: " + rental.NumberOfFreeDays;
		}

		private static string PrintBody(IList<Rental> newRentals)
		{
			string localResult = string.Empty;
			foreach (Rental rental in newRentals)
			{
				int rentalDays = rental.Period;
				localResult += "  " + rental.Movie.Title + "  -  $"
						  + rental.Movie.GetCharge(rentalDays)
						  + PrintDays(rental) + "\n";
			}
			return localResult;
		}

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