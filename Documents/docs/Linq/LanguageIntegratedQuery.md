---
sidebar_position: 3
---

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
Additional methods in Linq are:
1. *Select* -  It project an item.
2. *First* - First item that comply the function parameter.
3. *FirstOrDefault* - if there is no item comply the function parameter, get the default. (for integers, the default value for an undefined varaible is zero - 0)
4. *Single* - give me a single item fulfiling this condition. If there are more items single returns an exception.

```csharp
        static void Main(string[] args)
        {
            var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.Where(number => number % 2 == 0);

            result = result.Select(number => number * number);
            var singleResult = result.First(number => number > 4);

            var orders = new[] {
                new { Id = 1, Amount = 100 },
                new { Id = 2, Amount = 200 },
                new { Id = 3, Amount = 150 }
            };

            var fullAmount = orders.Sum(order => order.Amount);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }
```

**Bibilography**

 - [Link - Mobile Computing 30:00](https://www.youtube.com/watch?v=3T2q1oowQdY&list=PLhGL9p3BWHwtV_hn6H_uZ4vrFE3F7mY8a&index=3)
 - [![Link - Mobile Computing 30:00](https://i.ytimg.com/vi/3T2q1oowQdY/hqdefault.jpg?sqp=-oaymwEmCKgBEF5IWvKriqkDGQgBFQAAiEIYAdgBAeIBCggYEAIYBjgBQAE=&rs=AOn4CLC2hNEvH58G5EMxUyieOvuDDyYCfA)](https://www.youtube.com/watch?v=3T2q1oowQdY&list=PLhGL9p3BWHwtV_hn6H_uZ4vrFE3F7mY8a&index=3)
 - [Link Tutorial](https://www.youtube.com/playlist?list=PL6n9fhu94yhWi8K02Eqxp3Xyh_OmQ0Rp6)
 - [![](https://i.ytimg.com/vi/z3PowDJKOSA/hqdefault.jpg?sqp=-oaymwEnCPYBEIoBSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLAMa40_TkEOLoM1l_dR27RUZ5j6dg)](https://www.youtube.com/playlist?list=PL6n9fhu94yhWi8K02Eqxp3Xyh_OmQ0Rp6)
