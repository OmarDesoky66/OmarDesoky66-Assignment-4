# Benchmark Analysis

## 1. Benchmark Configuration

The benchmarks were performed using BenchmarkDotNet.

- **BenchmarkDotNet Version:** 0.15.8
- **Operating System:** Windows 10
- **Processor:** Intel Core i5-10300H CPU 2.50GHz
- **.NET Version:** .NET 10.0.12
- **Memory Diagnoser:** Enabled using `[MemoryDiagnoser]`
- **Methods:**
  - `StringConcatenation`
  - `StringBuilderConcatenation`
- **Iteration Counts:** 100, 1,000, 10,000, 100,000

## 2. Benchmark Results

The following results were generated on my own machine using BenchmarkDotNet.

| Method | Iterations | Mean | Error | StdDev | Allocated |
|---|---:|---:|---:|---:|---:|
| StringConcatenation | 100 | 3,151.0 ns | 39.52 ns | 35.03 ns | 51.73 KB |
| StringBuilderConcatenation | 100 | 331.0 ns | 3.73 ns | 3.49 ns | 2.42 KB |
| StringConcatenation | 1,000 | 260,941.3 ns | 2,191.15 ns | 1,942.40 ns | 4,912.08 KB |
| StringBuilderConcatenation | 1,000 | 2,931.0 ns | 55.49 ns | 61.68 ns | 26.49 KB |
| StringConcatenation | 10,000 | 38,555,282.1 ns | 571,932.18 ns | 446,527.03 ns | 488,586.71 KB |
| StringBuilderConcatenation | 10,000 | 68,123.2 ns | 584.98 ns | 547.19 ns | 208.56 KB |
| StringConcatenation | 100,000 | 8,228,284,988.9 ns | 157,429,061.14 ns | 168,447,331.79 ns | 48,835,724.86 KB |
| StringBuilderConcatenation | 100,000 | 709,605.1 ns | 12,540.40 ns | 10,471.81 ns | 1,966.48 KB |

## 3. Benchmark Analysis

### Q1. Which approach was faster with 100 iterations?

StringBuilder was faster.

- String concatenation: 3,151.0 ns.
- StringBuilder: 331.0 ns.

StringBuilder performed better because it avoids creating a new string object for every append operation.

### Q2. Which approach was faster with 100,000 iterations?

StringBuilder was significantly faster.

- String concatenation: 8,228,284,988.9 ns (approximately 8.23 seconds).
- StringBuilder: 709,605.1 ns (approximately 0.71 milliseconds).

This demonstrates that StringBuilder is much more efficient when repeatedly appending text.

### Q3. Which approach allocated more memory?

String concatenation allocated significantly more memory.

At 100,000 iterations:

- String concatenation: 48,835,724.86 KB.
- StringBuilder: 1,966.48 KB.

This is because normal string concatenation creates many temporary string objects, while StringBuilder reuses its internal buffer.

### Q4. What happened to string concatenation performance as the loop size increased?

String concatenation became significantly slower as the number of iterations increased.

At 100 iterations, it took approximately 3.15 microseconds.

At 100,000 iterations, it took approximately 8.23 seconds.

The execution time increases dramatically because every concatenation creates a new string and copies the previous content.

### Q5. Why does repeated string concatenation create additional allocations?

Strings in C# are immutable, meaning their contents cannot be modified after creation.

Every time we use the `+=` operator, C# creates a new string containing the previous content and the newly appended text.

The previous string is no longer needed by the variable, but its allocated memory must eventually be reclaimed by the Garbage Collector.

### Q6. Why does StringBuilder usually perform better when text is repeatedly appended?

StringBuilder uses a mutable internal buffer that can be reused and expanded when necessary.

Instead of creating a new string for every append operation, it modifies its internal buffer.

A final string is created when calling `ToString()`.

This reduces memory allocations and improves performance, especially when repeatedly appending text inside loops.

### Q7. Is StringBuilder always better than normal string operations? Explain.

No, StringBuilder is not always better.

For simple operations involving a small number of strings, normal string concatenation is perfectly suitable and can be more readable.

However, StringBuilder is generally more efficient when repeatedly appending large amounts of text, especially inside loops.

## 4. Conclusion

Based on the benchmark results, StringBuilder performed better in both execution time and memory allocation for all tested iteration counts.

The performance difference became much larger as the number of iterations increased.

This benchmark demonstrates the importance of understanding string immutability and choosing the appropriate approach depending on the workload.