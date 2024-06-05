namespace Homework_2_2
{
	public class DiagonalMatrix
	{
		public int[] diagonalElements;

		public int Size { get { return diagonalElements.Length; } }

		public DiagonalMatrix(params int[] elements)
		{
			if (elements == null)
			{
				diagonalElements = new int[0];
			}
			else
			{
				diagonalElements = new int[elements.Length];
				Array.Copy(elements, diagonalElements, elements.Length);
			}
		}
		// Indxer
		public int this[int i, int j]
		{
			get
			{
				if (i < 0 || j < 0 || i >= Size || j >= Size)
				{
					return 0; 
				}
				return i == j ? diagonalElements[i] : 0;
			}
			set
			{
				if (i < 0 || j < 0 || i >= Size || j >= Size)
				{
					throw new IndexOutOfRangeException("Indices are out of bounds.");
				}
				if (i == j)
				{
					diagonalElements[i] = value;
				}
			}
		}

		public int Track()
		{
			int sum = 0;
			for (int i = 0; i < Size; i++)
			{
				sum += diagonalElements[i];
			}
			return sum;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is DiagonalMatrix other) || other.Size != Size)
				return false;

			for (int i = 0; i < Size; i++)
			{
				if (diagonalElements[i] != other.diagonalElements[i])
					return false;
			}

			return true;
		}

		public override string ToString()
		{
			return $"DiagonalMatrix(Size={Size})";
		}
	}
}