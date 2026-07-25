# C# Types, Records & Interfaces — Field Guide

A read-through reference, not exercises. Trace through each snippet mentally — expected output is given as comments. Everything here targets .NET (net10.0, matching this repo's `Playground.csproj`), nullable reference types + implicit usings enabled.

---

## 1. Recap — class vs record vs struct

Three independent choices stack together: **class vs struct** (reference type vs value type — where it lives, how it's copied) and **plain vs record** (does the compiler generate value-equality machinery for you).

```csharp
public class Plain { public int X; }                  // reference type, reference equality
public record RecordClass(int X);                       // reference type, VALUE equality (default "record" = "record class")
public struct PlainStruct { public int X; }             // value type, value equality (struct default), but no ToString/with
public record struct RecordStruct(int X);                // value type, value equality + ToString + with
```

| | Where it lives | Copy on assignment? | `==` compares | Free `ToString()`? | `with` support |
|---|---|---|---|---|---|
| `class` | heap | no (copies the reference) | reference (identity) | no (prints type name) | no |
| `record` / `record class` | heap | no (copies the reference) | value (all properties) | yes (`Foo { X = 1 }`) | yes |
| `struct` | inline/stack (or inline in containing object) | yes (whole value copied) | value, but you must implement it yourself for `==` (structs get value `.Equals()` via reflection by default — slow — but not `==`) | no | no |
| `record struct` | inline/stack | yes (whole value copied) | value (generated) | yes | yes |

**Rule of thumb:** reach for `record` (class) as your default for immutable data. Reach for `record struct` only when the type is small (a handful of primitive fields, like a `Point` or `Money`) and you specifically want to avoid heap allocation. Reach for plain `class` when identity matters more than value (see §6). Plain `struct` is rare in application code now that `record struct` exists — you lose `ToString`/`with` for no benefit.

`init` vs `set`: `init` only allows assignment during construction (constructor or object-initializer); `set` allows assignment any time. Records default their **positional** properties to `init`. Swapping to `set` gives up the immutability guarantee that makes value-equality trustworthy over time (a mutable object's hash/equality can change after being stored in a `Dictionary`/`HashSet`, corrupting it).

---

## 2. Interfaces — the fundamentals

An interface is a **contract**: a set of members a type promises to implement, with no storage of its own (mostly — see default methods below).

```csharp
public interface IShape
{
    double Area();
    double Perimeter();
}

public class Circle : IShape
{
    public double Radius { get; init; }
    public double Area() => Math.PI * Radius * Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; init; }
    public double Height { get; init; }
    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
}
```

The payoff — code written against `IShape` works for *any* implementer, no type-checking needed:

```csharp
List<IShape> shapes = new() { new Circle { Radius = 2 }, new Rectangle { Width = 3, Height = 4 } };
foreach (var s in shapes)
    Console.WriteLine($"Area={s.Area()}, Perimeter={s.Perimeter()}");
// Area=12.566..., Perimeter=12.566...
// Area=12, Perimeter=14
```

Note: `IShape s = new Circle { Radius = 2 };` — you can call `s.Area()` (declared on `IShape`) but **not** `s.Radius` (only declared on `Circle`). The variable's *static type* (`IShape`) limits what members are visible, even though the *runtime type* is `Circle`. To get at `Radius` you'd cast: `((Circle)s).Radius` or `if (s is Circle c) c.Radius`.

**Multiple interfaces** — a class can implement as many as it wants, comma-separated:

```csharp
public interface INamed { string Name { get; } }

public class Circle : IShape, INamed
{
    public double Radius { get; init; }
    public string Name { get; init; } = "circle";
    public double Area() => Math.PI * Radius * Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
}
```

A `List<IShape>` still only knows about `IShape` members — it doesn't automatically expose `Name` even if every element happens to also implement `INamed`. To access `Name` generically you'd either declare `IShape : INamed` (forcing every shape to have a name) or check/cast per-item (`if (shape is INamed n) ...`). Whether to merge two contracts into one, or keep them separate and cast when needed, is a real design decision — merge them only if *every* implementer genuinely needs both; keep them separate if some shapes might reasonably have no name.

**Explicit interface implementation** — hides a member unless accessed through the interface type. Useful when a class implements two interfaces with clashing member names, or when you want to discourage calling a method except through its contract:

```csharp
public class Circle : IShape
{
    double IShape.Perimeter() => 2 * Math.PI * Radius; // no access modifier allowed here
    public double Radius { get; init; }
    public double Area() => Math.PI * Radius * Radius;
}

var c = new Circle { Radius = 2 };
// c.Perimeter();          // ERROR — not visible on Circle directly
IShape s = c;
s.Perimeter();              // OK — visible through the interface
```

**Default interface methods** (C# 8+) — an interface can now provide a method body. Existing implementers automatically get the default unless they override it — lets you add new members to a published interface without breaking every class that already implements it:

```csharp
public interface IShape
{
    double Area();
    double Perimeter();
    string Describe() => $"Area={Area():F2}, Perimeter={Perimeter():F2}"; // default body
}
// Circle and Rectangle above don't need to implement Describe() — they inherit the default.
// Any implementer CAN override Describe() if it wants custom behavior.
```

---

## 3. The built-in interface family (`IEnumerable` → `IList`)

These are the interfaces .NET's own collection types (`List<T>`, `Dictionary<K,V>`, arrays, etc.) implement, and the ones you'll write against constantly.

```
IEnumerable<T>            "I can be iterated with foreach" — one method: GetEnumerator()
      ↑
ICollection<T>             + Count, Add, Remove, Contains, Clear, CopyTo — "I'm a mutable bag"
      ↑
IList<T>                   + indexer this[int], Insert, RemoveAt — "I have positional access"
```

Plus read-only counterparts that describe a *view* without mutation members:
```
IEnumerable<T>  →  IReadOnlyCollection<T> (+ Count)  →  IReadOnlyList<T> (+ indexer, no Insert/RemoveAt)
```

`List<T>` implements **all** of these simultaneously (`IList<T>`, `ICollection<T>`, `IEnumerable<T>`, `IReadOnlyList<T>`, `IReadOnlyCollection<T>`). Which one you accept as a *parameter type* signals intent to callers:

```csharp
void PrintAll(IEnumerable<string> items)         // I only need to iterate — most flexible for callers
{
    foreach (var s in items) Console.WriteLine(s);
}

void AddDefaults(ICollection<string> items)      // I need to Add() into it — caller can't pass a plain array
{
    items.Add("default");
}

string FirstOrFallback(IReadOnlyList<string> items)  // I need indexed access but PROMISE not to mutate
{
    return items.Count > 0 ? items[0] : "none";
}
```

Passing the *narrowest* interface that satisfies what your method actually does is idiomatic — it lets callers pass arrays, `List<T>`, immutable collections, LINQ query results, etc., interchangeably, and it documents (via the signature) whether you might mutate their collection.

**`IComparable<T>` and `IComparer<T>`** — sorting contracts:

```csharp
public record Book(string Title, int Year) : IComparable<Book>
{
    public int CompareTo(Book? other) => Year.CompareTo(other?.Year ?? 0);
}

var books = new List<Book> { new("B", 2001), new("A", 1999) };
books.Sort();                       // uses CompareTo — sorted by Year ascending
// [Book { Title = A, Year = 1999 }, Book { Title = B, Year = 2001 }]
```

`IComparable<T>` = "I know how to compare myself to another instance" (built into the type). `IComparer<T>` = a *separate* object representing one particular way to compare two instances — useful when you need multiple sort orders for the same type without changing the type itself:

```csharp
public class TitleComparer : IComparer<Book>
{
    public int Compare(Book? x, Book? y) => string.Compare(x?.Title, y?.Title);
}
books.Sort(new TitleComparer());     // sorted by Title instead
```

**`IEquatable<T>`** — records implement this automatically (that's part of what gives you the generated `Equals`/`==`). For a plain class, implementing it yourself avoids boxing overhead vs. the default `object.Equals(object)` and documents that value-equality is intentional:

```csharp
public class Money : IEquatable<Money>
{
    public decimal Amount { get; init; }
    public bool Equals(Money? other) => other is not null && Amount == other.Amount;
    public override bool Equals(object? obj) => Equals(obj as Money);
    public override int GetHashCode() => Amount.GetHashCode();
}
```

**`IDisposable`** — "I hold an unmanaged/external resource (file handle, DB connection, etc.) that must be released deterministically." Implement `void Dispose()`; consumers use a `using` block/statement so `Dispose()` runs automatically even if an exception is thrown:

```csharp
using var conn = new SqlConnection(connStr); // Dispose() called automatically at end of scope
```

---

## 4. Generics + interfaces (constraints)

Generics let you write one implementation that works for many types, while constraints let you require those types to satisfy a contract:

```csharp
public static T Max<T>(T a, T b) where T : IComparable<T>
    => a.CompareTo(b) >= 0 ? a : b;

Max(3, 7);            // 7 — int implements IComparable<int>
Max(new Book("A", 1999), new Book("B", 2001)); // Book { Title = B, Year = 2001 } — from §3's IComparable<Book>
```

A tiny generic container constrained to comparable items:

```csharp
public class SortedBag<T> where T : IComparable<T>
{
    private readonly List<T> _items = new();
    public void Add(T item)
    {
        int i = _items.BinarySearch(item);
        _items.Insert(i < 0 ? ~i : i, item);
    }
    public IReadOnlyList<T> Items => _items; // expose read-only view, hide mutation
}
```

Common constraint forms: `where T : class` (reference type only), `where T : struct` (value type only), `where T : IFoo` (must implement interface), `where T : new()` (must have a public parameterless constructor), and they can combine: `where T : class, IComparable<T>, new()`.

---

## 5. Pattern matching on records (preview)

Records pair naturally with `switch` expressions and property patterns because their shape (their properties) is public and known:

```csharp
public abstract record Shape;
public sealed record Circle(double Radius) : Shape;
public sealed record Rectangle(double Width, double Height) : Shape;
public sealed record Triangle(double Base, double Height) : Shape;

static double Area(Shape s) => s switch
{
    Circle c => Math.PI * c.Radius * c.Radius,
    Rectangle { Width: var w, Height: var h } => w * h,   // property pattern + deconstruction
    Triangle t => 0.5 * t.Base * t.Height,
    _ => throw new ArgumentOutOfRangeException(nameof(s))
};
```

Because `Shape` is `abstract` and every subtype is `sealed`, the compiler can often tell the `switch` is exhaustive (no missing cases) — this combo (sealed record hierarchy + switch) is the closest C# gets to algebraic data types / discriminated unions from functional languages. We'll build this out properly in the capstone challenge.

---

## 6. Why DTOs and data models pick specific type shapes

This is the "why" behind conventions you'll see in real codebases:

**DTOs / API request-response payloads → `record`.**
- Equality by value is exactly what you want when comparing "did this response match what I expected" in a test, or de-duplicating payloads.
- Immutability prevents a deserialized payload from being silently mutated somewhere downstream and causing bugs that are hard to trace.
- `with` expressions make it trivial to build a modified copy for a follow-up request without a null-checked builder pattern.
- Free, readable `ToString()` output is a big win for logging incoming/outgoing payloads.

**Domain / entity models (e.g. EF Core entities backed by a database row) → plain `class`.**
- Identity matters more than value: two `Customer` objects with identical `Name`/`Email` right now might still be *different customers* (or the same customer mid-update where one field hasn't synced yet) — you generally want reference/identity equality (or equality by a stable ID field, not by all fields), which is what a plain class gives by default.
- These objects are commonly *mutated* over their lifetime (tracked by an ORM's change tracker, updated field by field, saved back to a DB) — record's default immutability actively fights this usage pattern.
- ORMs like EF Core often need to instantiate entities via reflection/proxies for change-tracking and lazy-loading; records' compiler-generated `Equals`/`GetHashCode` based on *all* properties can actively break change-tracking (two entities with the same data but different DB identity would incorrectly compare equal) and proxy generation. This is the most common concrete reason teams avoid records for EF entities specifically.

**Small, frequently-copied value types (Money amounts, 2D/3D points, date ranges, IDs wrapping a primitive) → `record struct` (or `readonly record struct`).**
- Avoids heap allocation and GC pressure when you create huge numbers of them (e.g. millions of price ticks in a trading system — relevant to your `Experiments/Day01..05` files!).
- Value equality is usually exactly right (`Money(10) == Money(10)` should be true).
- `readonly record struct` additionally guarantees the compiler won't generate hidden defensive copies when passing it around read-only, which matters for performance-sensitive code.

**Quick decision table:**

| Need | Choice |
|---|---|
| Immutable data crossing a boundary (API, message queue, function return) | `record` (class) |
| Small hot-path value, equality by value, no heap alloc | `record struct` / `readonly record struct` |
| Mutable entity with identity + lifecycle (DB row, tracked object) | `class` |
| Pure contract multiple unrelated types must satisfy | `interface` |
| Shared base implementation + contract, single-inheritance is fine | `abstract class` |

---

## 7. Cheat sheet

```csharp
record Foo(int X);                    // = record class Foo(int X); reference type, value equality, init-only, with-support
record struct Foo(int X);             // value type, value equality, mutable by default, with-support
readonly record struct Foo(int X);    // value type, value equality, TRULY immutable, no defensive copies

interface IFoo { void Bar(); }                          // contract, no state
interface IFoo { void Bar() => Console.WriteLine("d"); } // default method — optional to override

class C : IFoo, IBar { }              // multiple interfaces, comma-separated
void IFoo.Bar() { }                   // explicit implementation — only reachable via IFoo-typed variable

class Box<T> where T : IComparable<T> { }  // generic constraint

x switch {                             // pattern matching
    Circle c => ...,
    Rectangle { Width: var w } => ...,
    _ => ...
};
```

---

## 8. When you're back online

Pick up at **Challenge 4, parts 5–8** (multiple interfaces + `INamed`, expression-bodied members, explicit interface implementation, and the `IList<T>`/`List<T>` preview) — all covered above in §2–3 now, so you can attempt them from memory, or move straight to **Challenge 5 (abstract classes vs interfaces)**. Ping me with what you tried whenever you're back.
