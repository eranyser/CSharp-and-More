namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // LINQ (Language Integrated Query) is a powerful feature in C# that allows you to query and manipulate data in a more readable and concise way.
            var result = numbers.Where(number => number % 2 == 0);

            // You can also use LINQ to perform transformations on the data. For example, you can select the squares of the even numbers:
            result = result.Select(number => number * number);
            var singleResult = result.First(number => number > 4);

            var orders = new[] {
                new { Id = 1, Amount = 100 },
                new { Id = 2, Amount = 200 },
                new { Id = 3, Amount = 150 }
            };

            // You can use LINQ to calculate the total amount of all orders:
            var fullAmount = orders.Sum(order => order.Amount);

            foreach (var number in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
