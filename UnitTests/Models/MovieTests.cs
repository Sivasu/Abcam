﻿using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
    public class MovieTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void ShouldRequireTitle(string invalidTitle)
        {
            Assert.That(() => new Movie(invalidTitle), Throws.Exception);
        }

        [Test]
        public void ShouldContainTitle()
        {
            var movie = new Movie("Avatar");
            Assert.That(movie.Title, Is.EqualTo("Avatar"));
        }

        [Test]
        public void ShouldCalculateRentalForNewMovies()
        {
            Assert.That(new Movie("Deli Belly", Movie.NEW_MOVIE_PRICING_STRATEGY).GetCharge(3),Is.EqualTo(6m));
        }

		[Test]
		public void EnsureThatIfAMovieIsNewItsDisplayNameHasNewAppended()
		{
			var model = new Movie("Jaws", true);
			Assert.AreEqual("Jaws *new", model.GetDisplayName());

		}

		[Test]
		public void EnsureThatIfAMoveIsNotNewItsDisplayNameIsItsTitle()
		{
			var model = new Movie("Jaws", false);
			Assert.AreEqual(model.Title, model.GetDisplayName());
		}

		[Test]
		public void Ensure_that_a_childs_movie_has_Childrens_in_its_display_name()
		{
			var model = new Movie("A childs movie", false, true);
			Assert.AreEqual("A childs movie *childrens", model.GetDisplayName());
		}

		[Test]
		public void Ensure_that_a_new_childs_movie_has_new_and_childrens_in_its_display_name()
		{
			var model = new Movie("A new childs movie", true, true);
			Assert.AreEqual("A new childs movie *new *childrens", model.GetDisplayName());
		}
    }
}