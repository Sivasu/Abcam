// -----------------------------------------------------------------------
// <copyright file="CartTests.cs" company="Microsoft">
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
	public class CartTests
	{
		[Test]
		public void EnsureClearCartCreatesANewListOfRentals()
		{
			var cart = new Cart();
			cart.AddMovie(new DummyMovie(), 7);
			var rentals = cart.Rentals;
			cart.EmptyCart();
			Assert.AreNotSame(cart.Rentals, rentals);
		}
	}

	public class DummyMovie : Movie
	{
		public DummyMovie()
			: base("title")
		{
		}
	}
}
