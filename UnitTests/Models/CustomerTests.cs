using System.Collections.Generic;
using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
    internal class CustomerTests
    {
        [Test]
        public void Empty()
        {
            var customer = new Customer("John Smith");
        	var order = new Order();
        	var statement = new Statement(order, customer);
            const string noRentalsStatement = "Rental Record for John Smith\n"
                                              + "Amount charged is $0.00\n";
            Assert.AreEqual(noRentalsStatement, statement.Text);
        }

		[Test]
		public void AnEmptyRentalRecordShouldHaveATotalAmountOfZero()
		{
			var customer = new Customer("John Smith");
			var order = new Order();
			var statement = new Statement(order, customer); 
			Assert.AreEqual(statement.TotalAmount(order.Rentals), 0.00);
		} 
    }
}