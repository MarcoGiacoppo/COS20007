using System;
namespace SemesterTest
{
	public class MinMaxSummary : SummaryStrategy
	{
		private int Minimum(List<int> numbers)
		{
			int min = numbers[0];
			foreach (int i in numbers)
			{
				if (min > i)
				{
					min = i;
				}
			}
			return min;
		}

		private int Maximum(List<int> numbers)
		{
			int max = numbers[0];
			foreach (int i in numbers)
			{
				if (max < i)
				{
					max = i;
				}
			}
			return max;
		}

        public override void PrintSummary(List<int> numbers)
        {
			Console.WriteLine("Minimum Value: " + Minimum(numbers));
			Console.WriteLine("Maximum Value: " + Maximum(numbers));
        }
    }
}

