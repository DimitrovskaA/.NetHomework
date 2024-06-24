namespace Homework_2_1
{
	public class ThreeDPointWithMass
	{
		private int[] _3D = new int[3];
		private double mass;
		public int X
		{
			get { return _3D[0]; }
			set { _3D[0] = value; }
		}
		public int Y
		{
			get { return _3D[1]; }
			set { _3D[1] = value; }
		}
		public int Z
		{
			get { return _3D[2]; }
			set { _3D[2] = value; }
		}
		public double Mass
		{
			get
			{ return mass; }
			set
			{
				if (value > 0)
				{
					mass = value;
				}
				else
					mass = 0;
			}
		}
		
		public bool IsZero() => X == 0 && Y == 0 && Z == 0;

		public double DistanceTo(ThreeDPointWithMass obj)
		{
			int x2=obj.X;
			int y2=obj.Y;
			int z2=obj.Z;

			float distanceX = X-x2;
			float distanceY = Y- y2;
			float distanceZ = Z -z2;

			double finalResult= Math.Sqrt(Math.Pow(distanceX,2) + Math.Pow(distanceY,2) + Math.Pow(distanceZ,2));

			return finalResult;
		}
	}
}
