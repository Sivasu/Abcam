using System.Collections.Generic;
using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
    public class MovieRepositoryTests
    {
        [Test]
        public void ShouldHaveThreeMovies()
        {
            var repository = new MovieRepository();
            List<Movie> movies = repository.FindAllMovies();
            Assert.AreEqual(4, movies.Count);
        }

    }
}