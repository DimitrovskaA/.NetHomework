using Homework_2_2;
public static class DiagonalMatrixExtensions
{
	public static DiagonalMatrix Add(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
	{
		int maxSize = Math.Max(matrix1.Size, matrix2.Size);

		int[] diagonal1 = new int[maxSize];
		int[] diagonal2 = new int[maxSize];

		for (int i = 0; i < maxSize; i++)
		{
			if (i < matrix1.Size)
			{
				diagonal1[i] = matrix1[i, i];
			}
			else
			{
				diagonal1[i] = 0;
			}

			if (i < matrix2.Size)
			{
				diagonal2[i] = matrix2[i, i];
			}
			else
			{
				diagonal2[i] = 0;
			}
		}

		int[] resultDiagonal = new int[maxSize];
		for (int i = 0; i < maxSize; i++)
		{
			resultDiagonal[i] = diagonal1[i] + diagonal2[i];
		}

		return new DiagonalMatrix(resultDiagonal);
	}
}
