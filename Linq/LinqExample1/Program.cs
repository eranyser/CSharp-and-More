namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> result = Filter(numbers, IsEven);
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
        }

        /* This method filters a collection of integers based on a provided predicate function. 
         * It takes an IEnumerable of integers and a Func that defines the condition for filtering. 
         * The method uses the yield return statement to return each number that satisfies the predicate, 
         * allowing for deferred execution and efficient memory usage.
         */
        private static IEnumerable<int> Filter(IEnumerable<int> numbers, Func<int, bool> predicate)
        {
            foreach (var number in numbers)
            {
                if (predicate(number))
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
