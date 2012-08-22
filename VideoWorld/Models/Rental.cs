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

			if (movie.IsNew)
			{
				NumberOfFreeDays = (periodInDays > 6) ? 1 : 0;
			}
			else
			{
				NumberOfFreeDays = periodInDays/3;
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