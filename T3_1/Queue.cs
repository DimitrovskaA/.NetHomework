namespace Homework_Task3_1
{
	public class Queue<T> : IQueue<T> where T: struct
	{
		private class Node
		{
			public T Data { get; }     
			public Node Next { get; set; }  

			public Node(T data)
			{
				Data = data;
				Next = null;  
			}
		}

		private Node front; 
		private Node back;  

		public void Enqueue(T item)
		{
			Node newNode = new Node(item);  
			if (IsEmpty())  
			{
				front = newNode; 
			}
			else
			{
				back.Next = newNode; 
			}
			back = newNode;  
		}
		public T Dequeue()
		{
			if (IsEmpty())  
			{
				throw new InvalidOperationException("Queue is empty");  
			}
			T dequeuedItem = front.Data;  
			front = front.Next;  

			if (front == null)  
			{
				back = null;  
			}
			return dequeuedItem;  
		}
		public bool IsEmpty()
		{
			return front == null; 
		}
	}
}
