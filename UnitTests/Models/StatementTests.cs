// -----------------------------------------------------------------------
// <copyright file="StatementTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class StatementTests
	{
		[Test]
		public void GetTotalShouldReturnTheValueOfAllRentals()
		{
			var rentals = new List<Rental>() {new Rental(new Movie("Jaws"), 7), new Rental(new Movie("Snakes"), 2)};
			var order = new Order(rentals);
			var statement = new Statement(order, new Customer());
			Assert.AreEqual(9, statement.GetTotalValue());
		}
	}
}
