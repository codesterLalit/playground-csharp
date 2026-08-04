# Playground

A personal C# learning playground — small, numbered, single-topic exercise files used to practice language features hands-on rather than by reading docs. Single console app, no `.sln`, `net10.0`, nullable + implicit usings enabled.

## Structure

```
Program.cs          entry point — uncomment a line to run that day's exercise
fun-with-csharp/     type system track: records, structs, interfaces, generics, pattern matching
delegate/            delegates, Action/Func/Predicate, multicast delegates, events
Linq/                LINQ: filtering, projection, deferred execution
Experiments/         quant-finance katas: returns, volatility, Sharpe ratio, drawdown, VaR
```

## Running an exercise

`Program.cs` calls one exercise's `Run()` at a time:

```csharp
Play.fun.Ex15_GenericConstraints.Run();
```

Comment/uncomment the relevant line, then:

```
dotnet run
```

## Conventions

- One file per concept, named `ExNN_Topic.cs` or `DayNN_Topic.cs`.
- Each file is a static class with a single `Run()` entry point.
- Namespaces group by track (`Play.fun`, `Play.delegates`, `Play.linq`), not by physical folder — a few files live in one folder but declare another track's namespace.

## fun-with-csharp track

Progressive curriculum on the C# type system:

1. Records basics — value vs reference equality
2. `with`-expressions & immutability
3. Record structs vs record classes
4. Interfaces basics — multiple interfaces, expression-bodied members, explicit interface implementation
5. Abstract classes vs interfaces
6. Default interface methods
7. Generics + interfaces
8. Pattern matching on records
9. Structs vs classes — mutability pitfalls
10. Capstone — records + interfaces + pattern matching combined
11. (extension) Implementing `IEnumerable`/`ICollection`/`IList` yourself
12. (extension) DTO vs EF Core entity modeling

A standalone reference doc lives at `fun-with-csharp/interfaces-and-types-guide.md`, covering interfaces, built-in collection interfaces, generic constraints, and DTO vs. entity modeling.
