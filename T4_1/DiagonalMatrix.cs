namespace Homework_4_1
{
	public class DiagonalMatrix<T>
	{
		public T[] diagonalElements;
		public int Size { get; }

		public DiagonalMatrix(int size)
		{
			if (size < 0)
			{
				throw new ArgumentException("Size cannot be negative.");
			}
			Size = size;
			diagonalElements = new T[size];
		}
		// Indxer
		public T this[int i, int j]
		{
			get
			{
				if (i < 0 || j < 0 || i >= Size || j >= Size)
				{
					throw new IndexOutOfRangeException("Indices are out of bounds.");
				}
				return i == j ? diagonalElements[i] : default;
			}
			set
			{
				if (i < 0 || j < 0 || i >= Size || j >= Size)
				{
					throw new IndexOutOfRangeException("Indices are out of bounds.");
				}
				if (i == j)
				{
					var oldValue = diagonalElements[i];
					if (!EqualityComparer<T>.Default.Equals(oldValue, value))
					{
						diagonalElements[i] = value;
						OnElementChanged(new ElementChangedEventArgs<T>(i, oldValue, value));
					}
				}
			}
		}
		public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

		protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
		{
			ElementChanged?.Invoke(this, e);
		}
	}
}