# .NET 11 & C# 15 Playground

![.NET 11 & C# 15 Playground](https://raw.githubusercontent.com/georgekobaidze/dotnet11-playground/main/docs/cover.jpg)

A lightweight playground repository for experimenting with and testing new features introduced in **.NET 11** and **C# 15**.

Use it to explore language changes, try out APIs, and validate ideas in isolation without production constraints. Each feature lives in its own small project, often with a "before" and "after" version so you can see what the new feature actually changes.

## What's inside

| Project | Feature | Description |
| --- | --- | --- |
| [Unions](https://github.com/georgekobaidze/dotnet11-playground/tree/main/src/Unions) | Union types | Console examples: the login flow (before and after unions), plus samples for parsing input, a state machine, user commands, and combining types you don't own. |
| [UnionsWebApi](https://github.com/georgekobaidze/dotnet11-playground/tree/main/src/UnionsWebApi) | Union types | A minimal API that returns a union from a service and maps each outcome to an HTTP response. |
| [ClosedHierarchies](https://github.com/georgekobaidze/dotnet11-playground/tree/main/src/ClosedHierarchies) | Closed hierarchies | An order status modeled as an `abstract` record (before) and a `closed` record (after), so a `switch` over every subtype is exhaustive without a discard arm. |
| [LabeledLoops](https://github.com/georgekobaidze/dotnet11-playground/tree/main/src/LabeledLoops) | Labeled `break` / `continue` | `continue nextOrder;` skips to the next outer-loop iteration, and `break gameLoop;` exits a loop from inside a `switch`. The `continue` example also includes the pre-C# 15 version, which needs a flag variable. |

More examples will be added as new features are explored.

## Getting started

You'll need the [.NET 11 SDK](https://dotnet.microsoft.com/download/dotnet/11.0). Then clone the repo and run any example:

```bash
dotnet run --project src/Unions
dotnet run --project src/UnionsWebApi
dotnet run --project src/LabeledLoops
dotnet build src/ClosedHierarchies
```

Some projects hold several examples in one `Program.cs`. Uncomment the one you want to run:

- `src/Unions/Program.cs`: the login flow and the samples.
- `src/LabeledLoops/Program.cs`: the `continue` example (C# 15 and before) and the `break` example.

`ClosedHierarchies` has nothing to run, because the point is what the compiler reports. In `src/ClosedHierarchies/Program.cs`, change `using AfterClosed;` to `using BeforeClosed;` and build again to get warning CS8509, which says the `switch` isn't exhaustive.

## Disclaimer

The code here is for learning and experimentation, not production use.