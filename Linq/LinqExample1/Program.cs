namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> result = Filter(numbers);
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
        }

        /* This method filters the input numbers and returns a list of even numbers.
         * It iterates through each number in the input collection, checks if it is even,
         * and if so, adds it to the result list. Finally, it returns the list of even numbers.
         */
        private static IEnumerable<int> Filter(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (IsEven(number))
                {
                    yield return number;
                }
            }
        }

        /* This method checks if a given number is even. It takes an integer as input and returns true if the number is even (i.e., divisible by 2 without a remainder), and false otherwise.
         */
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
