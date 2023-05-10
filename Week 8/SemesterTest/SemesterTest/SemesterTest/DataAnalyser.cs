using System;
namespace SemesterTest
{
	public class DataAnalyser
	{
		private List<int> _numbers;
		private SummaryStrategy _strategy;

		public SummaryStrategy Strategy
		{
			get
			{
				return _strategy;
			}
			set
			{
				_strategy = value;

			}
		}

		public DataAnalyser() : this(new List<int>(), new AverageSummary()) { }

		public DataAnalyser(SummaryStrategy strategy) : this(new List<int>(), strategy)
		{ }

		public DataAnalyser(List<int> numbers, SummaryStrategy strategy)
		{
			_numbers = numbers;
			_strategy = strategy;
		}

		public void AddNumber(int num)
		{
			_numbers.Add(num);
		}

        public void Summarise()
		{
			_strategy.PrintSummary(_numbers);
		}

	}
}

