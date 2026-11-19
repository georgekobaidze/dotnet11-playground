# .NET 11 & C# 15 Playground

![.NET 11 & C# 15 Playground](docs/cover.jpg)

A lightweight playground repository for experimenting with and testing new features introduced in **.NET 11** and **C# 15**.

Use it to explore language changes, try out APIs, and validate ideas in isolation without production constraints. Each feature lives in its own small project, often with a "before" and "after" version so you can see what the new feature actually changes.

## What's inside

| Project              | Feature     | Description                                                                                                                               |
| -------------------- | ----------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| [Unions](src/Unions) | Union types | A small console login flow that compares the classic class-hierarchy approach with C# 15 unions and compiler-checked exhaustive matching. |

More examples will be added as new features are explored.

## Getting started

You'll need the [.NET 11 SDK](https://dotnet.microsoft.com/download/dotnet/11.0). Then clone the repo and run any example:

```bash
dotnet run --project src/Unions
```

## Disclaimer

.NET 11 and C# 15 features may still change. The code here is for learning and experimentation, not production use.