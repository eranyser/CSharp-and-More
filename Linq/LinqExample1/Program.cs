namespace LinqExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ShowEvenNumbers(numbers);
        }

        /* 
         * This method takes an array of integers and prints the even numbers to the console.
         * It iterates through each number in the array, checks if it is even (i.e., divisible by 2 with no remainder), and if so, it prints the number.
         */
        private static void ShowEvenNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
    }
}
