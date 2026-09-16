## List 
```csharp
List<string> names = new()
{
    "Alice", "Bob", "Anna"
}; //This is similar one with: names.Add("Alice"); names.Add("Bob"); names.Add("Anna"); 

//Modern list in c# 
List<string> cloudianNames = [
    "Alice", "Bob", "Anna"
];
```

## Target Typed 
The compiler can determine the type of an expression from the context where that expression is used. This allow you to omit type information when the compiler already knows it. 

**For example:** 

`GameDto game = new GameDto("game-1", 12, "Combat")`

- Because we have GameDto in the start line, the compilers already know that 
game has GameDto type. We can remove GameDto after new keyword: `GameDto game = new("game-1", 12, "Combat")`

- But, we have to keep () before new(), don't write only new()  

## { } syntax 
### Object Initializer 
An object initializer lets you create an object and assign its properties in the same statement 

**Example**: 
```csharp 
public class Person {
    public string Name {get; set;} 
    public int Age {get; set;} 
} 
var person = new Person {
    Name = "Nguyen Kha An", Age = 20
}
```
Conceptually, it is similar to:
```csharp
var person = new Person();

person.Name = "Alice";
person.Age = 20; 
```
### Collection Initializer 
Similar to object initializer, but instead of assigning, it initializes the **elements of a collections**

**Example**: 
```csharp
var names = new List<string> {
    "Alice", "Bob", "Anna" 
}; 

```
Conceptally, it is similar to 
```csharp 
var names = new List<string>();

names.Add("Alice");
names.Add("Bob");
names.Add("Charlie");
```

### Pattern Matching 
This one is different. In pattern matching, { } does not initialize anything. Instead, it describes the shape or properties that an existing object must match.

```csharp
if (person is Person { Name: "Alice" })
{
    Console.WriteLine("This is Alice");
} 
```
With =, you are saying: set name to Alice. However, : is a pattern matching, it means whether name is Alice. 

## lambda expression 

Syntax: `(parameter) => expression`

**For example**: We can write: (x) => x*2 or (x, y) => (x + y) 

- We can make a variables to store this lambda function by using `Func<T>` type. `Func<T>` is a delegate type. 

A **delegate type** is a type can store function and let you call that function later. Or, anything that matches a function signature and can be called like a function. 

```csharp 
Func<int, int, int> sumTwoNumber = (x,y) => x+y; 
// Then we cal using this: 
Console.WriteLine(sumTwoNumber(3,4)); 
```
### delegate 
A **delegate type** is a type can store function and let you call that function later. Or, anything that matches a function signature and can be called like a function. 

A `Func<int, int, int>` is a special delegate. We can use it to store function or lambda expression (because they is like function a lot) 

```csharp 
public void Add(int a, int b) {
    return a + b; 
} 
Func<int, int, int> add = Add; 
Console.WriteLine(add(4,5)); 
Func<int, int, int> minus = (a,b) => a - b; 
```

By the way, we can also define a custom delegate with `delegate` keyword 

**Syntax**: `delegate KDL name(parameters)`

**Caution**: This is not valid: `Func<int,int,int> add(int a, int b)` (define like a delegate). Because delegate will tell the compiler to create a new delegate, Func is already a generic delegate type, so it cannot use to request compiler create a new delegate type. 

## Way to define an instance in c# 

Ở sau chỉ được phép để trống (nhưng vẫn phải có ()) nế ở trước đã được define Kiểu dữ liệu. Còn lại thì ở sau phải viết rõ KDL ra. Lúc này, dấu () hay { } có hay không cũng không quan trọng. 

## Annonymous object 
- Annonymous object is a instance that don't have datatype. 

```csharp
var person = new {
    Name = "Nguyen Kha An", Age = 20
}; 
//Because it don't have datatype, so we use var and don't adding () to its syntax
```

## object type 
In c#, object is the base type of all types. 

For example: 
```csharp
object x = 10; 
object y = "Hello": 
object z = new Person();  
```
All of these things are object.

**Compare object and var**: 
```csharp
var x = 10;
object y = 10;
```
With var, the compiler knows: x -> int; but with object, even though the real store is int, the compiler still knows it as an object -> You have to check the type (GPT for syntax)

## casting type
(Type)value is a casting syntax. They will change an object to another type. 

**Change string to number**:
```csharp
string s = "123";
int number = int.Parse(s);
```

**Change number to string**:
```csharp
string s = number.ToString();
```


## static class & extension method 
### static class 
Static class is a class that cannot create an instance from this 

**Syntax**: `public static ClassName()`

```csharp
public static GameEndpoints 
{
    private static readonly string Name = "MMM"; 
}
```

In the static class, all things have to define in static way, including fields and methods. 

### extension method 
It lets you to create a method that lets instance of another class uses. 

For example: 
```csharp
public static GameEndpoints 
{
    private static readonly string Name = "MMM"; 
    public static MapGameEndpoints(this WebApplication web) 
    {
        ... 
        //Something write here
    }
}
```

In another file, we can write: 
```csharp
web.MapGameEndpoints() 
```

**Notice 1**: You can only have 1 this parameter, and it must be the first parameter

**Notice 2**: Extension method must be static.


