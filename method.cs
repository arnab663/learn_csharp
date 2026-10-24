// using System;


// static void sayHello()
// {
//     Console.WriteLine("Hello");
// }

// sayHello();



// static void Greet(string name)
// {
//     Console.WriteLine($"Hello {name}");
// }

// Greet("Arnab");


// static void Change(int number)
// {
//     number = 1000;
// }

// int x = 10;

// Change(x);

// Console.WriteLine(x);


// static void ChangeName(Person person)
// {
//     person.Name = "abc";
// }

// Person p = new Person();
// p.Name = "Arnab";
// Console.WriteLine(p.Name);

// ChangeName(p);
// Console.WriteLine(p.Name);


// static void changeRef(ref int number)
// {
//     number = 1000;
// }

// changeRef(ref x);
// Console.WriteLine(x);


// static bool TryDivide(int a, int b, out int result)
// {
//     if(b == 0)
//     {
//         result = 0;
//         return false;
//     }
//     else result = a/b;
//     return true;
// }

// bool success = TryDivide(10, 0, out int result);
// Console.WriteLine(Convert.ToString(success), result);











// class Person
// {
//     public string Name {get; set;}
// }




using System;

class Program
{
    static void Main()
    {
        decimal total = CalculateOrderTotal(
            price: 1500m,
            quantity: 2,
            discountPercentage: 10m);

        Console.WriteLine($"Total: {total}");

        if (TryParseQuantity("5", out int quantity))
        {
            Console.WriteLine($"Quantity = {quantity}");
        }
    }

    static decimal CalculateOrderTotal(
        decimal price,
        int quantity,
        decimal discountPercentage)
    {
        if (price <= 0 || quantity <= 0)
        {
            return 0;
        }

        decimal subtotal = price * quantity;

        decimal discount =
            subtotal * discountPercentage / 100m;

        return subtotal - discount;
    }

    static bool TryParseQuantity(
        string input,
        out int quantity)
    {
        return int.TryParse(input, out quantity);
    }
}