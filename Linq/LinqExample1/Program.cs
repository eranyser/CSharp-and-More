namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var names = new[] { "Tom", "Tim", "John" };
            // ShowEvenNumbers(numbers);
            // var evenNumbers = Filter(numbers, IsEven);
            //var evenNumbers = Filter(numbers, number => number % 2 == 0);
            //var result = Filter(names, name => name.StartsWith("T"));

            var result2 = numbers.Filter(number => number % 2 == 0);

            foreach (var number in result2)
            {
                Console.WriteLine(number);
            }
            /*
            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
            */


        }

        /*
        private static void ShowEvenNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0) { 
                    Console.WriteLine(number);
                }

            }
        }
        */

        /* This method is more flexible than ShowEvenNumbers because it returns a list of even numbers instead of just printing them. 
         * This allows the caller to use the filtered list in different ways, such as further processing, storing, or displaying it in a different format.
         */
        /*
        private static List<int> Filter(IEnumerable<int> numbers)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result;
        }
        */

        /* This version of the Filter method uses an iterator (yield return) to return even numbers one at a time. 
         * This approach is more memory efficient, especially for large collections, as it does not require storing all even numbers in memory at once.
         */
        /*
        private static IEnumerable<int> Filter(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }
        */

        /* This version of the Filter method uses a helper method IsEven to determine if a number is even.
         */
        /*
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
        */

        /* This version of the Filter method takes a predicate function as a parameter, allowing it to be used for filtering based on any condition, not just even numbers. 
         * This makes the method more reusable and flexible.
         */
        /*
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
        */
        /* This version of the Filter method is generic, allowing it to work with any type of collection, not just integers. 
         * The predicate function can be defined for any type, making this method highly versatile and reusable for various filtering scenarios.
         */
        /*
        private static IEnumerable<T> Filter<T>(IEnumerable<T> numbers, Func<T, bool> predicate)
        {
            foreach (var number in numbers)
            {
                if (predicate(number))
                    yield return number;
            }
        }
        */


        /* This version of the Filter method uses a helper method IsEven to determine if a number is even. 
         * This can improve readability and maintainability by separating the logic for checking if a number is even from the logic for filtering the numbers.
         */
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }

    public static class EnumerableExtensions
    {
        /* This version of the Filter method is defined as an extension method for IEnumerable<T>, allowing it to be called directly on any collection that implements IEnumerable<T>. 
         * This enhances the readability and usability of the method, as it can be used in a more natural and fluent way.
        */
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}
