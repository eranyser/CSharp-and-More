namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var names = new[] { "Tom", "Tim", "John" };

            IEnumerable<int> result = numbers.Filter(number => number % 2 == 0);
            var namesStartsWithT = names.Filter(name => name.StartsWith("T"));
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }

            foreach (var name in namesStartsWithT)
            {
                Console.WriteLine(name);
            }
        }
    }

    public static class EnumerableExtensions
    {
        /* This is an extension method for IEnumerable<T> that provides a filtering mechanism similar to the built-in Where method in LINQ. 
         * It allows you to filter any collection of type T based on a provided predicate function. 
         * The method uses 'yield return' to enable deferred execution, meaning that the filtering logic will only be applied when the resulting IEnumerable<T> is enumerated.
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
