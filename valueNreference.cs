using System;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public void Display()
    {
        Console.WriteLine($"{Name} - ₹{Price}");
    }
}

class Program
{
    static void Main()
    {
        // ============================================================
        // 1. VALUE TYPES
        // ============================================================

        // int is a value type.
        int price1 = 100;

        // Assignment copies the actual VALUE.
        int price2 = price1;

        price2 = 200;

        Console.WriteLine(price1); // 100
        Console.WriteLine(price2); // 200

        /*
            Mental model:

            price1
            ┌─────┐
            │ 100 │
            └─────┘

            price2 = price1

            price1          price2
            ┌─────┐         ┌─────┐
            │ 100 │         │ 100 │
            └─────┘         └─────┘

            Changing price2 does NOT affect price1.
        */


        // ============================================================
        // 2. STRUCTS ARE VALUE TYPES
        // ============================================================

        Point p1 = new Point();

        p1.X = 10;
        p1.Y = 20;

        // Struct assignment copies the value.
        Point p2 = p1;

        p2.X = 100;

        Console.WriteLine(p1.X); // 10
        Console.WriteLine(p2.X); // 100

        /*
            p1 and p2 are independent values.

            This is because Point is a struct,
            and structs are value types.
        */


        // ============================================================
        // 3. REFERENCE TYPES
        // ============================================================

        Product product1 = new Product();

        product1.Name = "Laptop";
        product1.Price = 50000;

        // Reference assignment copies the REFERENCE,
        // not the object itself.
        Product product2 = product1;

        product2.Price = 60000;

        Console.WriteLine(product1.Price); // 60000
        Console.WriteLine(product2.Price); // 60000

        /*
            Mental model:

                     ┌─────────────────────────┐
            product1 │ reference ──────────────┼──┐
                     └─────────────────────────┘  │
                                                  ↓
                     ┌──────────────────────────────┐
                     │ Product object               │
                     │ Name  = "Laptop"             │
                     │ Price = 60000                │
                     └──────────────────────────────┘
                                                  ↑
                     ┌─────────────────────────┐  │
            product2 │ reference ──────────────┼──┘
                     └─────────────────────────┘

            Both variables refer to the SAME object.
        */


        // ============================================================
        // 4. REFERENCE TYPE DOES NOT MEAN "PASS BY REFERENCE"
        // ============================================================

        Product product = new Product();

        product.Name = "Phone";
        product.Price = 30000;

        ChangePrice(product);

        Console.WriteLine(product.Price); // 40000

        /*
            The parameter itself is passed BY VALUE.

            What gets copied?

            The REFERENCE.

            So:

            Main's product
                  │
                  │ reference copied
                  ↓
            ChangePrice's product
                  │
                  ↓
            SAME Product object

            Therefore changing the object's state is visible
            outside the method.
        */


        // ============================================================
        // 5. VALUE TYPE PASSED TO A METHOD
        // ============================================================

        int number = 10;

        ChangeNumber(number);

        Console.WriteLine(number); // 10

        /*
            number's VALUE is copied into the method.

            Main:
                number = 10

                       ↓ copy

            Method:
                number = 10

            Method changes its own copy.

            Original remains 10.
        */


        // ============================================================
        // 6. ref PARAMETER
        // ============================================================

        int value = 10;

        ChangeNumberUsingRef(ref value);

        Console.WriteLine(value); // 20

        /*
            ref changes the parameter semantics.

            The method receives access to the
            CALLER'S VARIABLE itself.

            Main:
                value
                  │
                  └──────────────┐
                                 ↓
                            Method modifies
                            the same variable

            Therefore value becomes 20.
        */


        // ============================================================
        // 7. out PARAMETER
        // ============================================================

        int result;

        GetNumber(out result);

        Console.WriteLine(result); // 100

        /*
            out is commonly used when a method needs
            to produce an additional value.

            The caller doesn't need to initialize result first.

            The method MUST assign result before returning.
        */


        // ============================================================
        // 8. in PARAMETER
        // ============================================================

        Point point = new Point
        {
            X = 10,
            Y = 20
        };

        DisplayPoint(in point);

        /*
            'in' passes a value by reference for reading,
            while preventing the method from modifying it
            through that parameter.

            It is mainly useful for certain larger value types
            where avoiding a copy can matter.
        */


        // ============================================================
        // 9. REFERENCE TYPE + METHOD CAN MODIFY OBJECT STATE
        // ============================================================

        Product laptop = new Product
        {
            Name = "Laptop",
            Price = 50000
        };

        IncreasePrice(laptop);

        Console.WriteLine(laptop.Price); // 51000

        /*
            Again:

            The reference itself was passed by value.

            But both caller and method have a reference
            to the SAME Product object.

            Therefore the object's state changes.
        */


        // ============================================================
        // 10. REASSIGNING A REFERENCE PARAMETER
        // ============================================================

        Product phone = new Product
        {
            Name = "Phone",
            Price = 30000
        };

        ReplaceProduct(phone);

        Console.WriteLine(phone.Name);  // Phone
        Console.WriteLine(phone.Price); // 30000

        /*
            This is an important distinction.

            Inside ReplaceProduct():

                product = new Product();

            changes ONLY the local copy of the reference.

            It does NOT change which object the caller's
            variable refers to.

            So:

            Caller:
                phone ─────────→ Original Product

            Method:
                product ───────→ Original Product

            Then method does:

                product = new Product();

            Now:

            Caller:
                phone ─────────→ Original Product

            Method:
                product ───────→ New Product

            The caller still points to the original object.
        */


        // ============================================================
        // 11. CLASS VS STRUCT
        // ============================================================

        Product classProduct1 = new Product
        {
            Name = "Monitor",
            Price = 20000
        };

        Product classProduct2 = classProduct1;

        classProduct2.Price = 25000;

        Console.WriteLine(classProduct1.Price); // 25000


        Point structPoint1 = new Point
        {
            X = 10,
            Y = 20
        };

        Point structPoint2 = structPoint1;

        structPoint2.X = 100;

        Console.WriteLine(structPoint1.X); // 10
        Console.WriteLine(structPoint2.X); // 100

        /*
            CLASS
            -----

            Product p1 = ...
            Product p2 = p1;

            Both references → SAME object.


            STRUCT
            ------

            Point p1 = ...
            Point p2 = p1;

            p2 gets a COPY of the value.
        */


        // ============================================================
        // 12. STRING IS A REFERENCE TYPE BUT IMMUTABLE
        // ============================================================

        string name1 = "Laptop";

        string name2 = name1;

        name2 = "Phone";

        Console.WriteLine(name1); // Laptop
        Console.WriteLine(name2); // Phone

        /*
            string is a REFERENCE TYPE.

            But strings are IMMUTABLE.

            When we do:

                name2 = "Phone";

            we are not modifying the original "Laptop" string.

            name2 simply gets a reference to another string object.
        */


        // ============================================================
        // 13. BOXING
        // ============================================================

        int numberForBoxing = 100;

        object boxedNumber = numberForBoxing;

        /*
            int = value type
            object = reference type

            Assigning the int to object causes BOXING.

                int
                 100
                  ↓
               boxing
                  ↓
             object representation
        */

        int unboxedNumber = (int)boxedNumber;

        /*
            Converting the boxed value back to int
            is called UNBOXING.

            Unboxing requires the correct underlying value type.
        */


        // ============================================================
        // 14. BOXING CAN CAUSE RUNTIME PROBLEMS
        // ============================================================

        object valueAsObject = 100;

        // This is correct:
        int correctValue = (int)valueAsObject;

        // This would compile, but fail at runtime:
        //
        // string wrongValue = (string)valueAsObject;
        //
        // Because the actual boxed value is an int,
        // not a string.


        // ============================================================
        // 15. NULL
        // ============================================================

        Product? nullableProduct = null;

        /*
            Product is a reference type.

            Reference types can represent null.

            nullableProduct currently points to nothing.
        */

        if (nullableProduct == null)
        {
            Console.WriteLine("No product available");
        }


        // ============================================================
        // 16. NULLABLE VALUE TYPE
        // ============================================================

        int? nullableNumber = null;

        /*
            int normally cannot contain null.

            int? means:

                Nullable<int>

            It allows the value type to represent
            either an int OR null.
        */

        nullableNumber = 100;

        Console.WriteLine(nullableNumber); // 100


        // ============================================================
        // 17. THE MOST IMPORTANT COMPARISON
        // ============================================================

        int a = 10;
        int b = a;

        b = 20;

        // a = 10
        // b = 20

        Product x = new Product
        {
            Name = "Laptop",
            Price = 50000
        };

        Product y = x;

        y.Price = 60000;

        // x.Price = 60000
        // y.Price = 60000

        /*
            VALUE TYPE:

                a ──→ 10

                b = a

                a ──→ 10
                b ──→ 10

                b changes

                a ──→ 10
                b ──→ 20


            REFERENCE TYPE:

                x ─────┐
                       ↓
                  Product
                  Price = 50000
                       ↑
                y ─────┘

                y.Price = 60000

                x ─────┐
                       ↓
                  Product
                  Price = 60000
                       ↑
                y ─────┘
        */
    }



    static void ChangePrice(Product product)
    {
        product.Price = 40000;
    }


    static void ChangeNumber(int number)
    {
        number = 20;
    }


    static void ChangeNumberUsingRef(ref int number)
    {
        number = 20;
    }


    static void GetNumber(out int number)
    {
        number = 100;
    }


    static void DisplayPoint(in Point point)
    {
        Console.WriteLine($"X = {point.X}, Y = {point.Y}");

        // point.X = 100; // Not allowed because parameter is 'in'
    }


    static void IncreasePrice(Product product)
    {
        product.Price += 1000;
    }


    static void ReplaceProduct(Product product)
    {
        product = new Product
        {
            Name = "New Product",
            Price = 99999
        };
    }
}


struct Point
{
    public int X;
    public int Y;
}


class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}