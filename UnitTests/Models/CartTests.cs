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
			var order = cart.order;

			cart.EmptyCart();
			
			Assert.AreNotSame(cart.order, order);
		}
	}
}
