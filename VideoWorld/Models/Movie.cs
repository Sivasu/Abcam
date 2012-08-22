using System;

namespace VideoWorld.Models
{
    public class Movie
    {
        private readonly string title;
        private readonly IPrice pricingStrategy;
        public static IPrice REGULAR_MOVIE_PRICING_STRATEGY = new RegularPricingStrategy();
        public static IPrice NEW_MOVIE_PRICING_STRATEGY = new NewMoviePricingStrategy();

    	public bool IsNew;
		
		public Movie(string title) : this(title, Movie.REGULAR_MOVIE_PRICING_STRATEGY)
        {
        }

		public Movie(string title, bool isNew) : this(title, Movie.REGULAR_MOVIE_PRICING_STRATEGY)
		{
			this.title = title;
			this.IsNew = isNew;
		}

        public Movie(string title, IPrice pricingStrategy)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");
            }

            this.title = title;
            this.pricingStrategy = pricingStrategy;
        }

        public bool Equals(Movie other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.title, title);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Movie)) return false;
            return Equals((Movie) obj);
        }

        public override int GetHashCode()
        {
            return (title != null ? title.GetHashCode() : 0);
        }



        public string Title
        {
            get { return title; }
        }

        public decimal GetCharge(int rentalDays)
        {
            return pricingStrategy.GetCharge(rentalDays);
        }

        private class RegularPricingStrategy:IPrice
        {
            public decimal GetCharge(int rentalDays)
            {
                return rentalDays*1.00m;
            }
        }

        private class NewMoviePricingStrategy : IPrice
        {
            public decimal GetCharge(int rentalDays)
            {
                return rentalDays*2.00m;
            }
        }

    	public string GetDisplayName()
    	{
			if(IsNew)
			{
				return title + " *new";
			}
    		return title;
    	}
    }

    public interface IPrice
    {
        decimal GetCharge(int rentalDays);
    }
}