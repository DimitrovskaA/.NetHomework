namespace Homework_Task4_2
{
	public sealed class Rational : IComparable<Rational>
	{
		public int Numerator { get; }
		public int Denominator { get; }
		public Rational(int numerator, int denominator)
		{
			if (denominator == 0)
				throw new ArgumentException("Denominator cannot be zero.");

			int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
			Numerator = numerator / gcd;
			Denominator = denominator / gcd;

			if (Denominator < 0)
			{
				Numerator = -Numerator;
				Denominator = -Denominator;
			}
		}
		private static int GreatestCommonDivisor(int a, int b)
		{
			while (b != 0)
			{
				int temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}
		public override bool Equals(object? obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			Rational other = (Rational)obj;
			return Numerator == other.Numerator && Denominator == other.Denominator;
		}
		public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
		public override string ToString()=> $"{Numerator}/{Denominator}";

		public int CompareTo(Rational? other)
		{
			if (other == null)
				return 1;

			double decimalValueThis = (double)Numerator / Denominator;
			double decimalValueOther = (double)other.Numerator / other.Denominator;

			return decimalValueThis.CompareTo(decimalValueOther);
		}
		public static Rational operator +(Rational r1, Rational r2) => new Rational(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator,r1.Denominator * r2.Denominator);
		public static Rational operator -(Rational r1, Rational r2)=> new Rational(r1.Numerator* r2.Denominator - r2.Numerator* r1.Denominator,r1.Denominator* r2.Denominator);
		public static Rational operator *(Rational r1, Rational r2) => new Rational(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
		public static Rational operator /(Rational r1, Rational r2) =>  new Rational(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);

		
		public static explicit operator double(Rational r)=> (double) r.Numerator / r.Denominator;
	
		public static implicit operator Rational(int value) => new Rational(value, 1);
	}

}
