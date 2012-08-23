namespace VideoWorld.Models
{
    public class Rental
    {
        private readonly Movie movie;
        private readonly int periodInDays;

        public Rental(Movie movie, int periodInDays)
        {
            this.movie = movie;
            this.periodInDays = periodInDays;
        	this.Points = 1;
        	this.NumberOfFreeDays = 0;

			if (movie.IsNew)
			{
				NumberOfFreeDays = NumberOfFreeDays + ((periodInDays > 6) ? 1 : 0);
			}
			if (!movie.IsNew)
			{
				NumberOfFreeDays = NumberOfFreeDays + periodInDays/3;
			}
			if (movie.IsChildrens)
			{
				NumberOfFreeDays = NumberOfFreeDays + periodInDays/2;
			}
        }

        public Movie Movie
        {
            get { return movie; }
        }

        public int Period
        {
            get { return periodInDays; }
        }

    	public int NumberOfFreeDays;

    	public int Points;
    }
}