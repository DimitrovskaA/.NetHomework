namespace Homework_Task3_1
{
	public interface IQueue <T>
	{ 
		void Enqueue(T item); 
		T Dequeue(); 
		bool IsEmpty(); 
	}
}
