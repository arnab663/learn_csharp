/*
 Imagine you're developing an e-commerce application. You have different ways to send notifications:
- Email
- SMS
- Push notification
Each notification system works differently internally. However, your application needs a common way to ask any of them to send a message.

Without a common contract, you might write this:
 */
//class EmailNotifier
//{
//    public void SendEmail(string message)
//    {
//        Console.WriteLine($"Email: {message}");
//    }
//}

//class SmsNotifier
//{
//    public void SendSms(string message)
//    {
//        Console.WriteLine($"SMS: {message}");
//    }
//}


//  An interface is a contract that specifies a set of members a type must provide when it implements that interface.
interface INotifier
{
    void Send(string message);
}

class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

class SmsNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }
}


//static void NotifyCustomer(INotifier notifier)
//{
//    notifier.Send("Your order has shipped!");
//}
//INotifier email = new EmailNotifier();
//INotifier sms = new SmsNotifier();

//NotifyCustomer(email);
//NotifyCustomer(sms);

/*
1. new EmailNotifier() creates an EmailNotifier instance.
2. The variable notifier is declared with the interface type INotifier.
3.The variable holds a reference to that object.
4. The compiler permits calls to members exposed by INotifier.
5. At runtime, the implementation provided by EmailNotifier runs.
The declared type is INotifier; the runtime type is EmailNotifier.


Class -	A type that can define state and behavior and be instantiated if it's not abstract.
Interface -	A contract describing capabilities a type can provide.
Abstract class -	A base class that can share state and implementation while requiring derived classes to implement certain members.
*/

interface IShape
{
    double CalculateArea();
}

abstract class Shape : IShape
{
    public string Color { get; set; } = "Black";

    public abstract double CalculateArea();

    public void Describe()
    {
        Console.WriteLine($"This shape is {Color}.");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}



// A class can inherit from only one class directly, but it can implement multiple interfaces. This is important because a type may have several independent capabilities.

// A useful rule of thumb: use an interface when you want to define a contract that different types can implement; use an abstract class when you also need a shared base implementation or state.


// An interface can specify methods, properties, indexers, and events.
interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
}

class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}





// How interfaces connect to IEnumerable<T> and LINQ
List<Product> products = new()
{
    new Product { Id = 1, Name = "Laptop", Price = 900m },
    new Product { Id = 2, Name = "Mouse", Price = 25m },
    new Product { Id = 3, Name = "Monitor", Price = 300m }
};
foreach(Product product in products)
{
    Console.WriteLine($"{product.Name} costs {product.Price:C}");
}

/*
But why does foreach work on a List<Product>?

Because List<T> supports the enumeration pattern and implements IEnumerable<T> (among other interfaces).

Let's understand that contract.
What does IEnumerable<T> mean?
IEnumerable<T> is a generic interface in the System.Collections.Generic namespace.
Its central purpose is to represent something you can enumerate — visit one item at a time.
Its essential contract is:
public interface IEnumerable<out T> : IEnumerable
{
    IEnumerator<T> GetEnumerator();
}
This is a simplified view of the relevant interface declaration. The real framework interface also inherits from the non-generic IEnumerable.
- IEnumerable<T>: represents a sequence of items of type T.
- T: a generic type parameter. For IEnumerable<Product>, T is Product; for IEnumerable<int>, T is int.
- GetEnumerator(): obtains an object that knows how to move through the sequence.
- out T: declares covariance, an advanced feature we'll cover after the core concepts.
The key point is that IEnumerable<T> doesn't require a collection to be stored in a particular way. It only represents something that can provide an enumeration of T items.

For example, a sequence might come from:
- A List<T> stored in memory
- An array
- A database query
- A generated sequence of values
- A custom iterator that produces items on demand
These sources can all be consumed through the same interface.

The relationship between IEnumerable<T> and IEnumerator<T>
IEnumerable<T>
The thing you can enumerate

Provides GetEnumerator() to obtain an enumerator.

GetEnumerator()

IEnumerator<T>
The object that moves through the sequence

Provides MoveNext() and Current to visit elements, plus Reset() in the interface contract.
public interface IEnumerator<out T> : IDisposable
{
    T Current { get; }
    bool MoveNext();
}

Here's what happens conceptually when a foreach loop runs:
1. It obtains an enumerator.
2. It calls MoveNext() to advance to the next item.
3. If MoveNext() returns true, it reads Current.
4. It executes the loop body for that item.
5. It repeats until MoveNext() returns false.
6. The enumerator is disposed when appropriate.


This will work too:
List<int> numbers = new() { 10, 20, 30 };

IEnumerable<int> sequence = numbers;

foreach (int number in sequence)
{
    Console.WriteLine(number);
}

Q. Why not always List<T> instead of IEnumerable<T>?
static void PrintNumbers(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        Console.WriteLine(number);
    }
}
List<int> list = new() { 1, 2, 3 };
int[] array = { 4, 5, 6 };

PrintNumbers(list);
PrintNumbers(array);
PrintNumbers(Enumerable.Range(7, 3));


"Accept the least restrictive interface that provides the capabilities your method actually needs."

If your method only needs to read items one at a time, IEnumerable<T> is often a good choice. 
If it needs to add or remove items, another type or interface may be necessary.

(now go to LINQ.cs)
*/