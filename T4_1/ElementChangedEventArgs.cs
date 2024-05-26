
namespace Homework_4_1
{
	public class ElementChangedEventArgs<T>:EventArgs
	{
		public int Index { get; }
		public T OldValue { get; }
		public T NewValue { get; }

		public ElementChangedEventArgs(int index, T oldValue, T newValue)
		{
			Index = index;
			OldValue = oldValue;
			NewValue = newValue;
		}
	}
}
