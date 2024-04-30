namespace Homework_2_1
{
	public class Program
	{
		static void Main(string[] args)
		{
			ThreeDPointWithMass point1 = new ThreeDPointWithMass();
			point1.X = 1;
			point1.Y = 2;
			point1.Z = 3;
			point1.Mass = 4;

			ThreeDPointWithMass point2 = new ThreeDPointWithMass();
			point2.X = 5;
			point2.Y = 6;
			point2.Z = 7;
			point2.Mass = -8;

			ThreeDPointWithMass point3 = new ThreeDPointWithMass();
			point3.X = 0;
			point3.Y = 0;
			point3.Z = 0;
			point3.Mass = 12;

            Console.WriteLine($"Cordinates for Point1: X = {point1.X}  Y = {point1.Y}  Z = {point1.Z} Mass: {point1.Mass}");
			Console.WriteLine($"Cordinates for Point2: X = {point2.X}  Y = {point2.Y}  Z = {point2.Z} Mass: {point2.Mass}");
			Console.WriteLine($"Cordinates for Point3: X = {point3.X}  Y = {point3.Y}  Z = {point3.Z} Mass: {point3.Mass}\n");

            Console.WriteLine($"Distance between Point1 and Point2 is: {point1.DistanceTo(point2)}");
			Console.WriteLine($"Distance between Point1 and Point3 is: {point1.DistanceTo(point3)}");
			Console.WriteLine($"Distance between Point2 and Point3 is: {point2.DistanceTo(point3)}\n");;

            Console.WriteLine($"Is Point1 at coordinates (0, 0, 0) ? {point1.IsZero()}");
			Console.WriteLine($"Is Point2 at coordinates (0, 0, 0) ? {point2.IsZero()}");
			Console.WriteLine($"Is Point3 at coordinates (0, 0, 0) ? {point3.IsZero()}");
		}
	}
}