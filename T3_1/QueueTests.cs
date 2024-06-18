using Homework_Task3_1;
namespace Homework_Task3_1Tests;

[TestClass]
public class QueueTest
{
	[TestMethod]
	public void EnqueueDequeueTest()
	{
		IQueue<int> queue = new Homework_Task3_1.Queue<int>();

		queue.Enqueue(1);
		queue.Enqueue(2);
		int dequeue1=queue.Dequeue();

		Assert.AreEqual(1, dequeue1);
	}

	[TestMethod]
	public void IsEmptyTest()
	{
		IQueue<int> queue = new Homework_Task3_1.Queue<int>();

		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Dequeue();
		queue.Dequeue();

		Assert.IsTrue(queue.IsEmpty());
	}

	[TestMethod]
	public void TailTest() 
	{
		IQueue<int> queue = new Homework_Task3_1.Queue<int>();
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);

		IQueue<int> tailQueue = queue.Tail();

		Assert.AreEqual(2, tailQueue.Dequeue());
		Assert.AreEqual(3, tailQueue.Dequeue());
	}
}