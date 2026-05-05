# Linq - Language Integrated Query

Fortunately the implementation we saw [here](./SimpleExplanation.md), was implemented by Microsoft and it is called Linq. Linq is actually a bunch of injected methods, (extension methods), on IEnumerable.

Actually we can remove most of the code we created earlier. the *`Filter`* method that we implemented earlier is called in Link *`Where`* and we can write:
```csharp
static void Main(string[] args)
{
    var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    var evenNumbers = numbers
                    .Where(number => number % 2 == 0)
                    .Where(number => number > 5);

    foreach (var number in evenNumbers)
    {
        Console.WriteLine(number);
    }
}
```