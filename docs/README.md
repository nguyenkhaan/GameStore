# Dotnet Noodles: A C# Mini Course

Start here if you are new to C#. The lessons begin with values and control flow, then introduce objects and the syntax used in this project's game API. Read in order and try the practice prompt in each file.

## Run the examples

Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0), then create a separate console project so you can experiment without changing the API:

```bash
dotnet new console -n CSharpPractice --framework net10.0
cd CSharpPractice
dotnet run
```

Paste each example into `Program.cs`. Examples are separate unless described as continuations; do not combine repeated variable or type declarations. Put top-level statements and local functions before class, record, interface, and delegate declarations. Member-only snippets belong inside a type. Numeric output may use a different decimal separator depending on your current culture.

The course uses .NET 10 with its default C# 14 language version and nullable analysis enabled. It keeps the classic extension-method syntax used by the project.

## Part 1: Values, Decisions, and Functions

Start with C# values, decisions, and reusable functions.

| Lesson | What you will learn |
| --- | --- |
| [00. Data Types](00.DataTypes.md) | Numbers, text, Booleans, and value/reference types |
| [01. Variables](01.Variables.md) | Declaration, assignment, constants, and scope |
| [02. Conversion and Casting](02.TypeConversionAndCasting.md) | Numeric conversions, parsing, and type checks |
| [03. var, dynamic, and object](03.VarDynamicAndObject.md) | Type inference and compile-time/runtime checking |
| [04. If and Else](04.IfElse.md) | Conditions, comparisons, and logical operators |
| [05. Loops](05.Loops.md) | for, while, do/while, and foreach |
| [06. Functions and Methods](06.Methods.md) | Parameters, arguments, return values, and void |
| [07. Lambdas and Expression Bodies](07.LambdasAndExpressionBodies.md) | Both uses of the arrow syntax |
| [08. Func, Action, and Delegates](08.FuncActionAndDelegates.md) | Storing and passing behavior |
| [09. Nullable Variables](09.NullableTypes.md) | Missing values and safe null handling |
| [10. Lists](10.Lists.md) | Generic collections and common operations |

## Part 2: Modeling Data and Behavior

Learn to model data and behavior with objects.

| Lesson | What you will learn |
| --- | --- |
| [11. Classes and Objects](11.Classes.md) | Instances, members, and shared references |
| [12. Fields and Properties](12.FieldsAndProperties.md) | Storage, accessors, and validation |
| [13. Constructors](13.Constructors.md) | Ordinary and primary constructors |
| [14. Interfaces](14.Interfaces.md) | Contracts implemented by different classes |
| [15. Inheritance](15.Inheritance.md) | Base classes, overrides, and polymorphism |
| [16. Records](16.Records.md) | Data types, value equality, and with expressions |

## Part 3: Reading the Project's Syntax

Learn the construction and helper syntax used in this project.

| Lesson | What you will learn |
| --- | --- |
| [17. Creating Objects](17.CreatingObjects.md) | Compare different construction forms |
| [18. Target-Typed new](18.TargetTypedNew.md) | Let the expected type guide construction |
| [19. Object Initializers](19.ObjectInitializers.md) | Assign members while creating an object |
| [20. Collection Initializers](20.CollectionInitializers.md) | Create collections with initial items |
| [21. Pattern Matching](21.PatternMatching.md) | Test types and property values |
| [22. Anonymous Types](22.AnonymousTypes.md) | Local data without a named class |
| [23. Static Classes](23.StaticClasses.md) | Members that belong to the type |
| [24. Extension Methods](24.ExtensionMethods.md) | Add helper syntax to existing types |
| [25. readonly Fields](25.ReadonlyFields.md) | Protect field assignments after construction |

