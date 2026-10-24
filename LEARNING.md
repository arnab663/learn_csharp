
# Learning C# and .NET 

## Phase - 1: C# core
### 1. C# and .NET intro
- What is C# ?
    - C# is a strongly typed, object-oriented, general-purpose programming language developed by Microsoft
    - C# provides the language features but itself doesn't provide everything necessary to run an application. That's where .NET comes in
- What is .NET ?
    - Think of .NET as a development platform + runtime + libraries + tooling ecosystem
                    C# Application
                         │
                         ▼
                  ┌─────────────┐
                  │     C#      │
                  │   Language  │
                  └──────┬──────┘
                         │
                         ▼
                  ┌─────────────┐
                  │    .NET     │
                  │  Libraries  │
                  └──────┬──────┘
                         │
                         ▼
                  ┌─────────────┐
                  │ .NET Runtime │
                  │    (CLR)     │
                  └──────┬──────┘
                         │
                         ▼
                  Operating System
                         │
                         ▼
                       CPU
- What does .NET give you ?
    - Suppose you want to write: 
    ```c#
    File.ReadAllText("data.txt"); 
    ```
    You don't have to implement file-system access yourself. .NET provides libraries for this. HttpClient helps you make http reqs. 
- CLR (Common Language Runtime)
    - It's the runtime environment responsible for executing managed .NET code
- CPUs don't understand C#
C# source code
      │
      ▼
    Compiler
      │
      ▼
   IL / CIL
      │
      ▼
 .NET Runtime
      │
      ▼
     JIT
      │
      ▼
Native machine code
      │
      ▼
     CPU

    - When you build a C# application, the C# compiler converts your source code into an intermediate representation called IL(Intermediate Language)
    - CIL/MSIL
    - doesn't immediately become Intel/AMD machine instructions. It becomes IL contained inside a .NET assembly.
    - A compiled .NET application consists of assemblies. Commonly, MyApplication.dll or MyApplication.exe
    - An assembly can contain IL, metadata, type info, references, other assembly info
- .NET framework vs modern .NET
- ASP.NET Core 
    - It is not C# and it isn't the same thing as .NET. It's a web framework built on .NET
C#
 │
 ▼
.NET
 │
 ├── Base Class Libraries
 ├── Runtime
 ├── Networking
 ├── Threading
 └── ...
 │
 ▼
ASP.NET Core
 │
 ├── HTTP
 ├── Routing
 ├── Middleware
 ├── Controllers
 ├── Minimal APIs
 └── Web application infrastructure

- EF Core
    - Entity Framework Core (EF Core) is an ORM for .NET. It allows you to work with database data using C# objects and LINQ
- .csproj file 
    - It tells .NET things such as:
        - what SDK to use
        - target framework
        - project configuration
        - dependencies
        - build settings
- dotnet
You'll frequently use the .NET CLI. For example: dotnet new console - creates a project.
```bash
dotnet new console -n HelloCSharp
cd HelloCSharp
dotnet run
```
- Modern C# supports top-level statements. The compiler handles the necessary entry-point machinery for you.
- managed code
    - C# code running under the .NET runtime is generally considered managed code. The runtime manages many aspects of execution, particularly memory management.
- What happens when we do ```dotnet new console``` or ```dotnet run``` ?
<hr>

### 2. Variables and types
- statically typed
- built-in types:
| Type      | Example      | Typical use                         |
| --------- | ------------ | ----------------------------------- |
| `int`     | `42`         | Whole numbers                       |
| `long`    | `123456789L` | Large whole numbers                 |
| `short`   | `100`        | Smaller integers                    |
| `byte`    | `255`        | 0–255 values                        |
| `float`   | `3.14f`      | Floating-point numbers              |
| `double`  | `3.14`       | General floating-point calculations |
| `decimal` | `99.99m`     | Financial/decimal calculations      |
| `bool`    | `true`       | True/false                          |
| `char`    | `'A'`        | Single character                    |
| `string`  | `"Hello"`    | Text                                |
| `object`  | anything     | Base type of the .NET type system   |
- strings are reference types and immutable
- object
- explicit typing
- var
- dynamic
- const
- readonly 
        readonly means the field can generally be assigned:
        - at its declaration, or
        - in a constructor
        and then cannot be reassigned.
        This is different from const.
- type conversion (explicit/implicit, Convert, parse)
- null
- Nullable value types
- type safety, type inference with var
- compile time vs run time types

<hr>

### 3. Value and Reference types
- value types
- reference types
- copy rule
- difference in method calls
- "ref types" does not mean "pass by ref"
- case of string (ref type and immutability)
- struct vs class
- stack and heap 
- boxing/unboxing


<hr>

### 4. Operators and control flow
ARITHMETIC
────────────────────
+    addition
-    subtraction
*    multiplication
/    division
%    remainder

ASSIGNMENT
────────────────────
=    assignment
+=   add and assign
-=   subtract and assign
*=   multiply and assign
/=   divide and assign

COMPARISON
────────────────────
==   equal
!=   not equal
>    greater
<    less
>=   greater/equal
<=   less/equal

LOGICAL
────────────────────
&&   AND
||   OR
!    NOT

NULL
────────────────────
?.   null conditional
??   null coalescing
??=  null coalescing assignment

INCREMENT
────────────────────
++   increment
--   decrement

CONTROL FLOW
────────────────────
if / else
switch
for
foreach
while
do while
break
continue
return

CONDITIONAL
────────────────────
condition ? A : B

<hr>

### 5. Methods
```csharp
Order CreateOrder(
    Customer customer,
    List<OrderItem> items)
```
"This accepts a Customer and a collection of OrderItems, and produces an Order. I should investigate whether it modifies the customer/items and what validations or external operations happen inside."
- method with no param, no return
- method with params
- param vs arg, positional arguments, named arguments
- ref, out, in
- optional params
- method overloading
- method expressions
- local variables and scope
- static vs instance methods

<hr>

### 6. Classes and Objects
- class, object, creating an object, initializing an object
- calling an instance method
- this
```csharp
class Person
{
    private string name;

    public Person(string name)
    {
        this.name = name;
    }
}
```
- constructor
```csharp
class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```
- default constructor, constructor overloading
- instance field vs static field
- access modifiers
- properties vs fields
- null object references
- new
- class relationships
- methods returning objects

<hr>

### 7. Properties and constructors
- fields vs properties (anyone can change a field directly)
- why property instead of a public field ? 
```csharp
class Product
{
    private decimal _price;

    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative");

            _price = value;
        }
    }
}
```
- value keyword (the value the caller is trying to assign)
- auto-implemented property
instead of 
```csharp
private string _name;

public string Name
{
    get
    {
        return _name;
    }
    set
    {
        _name = value;
    }
}
```
we write:
```csharp
public string Name { get; set; }
```
- Read-only from outside: private set
- computed properties
```csharp
public class Product
{
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public decimal Total => Price * Quantity;
}
```
- read-only properties
- init
- why constructors ?
- constructor validation
- constructor + properties
- constructor overloading
- constructor chaining
- object initializers (constructor still runs first)
- this vs this(...)
- required properties (compile-time errors if required properties are not initialized)
- nullable properties

<hr>

### 8. Encapsulation
- what and why ?
- acess modifiers
```csharp
public class BankAccount
{
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds.");

        Balance -= amount;
    }
}
```
- Does this property represent data that anyone should be able to change, or state that should be controlled by the object ?
- The real idea is: Expose a clear public API and hide implementation details that callers shouldn't depend on
- protected
- internal 
- try to build a model: Order/Customer/Product

<hr>

### 9. Inheritance
- basic idea
```csharp
public class Developer : Employee // Employee: base class/parent class/superclass and Developer: derived class/child class/subclass
{
}
```
- The Order might have a Customer. But the "Order IS-A Customer" is wrong. That is composition rather than inheritance. 
- Inheritance: IS-A relationship, Composition: HAS-A relationship
- base constructor
eg. 1
```csharp
public class Employee
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
    }
}
```
Now
```csharp
public class Developer : Employee
{
    public Developer(string name)
        : base(name)
    {
    }
}
```
eg. 2
```csharp
public class Employee
{
    public int Id { get; }

    public string Name { get; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void TakeLeave()
    {
        Console.WriteLine($"{Name} is taking leave.");
    }
}
```
Now
```csharp
public class Developer : Employee
{
    public string ProgrammingLanguage { get; }

    public Developer(
        int id,
        string name,
        string programmingLanguage)
        : base(id, name)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public void WriteCode()
    {
        Console.WriteLine(
            $"{Name} is writing {ProgrammingLanguage} code.");
    }
}
```
- protected
- base vs this
- overriding behaviour (virtual - it means a derived class is allowed to provide its own implementation)
```csharp
public class Employee
{
    public virtual void Work()
    {
        Console.WriteLine("Employee is working.");
    }
}
```
and for the child class, if we override the method
```csharp
public class Developer : Employee
{
    public override void Work()
    {
        Console.WriteLine("Developer is writing code.");
    }
}
```
- base.Method()
Suppose the child wants to extend rather than completely replace the parent's behavior
```csharp
public class Developer : Employee
{
    public override void Work()
    {
        base.Work();

        Console.WriteLine("Developer writes code.");
    }
}
```
- virtual vs override
- abstract classes
- sealed class (to prevent inheritance from a class)
- single class inheritance in c#

<hr>

### 10. Interface
We might have:
```csharp
public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount);
}
```
Then:
```csharp
public class CardPaymentProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine(
            $"Processing card payment: {amount}");

        return true;
    }
}
```
And:
```csharp
public class UpiPaymentProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine(
            $"Processing UPI payment: {amount}");

        return true;
    }
}
```
Then the order service:
```csharp
public class OrderService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public OrderService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void PayOrder(decimal amount)
    {
        bool success =
            _paymentProcessor.ProcessPayment(amount);

        if (success)
        {
            Console.WriteLine("Order paid.");
        }
    }
}
```
Notice what OrderService does not know: Card,UPI,Bank API,Payment gateway,HTTP,Database
It only knows: IPaymentProcessor -> ProcessPayment()
This is the kind of decoupling you'll see in professional .NET code.


Imagine our Order Management System needs to send notifications.
We might have: Email,SMS,Push notification
All of them can send a notification, but their implementations are completely different.
We could use inheritance:
Notification
    │
    ├── EmailNotification
    ├── SmsNotification
    └── PushNotification
But what we're really interested in isn't necessarily their common identity. We're interested in their capability:
"Can send a notification."
An interface lets us express exactly that.
```csharp
public interface INotificationSender
{
    void Send(string message);
}
```
Anything that implements INotificationSender must provide a Send method that accepts a string. We haven't said how the message gets sent.
The interface defines a contract.
INotificationSender
        │
        │ contract
        ▼
     Send()

- implementing an interface
```csharp
public class EmailNotificationSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}
```
- key idea: contract vs implementation
<hr>

## Phase - 2: Collection and Generics
- arrays
- ```List<T>```
    - Add
    - Remove
    - foreach
- generic class
- generic method
- Generics allow you to write reusable types and methods that work with different types while preserving compile-time type safety.
- ```Dictionary<TKey, TValue>```
```csharp
if (employees.TryGetValue(101, out string name))
{
    Console.WriteLine(name);
}
```
- iterating through a dictionary
```csharp
foreach (KeyValuePair<int, string> employee in employees)
{
    Console.WriteLine(employee.Key);
    Console.WriteLine(employee.Value);
}
```
- initializing a dictionary
```csharp
Dictionary<int, string> employees = new()
{
    { 101, "Arnab" },
    { 102, "Rahul" },
    { 103, "Priya" }
};
```
or 
```csharp
Dictionary<int, string> employees = new()
{
    [101] = "Arnab",
    [102] = "Rahul",
    [103] = "Priya"
};
```
- generic constraints
    - ```where T : class``` means T must be a reference type
    - ```where T : struct``` means T must be a value type
    - ```where T : new()``` means T must have a public parameterless constructor
    - ```where T : SomeBaseClass``` means T must inherit from SomeBaseClass
    - ```where T : ISomeInterface``` means T must implement ISomeInterface
- multiple constraints
```csharp
public class Repository<T>
    where T : class, IEntity, new()
{
    // Implementation
}
```
- generic interfaces
```csharp
public interface IRepository<T>
{
    void Add(T item);
    T GetById(int id);
}
```
- generic delegates
- generic events
- generic collections
```csharp
List<T>
```
- generic methods
```csharp
public void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}
```
- generic type inference
```csharp
var list = new List<int>(); // The compiler infers that T is int
```
- generic covariance and contravariance
```csharp
public interface ICovariant<out T>
{
    T GetItem();
}
```
- generic constraints with interfaces
```csharp
public interface IRepository<T> where T : IEntity
{
    void Add(T item);
    T GetById(int id);
}
```
- generic constraints with base classes
```csharp
public class Repository<T> where T : BaseEntity
{
    public void Add(T item)
    {
        // Implementation
    }
}
```
- generic constraints with multiple interfaces
```csharp
public class Repository<T> where T : IEntity, IValidatable
{
    public void Add(T item)
    {
        // Implementation
    }
}
```
- generic constraints with new()
```csharp
public class Repository<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
```
- generic constraints with interface and class
```csharp
public class Repository<T> where T : class, IEntity
{
    // Implementation
}
```
- generic constraints with struct and interface
```csharp
public class Repository<T> where T : struct, IComparable
{
    // Implementation
}
```



<hr>

## Phase - 3: IEnumerable<T> + LINQ
- IEnumerable<T> is an interface that represents a sequence of elements that can be enumerated. It provides a way to iterate over a collection of items without exposing the underlying data structure.
```csharp
public interface IEnumerable<out T> : IEnumerable
{
    IEnumerator<T> GetEnumerator();
}
```
- LINQ (Language Integrated Query) is a set of features in C# that allows you to query and manipulate data in a more declarative and expressive way. It provides a unified syntax for querying different data sources, such as collections, databases, XML, and more.
- LINQ query syntax
```csharp
var query = from item in collection
            where item.Property > 10
            orderby item.Property
            select item;
```
- LINQ method syntax
```csharp
var result = collection
    .Where(item => item.Property > 10)
    .OrderBy(item => item.Property)
    .Select(item => item);
```
- deferred execution
    - LINQ queries are not executed until you iterate over the results. This allows for efficient querying and filtering of data.
    - For example, if you have a LINQ query that filters a collection, the filtering will not be performed until you actually iterate over the results using a `foreach` loop or call a method like `ToList()` or `ToArray()`.
- LINQ operators
    - LINQ provides a wide range of operators for querying and manipulating data, including filtering, projection, sorting, grouping, joining, and more. Some commonly used operators include:
        - `Where`: Filters elements based on a condition.
        - `Select`: Projects elements into a new form.
        - `OrderBy` / `OrderByDescending`: Sorts elements in ascending or descending order.
        - `GroupBy`: Groups elements based on a key.
        - `Join`: Joins two collections based on a common key.
        - `Distinct`: Removes duplicate elements from a collection.
        - `Take` / `Skip`: Retrieves a specified number of elements or skips a specified number of elements.
- LINQ to Objects
    - LINQ to Objects allows you to query in-memory collections, such as arrays, lists, and other IEnumerable<T> implementations. It provides a convenient way to work with data in a more expressive manner.
- LINQ to SQL
    - LINQ to SQL allows you to query relational databases using LINQ syntax. It provides a way to map database tables to C# classes and perform queries against the database using LINQ.
- LINQ to Entities
    - LINQ to Entities is part of the Entity Framework and allows you to query databases using LINQ syntax. It provides a higher-level abstraction over LINQ to SQL and supports more advanced features like navigation properties and relationships between entities.
- immediate execution
    - Some LINQ methods, such as `ToList()`, `ToArray()`, and `Count()`, trigger immediate execution of the query and return the results immediately. These methods force the evaluation of the query and return a concrete collection or value.


<hr>

## Phase - 4: Delegates and Lambdas

<hr>

## Phase - 5: Exception and error handling

<hr>

## Phase - 6: Async/Await/Tasks

<hr>

## Phase - 7: Memory and resource management