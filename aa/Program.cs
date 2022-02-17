using System;

namespace Lab1Viz
{
	public class HW1
	{
		public static void CashTurn(int[] customers, int[] cash, int n, ref int i)
		{
			for (int j = 0; j < n; j++)
			{
				if (cash[j] == 0)
				{
					cash[j] = customers[i];
					i++;
					if (i > customers.Length) break;
				}
			}
		}

		public static void CashInit(int[] cash, int n)
		{
			for (int t = 0; t < n; t++) cash[t] = 0;
		}

		public static int CashMax(int[] cash, int n)
		{
			int max = 0;
			for (int j = 0; j < n; j++) if (max < cash[j]) max = cash[j];
			return max;
		}

		public static long QueueTime(int[] customers, int n)
		{

			int[] cash = new int[n];
			CashInit(cash, n);
			int i = 0;
			long time = 0;
			CashTurn(customers, cash, n, ref i);
			while (i < customers.Length)
			{
				time++;
				for (int j = 0; j < n; j++) cash[j]--;
				for (int j = 0; j < n; j++) CashTurn(customers, cash, n, ref i);
			}
			int max = 0;
			time += CashMax(cash, n);
			return time;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			long time;
			int[] mas1 = new int[3] { 5, 3, 4 };
			time = HW1.QueueTime(mas1, 1);
			Console.WriteLine($"{time}");

			int[] mas2 = new int[4] { 10, 2, 3, 3 };
			time = HW1.QueueTime(mas2, 2);
			Console.WriteLine($"{time}");

			int[] mas3 = new int[3] { 2, 3, 10 };
			time = HW1.QueueTime(mas3, 2);
			Console.WriteLine($"{time}");
		}
	}
}
