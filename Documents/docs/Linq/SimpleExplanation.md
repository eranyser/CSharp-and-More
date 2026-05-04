# Linq - Simple Explanation

Lets create an array of integers and we want to show all the even numbers and filter out the odd numbers. 
```csharp
internal class Program
{
    static void Main(string[] args)
    {
        var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ShowEvenNumbers(numbers);
    }

    private static void ShowEvenNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0) { 
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
```

The above code is definetly not optimal. there are some issues make it such:
- The ***numbers*** variable of the method ***ShowEvenNubmers*** that is of type ```int[]```. 

    There is a known principal that we alway want to use the **least specific type** that you can handle. Suppse the caller has a List instead of Array. In this case the caller couldn not use the ***ShowEvenNubmers*** any more. There is a common type for all collection in c# It is called ***IEnumerable***. It is implemented by any kind of collection.

    ***IEnumerable*** is a:
    - Read only
    - Forward only 
    
    We can only read from this variable and can only move forward. (can't move backwards, can't index, i.e. get item number 3). 
    If we have an IEnumerable, we can change the type of the loop:

    ```csharp
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ShowEvenNumbers(numbers);
        }

        private static void ShowEvenNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0) { 
                    Console.WriteLine(number);
                }

            }
        }
    }
    ```
- In addition inside the method *ShowEvenNumber* we have both, Business logic ```if (number % 2 == 0)``` and UI ```Console.WriteLine(number);```. If for exmaple, we need to write **Automated Test**, it is very difficult to do it for this method. The solution for this is that we could return an Array, but since we don't know how many even numbers we will have, we prefer a `List<int>`, where we can add items dynamically.
    ```csharp
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = Filter(numbers);
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }

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
    }
    ```
- It still not very optimal, it is considered bad c# code. This is because in C# we don't need to build a persistent result, (`return List<int>`), in such cases. Instead of returning a *List of int* we can return an `IEnumerable<int>`, (base class for any collection). When we do so, we can use the `yield` to return the even numbers. The way it works is as follows:
    - The fileter method will exmaine the first number, if the first number is even, it immediately return it to the calling function that will print it.
    - when the second number is examined, C# will jump again into the method. It will jump between the caller and the calee back and forth.
    ```csharp
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
    ```
    More about ```yield return``` you can read [here](./YieldReturn-Explanation.md) 👈

As we see above the *Filter* method can be describe as iterating over all numbers and return those numbers that are even.
In software developmnet there is an important principal: **Single Responsibility Pattern**. Thei means that every method should have a single purpose. The *Filter* method above, has two purposes:
- Iterating
- decide for each iterated number, if it is even.
- return number if it is even.

The way to make our code comply to the **Single Reasponsibility Pattern** is to create an ```isEven(int nuber)``` method:
```csharp
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

private static bool IsEven(int number)
{
    return number % 2 == 0;
}
```

Now if I want to display all **Odd** numbers, what should I have to do?
- Duplicate the method above and create ```IsOdd(number)``` - bad solution
- add a relevant method as a parameter to the *Filter* method and call this method with the relevant parameter method as needed.
    In C# we write a method that get a parameter that is actually a function that recives an integer and return a boolean like this: `Func<int, bool>` and we will call it *predicate* and in the implemetation we call the *predicate* method. The caller functiion can be chaged to pass the ```IsEven``` method like this:
    ```csharp
    static void Main(string[] args)
    {
        var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        var evenNumbers = Filter(numbers, IsEven);
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }
    }

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
    ```
    In this way we can write the ```IsOdd``` method, and pass it to the *Filter* method.
    
    In addition, instead of passing the ```IsEven``` function as a parameter to the *Filter* method, we can write:
    ```csharp
    var evenNumbers = Filter(numbers, number => number % 2 == 0);
    ```
    If we want a list of odd number we should call it like this:
    ```csharp
    var evenNumbers = Filter(numbers, number => number % 2 != 0);
    ```
The *Filter* method is still not optimal. Suppose that instead of *integer* we have *string*. Nothing should be changed in the implementation of the *Filter* method. But we need to use *Generics*:
```csharp
private static IEnumerable<T> Filter<T>(IEnumerable<T> numbers, Func<T, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
            yield return number;
    }
}
```
We can now define array of names, and filter all names starts with, for example, 'T':
```csharp
var names = new [] {"Tom", "Tim", "John"};

var result = Filter(names, name => name.StartsWith("T"));

```

Another change we can do it to add the keyword ``this``` at the begining of the parameter's list of the *Filter* method.
```csharp
private static IEnumerable<T> Filter<T>(this IEnumerable<T> numbers, Func<T, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
            yield return number;
    }
}
```
The ```this``` keyword, causes the *Filter* method, to be injected into the *IEnumerable* type

The 'Promblem' is that Extension Methods must be defined in a static Class, so we have to either:
1. Change the Program Class to be static, but this is not recomended cuase:
    - The Program class should be the entry point of your application (contains Main(string[]))
    - Extension methods are utility functions for your domain
    - Mixing them violates SRP—each class should have one reason to change
2. Move the *Filter* method into another static class
    ```csharp
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                    yield return item;
            }
        }
    }
    ```

    and now we can use the mehdod as follows:
    ```csharp
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result2 = numbers.Filter(number => number % 2 == 0);  // Now works!
        }
    }
    ```
The method *Filter* has never been defined on *IEnumerable*. *IEnumerabel* has no method name *Filter*. Now it has! using the ```this``` keyword we inject a method on existing type.

Since the result type of our *Filter* method is *IEnumerable*, wo we can chain this methods:

```csharp
var result2 = numbers
                .Filter(number => number % 2 == 0)
                .Filter(number => number > 5);
```

Since we are using the ```yield return``` the numbers going back and forth form the callee to the caller, and the memory footprint is minimal.

The entire code we mentioned above is already implemented by Micorosft, it was called Linq - language integrated query.

**Bibilography**
- [Link Explanation](https://www.youtube.com/watch?v=3T2q1oowQdY&list=PLhGL9p3BWHwtV_hn6H_uZ4vrFE3F7mY8a&index=5)
- [![Linq Explanation](https://i.ytimg.com/vi/3T2q1oowQdY/hqdefault.jpg?sqp=-oaymwEnCPYBEIoBSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLBqn55yPTQXCAyyYsIca2a0hi--3g)](https://www.youtube.com/watch?v=3T2q1oowQdY&list=PLhGL9p3BWHwtV_hn6H_uZ4vrFE3F7mY8a&index=5)
- htl-mobile-computing-5 - 2019-2020
	- [Github Repository](https://github.com/rstropek/htl-mobile-computing-5)
	- [Slides](https://htl-mobile-computing-5.azurewebsites.net/#/)
- htl-mobile-computing - older course 2018-2019
	- [Github Repository](https://github.com/rstropek/htl-mobile-computing)
	- [Slides](https://rstropek.github.io/htl-mobile-computing/#/)
- htl-csharp - course 2019-2020
	- [Github Repository](https://github.com/rstropek/htl-csharp)
	- [Slides](https://rstropek.github.io/htl-csharp/#/)

- [Linq - From microsoft site](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)

- [Extenstion Method]()