namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> result = Filter(numbers);
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
        }

        /* This method filters the input numbers and returns a list of even numbers.
         * It iterates through each number in the input collection, checks if it is even,
         * and if so, adds it to the result list. Finally, it returns the list of even numbers.
         */
        private static List<int> Filter(IEnumerable<int> numbers)
        {
            List<int> result = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result;
        }
    }
}
