# C# Syntax Notes

These quick notes follow the same topics as the [mini course](README.md). Examples are separate snippets; put top-level statements before type declarations, and put member-only snippets inside a class.

## List

```csharp
List<string> names = new()
{
    "Alice", "Bob", "Anna"
}; // Adds each item through List<T>.Add.

// Collection expression (C# 12 or later).
List<string> cloudianNames = ["Alice", "Bob", "Anna"];
```

A list can grow or shrink. Its element type is specified by `T`, here `string`. A collection expression needs a target type; `var names = ["Alice", "Bob"];` does not compile.

## Target-Typed `new`

When the expected type is known, you can omit its name after `new`:

```csharp
GameDto game = new GameDto("game-1", 12m, "Combat");
GameDto anotherGame = new("game-2", 15m, "RPG");

public record GameDto(string Id, decimal Price, string Genre);
```

This simplified `GameDto` is for this example, not the project's DTO definition. Target-typed `new` always needs parentheses, even with no arguments: `new()`. With `var`, write the type after `new`, as in `var game = new GameDto("game-1", 12m, "Combat");`.

## `{}` Syntax

### Object Initializer

An object initializer creates an object and assigns accessible fields or properties. Its constructor runs first.

```csharp
var person = new Person
{
    Name = "Nguyen Kha An", Age = 20
};

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
```

With this simple class, it is similar to:

```csharp
var person = new Person();
person.Name = "Nguyen Kha An";
person.Age = 20;
```

For this form, `new Person { ... }` may omit empty parentheses. Both `new Person()` and `new Person { ... }` call the parameterless constructor; `new Person` alone is invalid.

### Collection Initializer

A collection initializer supplies initial elements rather than assigning named members:

```csharp
var names = new List<string>
{
    "Alice", "Bob", "Anna"
};
```

For `List<T>`, this calls `Add` for each item, like:

```csharp
var names = new List<string>();
names.Add("Alice");
names.Add("Bob");
names.Add("Anna");
```

### Pattern Matching

In a property pattern, braces describe tests against an existing object:

```csharp
if (person is Person { Name: "Nguyen Kha An" })
{
    Console.WriteLine("This is Nguyen Kha An");
}
```

In an initializer, `Name = "Alice"` assigns a value. In a pattern, `Name: "Alice"` tests the property's value. A property pattern does not match `null`.

## Lambda Expressions

Syntax: `parameters => expression`, or `parameters => { statements }`.

For example, `x => x * 2` accepts one parameter, and `(x, y) => x + y` accepts two. A lambda is an unnamed function; a delegate variable lets you store and call its behavior:

```csharp
Func<int, int, int> sumTwoNumbers = (x, y) => x + y;
Console.WriteLine(sumTwoNumbers(3, 4)); // 7
```

The final `Func` type argument is the return type; the earlier ones are parameter types. `Func<int>` has no parameters and returns an `int`. Use `Action` for behavior that returns `void`.

### Delegates

A delegate type describes a callable signature. A delegate instance refers to one or more compatible methods, including the target object for each instance method. A named method can be assigned just like a lambda:

```csharp
int Add(int a, int b)
{
    return a + b;
}

Func<int, int, int> add = Add;
Console.WriteLine(add(4, 5)); // 9
Func<int, int, int> minus = (a, b) => a - b;
```

Assigning `Add` creates a delegate; `Add(4, 5)` calls the function and returns a number.

You can also declare a custom delegate type:

```csharp
public delegate int BinaryOperation(int left, int right);
```

`Func<int, int, int> add(int a, int b)` would declare a function returning a delegate if supplied with a valid body; it does **not** declare a delegate type. Use `Func<int, int, int> add = Add;` to declare a delegate variable.

## Ways to Create an Instance in C#

```csharp
Person first = new Person();
Person second = new();
var third = new Person();
```

All three variables have type `Person`. You may omit the type after `new` only when the context supplies a target type. Object initializers may follow construction to assign members.

## Anonymous Objects

An anonymous object has a type: the compiler generates a class with read-only properties. You cannot write its type name in source code, so use `var` to access its properties directly:

```csharp
var person = new
{
    Name = "Nguyen Kha An", Age = 20
};
Console.WriteLine(person.Name);
```

This syntax uses `new { ... }`, with no constructor parentheses. Use a named class or record when data needs a reusable contract.

## The `object` Type

`object` is the common base type for the ordinary value and reference types used here. Specialized types such as `ref struct` types cannot be stored in `object` variables.

```csharp
object x = 10; // Boxes the int value.
object y = "Hello";
object z = new Person();
```

Compare `var` with `object`:

```csharp
var x = 10;    // Compile-time type: int.
object y = 10; // Compile-time type: object; contains a boxed int.

if (y is int number)
{
    Console.WriteLine(number + 1);
}
```

`var` infers a fixed type; it does not delay type checking. An `object` variable needs a cast or type check before you use members specific to the contained type.

## Casting and Conversion

`(Type)value` requests an explicit conversion. A numeric cast can lose information; a reference cast changes how you access the same object and can fail if the object is incompatible. It does not create an object of a new class.

Parsing, rather than casting, converts numeric text:

```csharp
string text = "123";
if (int.TryParse(text, out int number))
{
    Console.WriteLine(number.ToString()); // Converts the number to text.
}
```

`int.Parse` throws for invalid text or values outside the `int` range. `TryParse` reports these failures with `false`. Numeric parsing and formatting can depend on the current culture.

## Static Classes and Extension Methods

### Static Classes

A static class cannot be instantiated:

```csharp
public static class GameEndpoints
{
    private static readonly string Name = "MMM";
}
```

Methods, fields, and properties in a static class must be static. Constants are implicitly static; nested types are also allowed. A static member belongs to the type rather than an individual object.

### Extension Methods

An extension method is a static helper callable with instance-method syntax. It does not modify the original type. For example, this ASP.NET Core snippet belongs in a web project:

```csharp
public static class GameEndpoints
{
    public static void MapGamesEndpoints(this WebApplication app)
    {
        app.MapGet("/games", () => "Game list");
    }
}
```

After building the application, call `app.MapGamesEndpoints();`. The current project defines an extension with that name in `GameStore.Endpoints`; its controller routes are currently registered using `app.MapControllers()` instead.

For this classic syntax, the method must be static in a top-level, non-generic static class. Only the first parameter has `this`. The containing namespace must be in scope, usually through `using`.

## Fields and Properties

Both use member-access syntax, but their implementations differ.

### Fields

A field directly stores data. This declaration belongs inside a class:

```csharp
public string Name = string.Empty;
```

`person.Name = "Nguyen Kha An";` assigns directly to the field. Prefer private fields when other code should not freely change stored data.

### Properties

An auto-property also belongs inside a class:

```csharp
public string Name { get; set; } = string.Empty;
```

The compiler generates a hidden backing field and getter/setter accessors. `person.Name = "Nguyen Kha An";` invokes the setter; C# callers do not use a method named `setName()`.

A custom property can validate or compute values. A get-only auto-property can be initialized in its declaration or the containing type's constructor. An `init` accessor permits assignment during initialization, including an object initializer. A getter is common but not mandatory for a custom property.

## `readonly`

An instance `readonly` field can be assigned in its declaration or directly inside an instance constructor of its declaring class. After construction, it cannot be reassigned. A `static readonly` field can be initialized in its declaration or the declaring type's static constructor.

For a reference-type field, the referenced object may still be mutable: a `readonly List<string>` can still have items added. The field modifier does not apply to ordinary class properties; use a get-only or `init` property as appropriate. Other features, such as readonly structs, use `readonly` in different contexts.

## Sources

- [Object and collection initializers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers)
- [Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)
- [Anonymous types](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types)
- [Properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)
- [Extension methods](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extension)
- [`readonly`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly)
