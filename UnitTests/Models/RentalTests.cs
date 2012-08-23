// --------------------------------------------------------------------------------
// 	$Id: $
// --------------------------------------------------------------------------------
using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
	/// <summary></summary>
	public sealed class RentalTests
	{
		/// <summary>Initializes a new instance of the <see cref="RentalTests"/> class.</summary>
		public RentalTests()
		{
		}

		[Test]
		public void EnsureCustomersAreNotChargedForFreeDays()
		{
			var periodInDays = 7;
			var movie = new Movie("Hook", true);
			Assert.AreEqual(7, movie.GetCharge(periodInDays));
		}

		[Test]
		public void EnsureRentalsOfRegularMoviesReceiveOneFreeDayForEveryThreeDays()
		{
			var movie = new Movie("Hook", false);
			var model = new Rental(movie, 7);
			Assert.AreEqual(2, model.NumberOfFreeDays);
		}

		[Test]
		public void EnsureRentalsOfNewMoviesReceiveOneFreeDayForPeriodsOverSixDays()
		{
			var movie = new Movie("Hook", true);
			var model = new Rental(movie, 7);
			Assert.AreEqual(1, model.NumberOfFreeDays);
		}

		[Test]
		public void For_A_Childrens_Release_Every_three_day_rentals_get_two_additional_days_free()
		{
			var isNewMovie = false;
			var isChildrensMovie = true;

			var childsMovie = new Movie("A Childrens Movie", isNewMovie, isChildrensMovie);
			var model = new Rental(childsMovie, 2);
			Assert.AreEqual(1, model.NumberOfFreeDays);
		}
	}
}
