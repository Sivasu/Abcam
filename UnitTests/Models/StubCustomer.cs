using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoWorld.Models;

namespace UnitTests.Models
{
	class StubCustomer : Customer
	{
		public int GetPointsEarned()
		{
			return PointsEarned;
		}

		public void SetPointsEarned(int points)
		{
			base.PointsEarned = points;
		}
	}
}
