using System;

namespace Homework_Task1_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the numbers of the array:");
			int num = int.Parse(Console.ReadLine());

			int[] array = new int[num];

			for (int i = 0; i < num; i++)
			{
				Console.WriteLine($"Enter {i + 1} element: ");
				array[i] = int.Parse(Console.ReadLine());
			}

			Console.Write("Original array: ");
			PrintArray(array);

			int[] newArray = EachValueOnlyOnce(array);
			Console.WriteLine();
			Console.Write("New array based on the principle Each Value - Only Once: ");
			PrintArray(newArray);
			Console.ReadKey();
		}

		
		static int[] EachValueOnlyOnce(int[] array)
		{
			int[] uniqueArray = new int[array.Length];
			int uniqueIndex = 0;

			for (int i = 0; i < array.Length; i++)
			{
				bool isDuplicate = false;

				// Check if the current element is a duplicate
				for (int j = 0; j < uniqueIndex; j++)
				{
					if (array[i] == uniqueArray[j])
					{
						isDuplicate = true;
						break;
					}
				}

				// If not a duplicate, add it to the unique array
				if (!isDuplicate)
				{
					uniqueArray[uniqueIndex] = array[i];
					uniqueIndex++;
				}
			}

			// Resize the unique array to remove unused slots
			Array.Resize(ref uniqueArray, uniqueIndex);

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
