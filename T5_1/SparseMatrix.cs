using System.Collections;
using System.Text;
namespace Homework_5_1
{
	public class SparseMatrix : IEnumerable<long>
	{
		private Dictionary<(int, int), long> matrix;
		private int rows;
		private int columns;

		public SparseMatrix(int rows, int columns)
		{
			if (rows <= 0 || columns <= 0)
				throw new ArgumentException("Rows and columns must be greater than zero.");

			this.rows = rows;
			this.columns = columns;
			matrix = new Dictionary<(int, int), long>();
		}

		public long this[int i, int j]
		{
			get
			{
				if (i < 0 || i >= rows || j < 0 || j >= columns)
					throw new IndexOutOfRangeException("Index out of range.");

				return matrix.ContainsKey((i, j)) ? matrix[(i, j)] : 0;
			}
			set
			{
				if (i < 0 || i >= rows || j < 0 || j >= columns)
					throw new IndexOutOfRangeException("Index out of range.");

				if (value != 0)
					matrix[(i, j)] = value;
				else if (matrix.ContainsKey((i, j)))
					matrix.Remove((i, j));
			}
		}

		public IEnumerator<long> GetEnumerator()
		{
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					yield return this[i, j];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerable<(int, int, long)> GetNonzeroElements()
		{
			var sortedKeys = matrix.Keys.OrderBy(key => key.Item2).ThenBy(key => key.Item1);
			foreach (var key in sortedKeys)
			{
				yield return (key.Item1, key.Item2, matrix[key]);
			}
		}

		public int GetCount(long x)
		{
			if (x != 0)
			{
				int count = 0;
				foreach (var value in matrix.Values)
				{
					if (value == x)
						count++;
				}
				return count;
			}
			else
			{
				return (rows * columns) - matrix.Count;
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					sb.Append(this[i, j] + "\t");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}