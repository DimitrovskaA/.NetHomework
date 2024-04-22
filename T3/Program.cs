namespace Homework_Task1_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the numbers of the array:");
			int num=int.Parse(Console.ReadLine());

			int[] array = new int[num];

			for(int i=0; i<num; i++)
			{
				Console.WriteLine($"Enter {i + 1} element: ");
				array[i] = int.Parse(Console.ReadLine());
			}

            Console.Write("Original array: ");
			PrintArray(array);

			int [] newArray =SortedArray(array);
            Console.WriteLine(	);
            Console.Write("New array based on the principle Each Value - Only Once: ");
			PrintArray( newArray );
			Console.ReadKey();
        }
		static int [] SortedArray(int[] array)
		{
			int length=array.Length;
			for(int i=0 ; i<length; i++)
			{
				for(int j=i+1; j<length; j++)
				{
					if (array[i] == array[j])
					{
						for (int k = j; k < length - 1; k++)
						{
							array[k] = array[k + 1];
						}
						length--;
						j--;

					}
				}
			}
			int[] uniqueArray = new int[length];
			Array.Copy(array, uniqueArray, length);
			return uniqueArray;
		}
		static void PrintArray(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i] + " ");
			}
		}
	}
}