using System.Collections;
using System.Text;
namespace Homework_5_1
{
	public class SparseMatrix : IEnumerable<long>
	{
		private Dictionary<(int, int), long> _matrix;
		private int _rows;
		private int _columns;

		public SparseMatrix(int rows, int columns)
		{
			if (rows <= 0 || columns <= 0)
				throw new ArgumentException("Rows and columns must be greater than zero.");

			_rows = rows;
			_columns = columns;
			_matrix = new Dictionary<(int, int), long>();
		}

		public long this[int i, int j]
		{
			get
			{
				if (i < 0 || i >= _rows || j < 0 || j >= _columns)
					throw new IndexOutOfRangeException("Index out of range.");

				_matrix.TryGetValue((i, j), out long value);
				return value;
			}
			set
			{
				if (i < 0 || i >= _rows || j < 0 || j >= _columns)
					throw new IndexOutOfRangeException("Index out of range.");

				if (value != 0)
					_matrix[(i, j)] = value;
				else if (_matrix.ContainsKey((i, j)))
					_matrix.Remove((i, j));
			}
		}

		public IEnumerator<long> GetEnumerator()
		{
			for (int i = 0; i < _rows; i++)
			{
				for (int j = 0; j < _columns; j++)
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
			var sortedKeys = _matrix.Keys.OrderBy(key => key.Item2).ThenBy(key => key.Item1);
			foreach (var key in sortedKeys)
			{
				yield return (key.Item1, key.Item2, _matrix[key]);
			}
		}

		public int GetCount(long x)
		{
			if (x != 0)
			{
				int count = 0;
				foreach (var value in _matrix.Values)
				{
					if (value == x)
						count++;
				}
				return count;
			}
			else
			{
				return (_rows * _columns) - _matrix.Count;
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < _rows; i++)
			{
				for (int j = 0; j < _columns; j++)
				{
					sb.Append(this[i, j] + "\t");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}