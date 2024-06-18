namespace Homework_Task3_1
{
	public static class QueueExtensions
	{
		public static IQueue<T> Tail<T>(this IQueue<T> queue)
		{
			IQueue<T> tailQueue = new Queue<T>();

			if (!queue.IsEmpty())
			{
				queue.Dequeue();
				while (!queue.IsEmpty())
				{
					tailQueue.Enqueue(queue.Dequeue());
				}
			}
			return tailQueue;
		}
	}
}
