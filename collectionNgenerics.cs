
using System.Dynamic;


static void Print<T>(T value)
{
    Console.WriteLine(value);
}


Container<int> IntegerNumber = new();
IntegerNumber.Value = 100;




List<int> numbers = new();
for(int i=1; i<=5; i++) numbers.Add(i*10);

foreach(int number in numbers)
{
    Console.WriteLine(number);
}


Print(100);
Print(numbers);
Print("asdfgh");



class Container<T>
{
    public T Value { get; set; }
}
