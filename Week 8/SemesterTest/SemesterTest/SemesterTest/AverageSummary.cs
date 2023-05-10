using System;

namespace SemesterTest
{
	public class AverageSummary : SummaryStrategy
	{
		private float Average(List<int> numbers)
		{
			int total = 0;
			foreach (int number in numbers)
			{
				total += number;
			}
			float result = (float)total / numbers.Count;
			return result;
		}

        public override void PrintSummary(List<int> numbers)
        {
			Console.WriteLine("Average: " + Average(numbers));
        }
    }
}

