namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ShowEvenNumbers(numbers);
        }

        // This method will print only the even numbers from the provided collection 
        private static void ShowEvenNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
