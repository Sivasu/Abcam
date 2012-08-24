using System;
using System.Collections.Generic;
using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
    internal class CustomerTests
    {
		[Test]
		public void AnEmptyRentalRecordShouldHaveATotalAmountOfZero()
		{
			var customer = new Customer("John Smith");
			var order = new Order();
			var statement = new Statement(order, customer); 
			Assert.AreEqual(statement.TotalAmount(order.Rentals), 0.00);
		}
 
		[Test]
		public void When_The_Points_Spent_Is_More_Than_The_Points_Earnt_An_Exception_Is_Thrown()
		{
			// Arrange
			var customer = new Customer();
			customer.PointsEarned = 5;
			customer.PointsSpent = 10;

			//Assert
			Assert.Throws(typeof (ArgumentOutOfRangeException), () => customer.GetPointsBalance());
		}

		[Test]
		public void The_Balance_Is_Equal_To_The_Number_Of_Points_Earnt_Minus_Number_Of_Points_Spent()
		{
			//Arrange
			var customer = new Customer();
			customer.PointsEarned = 5;
			customer.PointsSpent = 3;

			//Act
			var result = customer.GetPointsBalance();

			//Assert
			Assert.AreEqual(2, result);
		}
    }
}