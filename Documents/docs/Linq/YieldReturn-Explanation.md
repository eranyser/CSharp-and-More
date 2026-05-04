# Understanding `yield return` in C#

## What It Does

`yield return` is a **lazy evaluation iterator** that returns values one at a time instead of creating and returning an entire collection at once.

```csharp
yield return number;
```

This line pauses execution and returns the current number value to the caller. 
The next time the caller requests another value (like in a foreach loop), the method resumes 
execution right after the yield return statement and continues the loop.

## Example:

```csharp
private static IEnumerable<int> Filter(IEnumerable<int> numbers) {
	foreach (var number in numbers)
	{
		if (number % 2 == 0)
		{
			yield return number; // Returns the even number and pauses execution
		}
	}
}
```

## How It Works

 - First iteration: Loop starts, finds first even number (2) → yield return 2 → method pauses
 - Second iteration: Caller requests next value → method resumes → loop continues, finds next even number (4) → yield return 4 → method pauses
 - This continues until no more even numbers exist

## Memory Efficiency
Without yield return (the commented version):
```csharp
var result = new List<int>();  // Creates list in memory immediately
foreach (var number in numbers) {
    if (number % 2 == 0) {
        result.Add(number);      // Stores ALL even numbers at once
    }
}
return result;                   // Returns complete list
```
❌ Requires storing all even numbers in memory upfront

With yield return (current version):
```csharp
yield return number; // Returns one even number at a time, no need to store all in memory
```

✅ Only keeps current value in memory—memory efficient for large datasets

## Key Difference

Your method returns IEnumerable<int> (iterator), not List<int>. 
This makes it a generator that produces values on-demand, similar to how LINQ methods work.
