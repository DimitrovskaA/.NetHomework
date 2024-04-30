using Homework_2_1;
namespace ThreeDPointWithMassTests
{
	[TestClass]
	public class ThreeDPointWithMassTests
	{
		[TestMethod]
		public void MassValidationPositive()
		{
			ThreeDPointWithMass point = new ThreeDPointWithMass();
			point.Mass = 1;
			Assert.AreEqual(1, point.Mass);
		}

		[TestMethod]
		public void MassValidationNegative()
		{
			ThreeDPointWithMass point = new ThreeDPointWithMass();
			point.Mass = -4;
			Assert.AreEqual(0, point.Mass);
		}
		[TestMethod]
		public void IsZeroTest()
		{
			ThreeDPointWithMass point = new ThreeDPointWithMass();
			point.X = 0;
			point.Y = 0;
			point.Z = 0;
			Assert.IsTrue(point.IsZero());
		}
		[TestMethod]
		public void IsNotZeroTest()
		{
			ThreeDPointWithMass point = new ThreeDPointWithMass();
			point.X = 1;
			point.Y = -2;
			point.Z = 7;
			Assert.IsFalse(point.IsZero());
		}
		[TestMethod]
		public void DistanceToValidationTest()
		{
			ThreeDPointWithMass point1 = new ThreeDPointWithMass { X = 1, Y = 2, Z = 3 };
			ThreeDPointWithMass point2 = new ThreeDPointWithMass { X = 5, Y = 6, Z = 7 };

			Assert.AreEqual(6.928, point1.DistanceTo(point2), 0.001);
		}
		[TestMethod]
		public void GettersAndSettersValidationTest()
		{
			ThreeDPointWithMass point = new ThreeDPointWithMass();
			point.X = 1;
			point.Y = 5;
			point.Z = 17;
			point.Mass = 4;

			Assert.AreEqual(1, point.X);
			Assert.AreEqual(5, point.Y);
			Assert.AreEqual(17, point.Z);
			Assert.AreEqual(4, point.Mass);
		}
	}
}