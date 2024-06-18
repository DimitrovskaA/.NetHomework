
namespace Homework_Task3_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IQueue<int> queue = new Queue<int>();

			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
			queue.Enqueue(4);
			queue.Enqueue(5);

			Console.Write("Old Queue: ");
			IQueue<int> tempQueue = new Queue<int>();
			while (!queue.IsEmpty())
			{
				int element = queue.Dequeue();
				tempQueue.Enqueue(element);
				Console.Write(element + "\t");
			}

			queue = tempQueue;

			IQueue<int> tailQueue = queue.Tail();

			Console.Write("\nNew Queue: ");
			while (!tailQueue.IsEmpty())
			{
				Console.Write(tailQueue.Dequeue() + "\t");
			}
		}
	}
}
