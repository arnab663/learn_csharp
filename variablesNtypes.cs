// TOPIC 2 — C# VARIABLES & TYPES

public class Program
{
    public static void Main()
    {
        // ========================================================
        // 1. BASIC VARIABLES
        // ========================================================
        
        int age = 25;

        string name = "Arnab";

        bool isActive = true;

        char grade = 'A';

        Console.WriteLine(age);
        Console.WriteLine(name);
        Console.WriteLine(isActive);
        Console.WriteLine(grade);


        // ========================================================
        // 2. INTEGER TYPES
        // ========================================================

        // int = 32-bit signed integer
        int population = 1_000_000;

        // long = 64-bit signed integer
        // L suffix indicates a long literal
        long largeNumber = 5_000_000_000L;

        // short = 16-bit signed integer
        short temperature = 30;

        // byte = 8-bit unsigned integer (0 - 255)
        byte percentage = 100;

        Console.WriteLine(population);
        Console.WriteLine(largeNumber);
        Console.WriteLine(temperature);
        Console.WriteLine(percentage);


        // ========================================================
        // 3. FLOATING-POINT TYPES
        // ========================================================

        // float = 32-bit floating-point number
        // 'f' suffix is required for a float literal
        float height = 5.9f;

        // double = 64-bit floating-point number
        // Decimal literals are double by default
        double average = 87.42;

        // decimal = high-precision decimal arithmetic
        // 'm' suffix indicates a decimal literal
        // Commonly preferred for monetary/business calculations
        decimal price = 199.99m;

        Console.WriteLine(height);
        Console.WriteLine(average);
        Console.WriteLine(price);


        // ========================================================
        // 4. WHY DECIMAL CAN BE IMPORTANT
        // ========================================================

        // Binary floating-point numbers cannot represent
        // many decimal fractions exactly.
        double d1 = 0.1;
        double d2 = 0.2;

        double doubleResult = d1 + d2;

        Console.WriteLine(doubleResult);
        // May produce:
        // 0.30000000000000004


        // decimal uses decimal-based representation and can
        // represent these particular decimal values exactly.
        decimal m1 = 0.1m;
        decimal m2 = 0.2m;

        decimal decimalResult = m1 + m2;

        Console.WriteLine(decimalResult);
        // 0.3


        // ========================================================
        // 5. VAR — TYPE INFERENCE
        // ========================================================

        // 'var' does NOT mean "any type".
        // The compiler determines the type at compile time.

        var employeeName = "Rahul";       // string
        var employeeAge = 30;             // int
        var employeeSalary = 75000.50m;   // decimal
        var employeeActive = true;        // bool

        Console.WriteLine(employeeName);
        Console.WriteLine(employeeAge);
        Console.WriteLine(employeeSalary);
        Console.WriteLine(employeeActive);


        // This would NOT compile:
        //
        // var number = 10;
        // number = "Hello";
        //
        // Because the compiler inferred:
        //
        // number -> int
        //
        // 'var' is still strongly typed.


        // ========================================================
        // 6. DYNAMIC — DIFFERENT FROM VAR
        // ========================================================

        // dynamic postpones many type checks until runtime.

        dynamic value = 10;

        Console.WriteLine(value);

        // This is allowed with dynamic:
        value = "Hello";

        Console.WriteLine(value);

        value = true;

        Console.WriteLine(value);

        // Remember:
        //
        // var     -> type determined at compile time
        // dynamic -> operations/type behavior resolved at runtime


        // ========================================================
        // 7. OBJECT
        // ========================================================

        // object is the base type of the .NET type system.
        //
        // It can hold values of many different types.

        object data = 100;

        Console.WriteLine(data);

        data = "Hello";

        Console.WriteLine(data);

        data = true;

        Console.WriteLine(data);

        // Although object can hold many types, don't use object
        // unnecessarily.
        //
        // Prefer:
        //
        // int age = 25;
        //
        // over:
        //
        // object age = 25;
        //
        // when you know the value should be an integer.


        // ========================================================
        // 8. CONSTANTS
        // ========================================================

        // const means the value cannot be changed after declaration.
        //
        // Constants are compile-time constants.

        const int MaxRetries = 3;

        const decimal TaxRate = 0.18m;

        Console.WriteLine(MaxRetries);
        Console.WriteLine(TaxRate);

        // This would NOT compile:
        //
        // MaxRetries = 5;


        // ========================================================
        // 9. NULL
        // ========================================================

        // null represents the absence of a value/reference.

        // In modern C# with nullable reference types enabled,
        // this is generally discouraged/warns:
        //
        // string name2 = null;


        // Use '?' when the reference is intentionally allowed
        // to be null:
        string? optionalName = null;

        Console.WriteLine(optionalName);


        // ========================================================
        // 10. NULLABLE VALUE TYPES
        // ========================================================

        // Normal int cannot contain null:
        int normalAge = 25;

        // int? can contain either an integer OR null.
        int? optionalAge = null;

        Console.WriteLine(normalAge);
        Console.WriteLine(optionalAge);

        // int? is shorthand for:
        //
        // Nullable<int>


        // ========================================================
        // 11. TYPE CONVERSION — IMPLICIT
        // ========================================================

        // int -> double is an implicit conversion.
        //
        // The compiler allows this because the conversion can
        // safely represent the integer value.

        int integerValue = 100;

        double doubleValue = integerValue;

        Console.WriteLine(doubleValue);


        // ========================================================
        // 12. TYPE CONVERSION — EXPLICIT CASTING
        // ========================================================

        // double -> int can lose information.
        //
        // Therefore we explicitly tell the compiler to perform
        // the conversion.

        double originalValue = 10.75;

        int convertedValue = (int)originalValue;

        Console.WriteLine(convertedValue);

        // Output:
        // 10
        //
        // The fractional part is discarded.


        // ========================================================
        // 13. CONVERT
        // ========================================================

        string numberText = "123";

        int number = Convert.ToInt32(numberText);

        Console.WriteLine(number);


        // ========================================================
        // 14. PARSE
        // ========================================================

        string ageText = "25";

        int parsedAge = int.Parse(ageText);

        Console.WriteLine(parsedAge);

        // Be careful:
        //
        // int.Parse("hello");
        //
        // throws a FormatException.


        // ========================================================
        // 15. TRYPARSE
        // ========================================================

        // TryParse is safer when invalid input is expected.

        string userInput = "123";

        bool success = int.TryParse(
            userInput,
            out int parsedNumber
        );

        Console.WriteLine(success);
        Console.WriteLine(parsedNumber);

        // success -> tells us whether conversion succeeded
        // parsedNumber -> contains the converted number


        // Example of failed parsing:

        string invalidInput = "hello";

        bool conversionSucceeded = int.TryParse(
            invalidInput,
            out int result
        );

        Console.WriteLine(conversionSucceeded);

        // false


        // ========================================================
        // 16. DATE/TIME
        // ========================================================

        DateTime joiningDate =
            new DateTime(2025, 6, 10);  // y m d

        Console.WriteLine(joiningDate);


        // Nullable DateTime:
        //
        // Useful when the date may not exist.

        DateTime? terminationDate = null;

        Console.WriteLine(terminationDate);


        // ========================================================
        // 17. REALISTIC E-COMMERCE EXAMPLE
        // ========================================================

        // Imagine these are properties of a product.

        long productId = 982374982374L;

        string productName = "Mechanical Keyboard";

        decimal productPrice = 4999.99m;

        int productQuantity = 10;

        bool productIsActive = true;

        decimal discountPercentage = 15.5m;

        Console.WriteLine(productId);
        Console.WriteLine(productName);
        Console.WriteLine(productPrice);
        Console.WriteLine(productQuantity);
        Console.WriteLine(productIsActive);
        Console.WriteLine(discountPercentage);


        // ========================================================
        // 18. A FEW IMPORTANT LITERAL EXAMPLES
        // ========================================================

        int intValue = 100;

        long longValue = 100L;

        float floatValue = 100.5f;

        double doubleLiteral = 100.5;

        decimal decimalValue = 100.5m;

        char character = 'A';

        string text = "Hello";

        bool flag = true;


        // ========================================================
        // 19. STRONG TYPE SAFETY
        // ========================================================

        int quantity = 10;

        // This is invalid:
        //
        // quantity = "ten";
        //
        // Because quantity is an int.

        string message = "Hello";

        // This is invalid:
        //
        // message = 100;
        //
        // Because message is a string.


        // ========================================================
        // 20. COMPILE-TIME TYPE VS RUNTIME TYPE
        // ========================================================

        // The compiler knows:
        //
        // intValue -> int
        //
        // For inheritance/interfaces, however, the compile-time
        // type and runtime type can differ.
        //
        // Example (conceptually):
        //
        // IAnimal animal = new Dog();
        //
        // Compile-time type -> IAnimal
        // Runtime type       -> Dog
        //
        // We'll study this deeply when we reach
        // Interfaces and Polymorphism.


        // ========================================================
        // QUICK SUMMARY
        // ========================================================

        Console.WriteLine();

        Console.WriteLine("C# is statically typed.");
        Console.WriteLine("var uses compile-time type inference.");
        Console.WriteLine("dynamic defers type-related checks to runtime.");
        Console.WriteLine("object can reference many different types.");
        Console.WriteLine("const represents a compile-time constant.");
        Console.WriteLine("Nullable types allow values/references to be null.");
        Console.WriteLine("TryParse is useful for safe input conversion.");
    }
}