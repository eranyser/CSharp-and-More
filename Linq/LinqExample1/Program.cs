namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // LINQ (Language Integrated Query) is a powerful feature in C# that allows you to query and manipulate data in a more readable and concise way.
            var evenNumbers = numbers
                            .Where(number => number % 2 == 0)
                            .Where(number => number > 5);

            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
