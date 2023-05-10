namespace SemesterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MinMax Summary");

            DataAnalyser dataAnalyser = new DataAnalyser(new List<int>() {1,0,4,0,7,1,4,5,3}, new MinMaxSummary());

            dataAnalyser.Summarise();

            dataAnalyser.AddNumber(7);
            dataAnalyser.AddNumber(5);
            dataAnalyser.AddNumber(21);

            Console.WriteLine("\nAverage Summary");
            dataAnalyser.Strategy = new AverageSummary();

            dataAnalyser.Summarise();
        }
    }
}
