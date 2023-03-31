namespace ParallelCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Minimum number -> ");
            long min = long.Parse(Console.ReadLine());
            while (min < 1)
            {
                Console.Write("Must be higher than or equal to 1 -> ");
                min = long.Parse(Console.ReadLine());

            }
            Console.Write("Maximum number -> ");
            long max = long.Parse(Console.ReadLine());
            while (max<min)
            {
                Console.Write("Must be higher than or equal to minimum number -> ");
                max = long.Parse(Console.ReadLine());

            }
            Console.Write("Parts -> ");
            int parts = int.Parse(Console.ReadLine());
            while (parts <= 0)
            {
                Console.Write("Must be higher than 0 -> ");
                max = long.Parse(Console.ReadLine());

            }
            ParallelCalc parallelCalc = new ParallelCalc(min,max,parts);
            long res = parallelCalc.Run(out long elapsed);
            Console.WriteLine($"Result - {res}, Time Elapsed - {elapsed}");
        }
    }
}