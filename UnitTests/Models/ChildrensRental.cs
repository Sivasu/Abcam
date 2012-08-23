using VideoWorld.Models;

namespace UnitTests.Models
{
	public class ChildrensRental : Rental
	{
		public ChildrensRental() : base(new ChildrensDummyMovie(), 3)
		{
			
		}
	}
}