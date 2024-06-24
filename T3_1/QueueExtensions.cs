namespace Homework_Task3_1
{
	public static class QueueExtensions
	{
		public static IQueue<T> Tail<T>(this IQueue<T> queue) where T : struct
		{
			IQueue<T> tailQueue = new Queue<T>();
			IQueue<T> tempQueue = new Queue<T>();

			if (!queue.IsEmpty())
			{
				queue.Dequeue(); 
				while (!queue.IsEmpty())
				{
					T item = queue.Dequeue();
					tailQueue.Enqueue(item);
					tempQueue.Enqueue(item);
				}

				while (!tempQueue.IsEmpty())
				{
					queue.Enqueue(tempQueue.Dequeue());
				}
			}
			return tailQueue;
		}
	}
}
