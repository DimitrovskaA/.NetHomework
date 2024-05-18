using Homework_Task4_2;
using System.Reflection;

namespace RationalTests
{
	[TestClass]
	public class RatonalTest
	{
		[TestMethod]
		public void SumTest()
		{
			Rational r1 = new Rational(1, 2);
			Rational r2 = new Rational(1, 3);

			Rational result = r1 + r2;

			Assert.AreEqual(new Rational(5, 6), result);
		}

		[TestMethod]
		public void SubTest()
		{
			Rational r1 = new Rational(5, 6);
			Rational r2 = new Rational(1, 3);

			Rational result = r1 - r2;

			Assert.AreEqual(new Rational(1, 2), result);
		}

		[TestMethod]
		public void MulTets()
		{
			Rational r1 = new Rational(1, 2);
			Rational r2 = new Rational(2, 3);

			Rational result = r1 * r2;

			Assert.AreEqual(new Rational(1, 3), result);
		}

		[TestMethod]
		public void DivTest()
		{
			Rational r1 = new Rational(1, 2);
			Rational r2 = new Rational(3, 4);

			Rational result = r1 / r2;

			Assert.AreEqual(new Rational(2, 3), result);
		}

		[TestMethod]
		public void EqualsTestPositiveTest()
		{
			Rational r1 = new Rational(2, 6);
			Rational r2 = new Rational(1, 3); 

			Assert.IsTrue( r1.Equals(r2));
		}

		[TestMethod]
		public void EqualsTestNegativeTest()
		{
			Rational r1 = new Rational(2, 6);
			Rational r2 = new Rational(1, 2);
		
			Assert.IsFalse(r1.Equals(r2));

		}

		[TestMethod]
		public void CompareMethodLesserTest()
		{
			Rational r1 = new Rational(2, 6);
			Rational r2 = new Rational(3, 4);
			int result = r1.CompareTo(r2);

			Assert.IsTrue(result < 0);
		}

		[TestMethod]
		public void CompareMethodGreaterTest()
		{
			Rational r1 = new Rational(2, 6);
			Rational r3 = new Rational(5, 10);
			int result = r3.CompareTo(r1);
			Assert.IsTrue(result > 0);
		}

		[TestMethod]
		public void CompareMethodEqualTest()
		{
			Rational r1 = new Rational(2, 6);
			Rational r4 = new Rational(2, 6);
			int result = r1.CompareTo(r4);
			//Assert.IsTrue(result == 0);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ExplicitConversionToDoubleTest()
		{
			Rational r = new Rational(1, 2);
			double result = (double)r;
			Assert.AreEqual(0.5, result);
		}

		[TestMethod]
		public void ImplicitConversionFromIntTets()
		{
			int a = 5;
			Rational result = a;
			Assert.AreEqual(5, result.Numerator);
			Assert.AreEqual(1, result.Denominator);
		}

		[TestMethod]
		public void ToStringTest()
		{
			Rational r1= new Rational(1, 2);
			string result = r1.ToString();
			Assert.AreEqual("1/2", result);
		}
		
		[TestMethod]
		public void DivideByZeroExceptionTest()
		{
			try
			{
				Rational invalid = new Rational(1, 0);

				Assert.Fail("Expected ArgumentException was not thrown.");
			}
			catch (ArgumentException e)
			{
				Assert.AreEqual("Denominator cannot be zero.", e.Message);
			}
		}
	}
}