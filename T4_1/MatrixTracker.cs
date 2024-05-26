
namespace Homework_4_1
{
	public class MatrixTracker<T>
	{
		private readonly DiagonalMatrix<T> matrix;
		private readonly Stack<(int, T)> changes = new Stack<(int, T)>();

		public MatrixTracker(DiagonalMatrix<T> matrix)
		{
			this.matrix = matrix;
			matrix.ElementChanged += Matrix_ElementChanged;
		}

		private void Matrix_ElementChanged(object sender, ElementChangedEventArgs<T> e)
		{
			changes.Push((e.Index, e.OldValue));
		}

		public void Undo()
		{
			if (changes.Count > 0)
			{
				var (index, oldValue) = changes.Pop();
				matrix[index, index] = oldValue;


				matrix.ElementChanged -= Matrix_ElementChanged;
				matrix[index, index] = oldValue;
				matrix.ElementChanged += Matrix_ElementChanged;
			}
		}
	}
}
