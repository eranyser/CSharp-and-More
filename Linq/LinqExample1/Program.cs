namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var names = new[] { "Tom", "Tim", "John" };
            IEnumerable<int> result = Filter(numbers, number => number % 2 == 0);
            var namesStartsWithT = Filter(names, name => name.StartsWith("T"));

            foreach (int item in result)
            {
                Console.WriteLine(item);
            }

            foreach (var name in namesStartsWithT)
            {
                Console.WriteLine(name);
            }
        }

        /* This method is a custom implementation of the LINQ Where method.
         * It takes an IEnumerable<T> and a predicate function, and yields only the elements that satisfy the predicate.
         */
        private static IEnumerable<T> Filter<T>(IEnumerable<T> numbers, Func<T, bool> predicate)
        {
            foreach (var number in numbers)
            {
                if (predicate(number))
                {
                    yield return number;
                }
            }
        }
    }
}
