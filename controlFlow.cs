using System;

class Program
{
    static void Main()
    {
        // ============================================================
        // TOPIC 4 — OPERATORS & CONTROL FLOW
        // ============================================================


        // ============================================================
        // 1. ARITHMETIC OPERATORS
        // ============================================================

        int a = 10;
        int b = 3;

        Console.WriteLine(a + b); // 13
        Console.WriteLine(a - b); // 7
        Console.WriteLine(a * b); // 30
        Console.WriteLine(a / b); // 3  <-- integer division
        Console.WriteLine(a % b); // 1  <-- remainder

        /*
            IMPORTANT:

            int / int = int

            10 / 3 = 3

            If you want decimal division:

                double result = 10.0 / 3.0;
        */

        double decimalResult = 10.0 / 3.0;

        Console.WriteLine(decimalResult);


        // ============================================================
        // 2. ASSIGNMENT OPERATORS
        // ============================================================

        int number = 10;

        number = 20;

        number += 5;   // number = number + 5
        number -= 5;   // number = number - 5
        number *= 2;   // number = number * 2
        number /= 2;   // number = number / 2
        number %= 3;   // number = number % 3

        Console.WriteLine(number);


        // ============================================================
        // 3. INCREMENT / DECREMENT
        // ============================================================

        int x = 10;

        x++;

        Console.WriteLine(x); // 11

        x--;

        Console.WriteLine(x); // 10


        // ============================================================
        // 4. POST-INCREMENT vs PRE-INCREMENT
        // ============================================================

        int value = 10;

        int result1 = value++;

        /*
            POST-INCREMENT:

            First use the value,
            then increment it.

            result1 = 10
            value   = 11
        */

        Console.WriteLine(result1); // 10
        Console.WriteLine(value);   // 11


        value = 10;

        int result2 = ++value;

        /*
            PRE-INCREMENT:

            First increment the value,
            then use it.

            value   = 11
            result2 = 11
        */

        Console.WriteLine(result2); // 11


        // ============================================================
        // 5. COMPARISON OPERATORS
        // ============================================================

        int age = 25;

        Console.WriteLine(age == 25); // true
        Console.WriteLine(age != 25); // false
        Console.WriteLine(age > 18);  // true
        Console.WriteLine(age < 18);  // false
        Console.WriteLine(age >= 25); // true
        Console.WriteLine(age <= 25); // true


        // ============================================================
        // 6. LOGICAL OPERATORS
        // ============================================================

        bool isLoggedIn = true;
        bool isAdmin = false;

        // AND
        bool canManageUsers = isLoggedIn && isAdmin;

        // OR
        bool canAccess = isLoggedIn || isAdmin;

        // NOT
        bool isNotAdmin = !isAdmin;

        Console.WriteLine(canManageUsers); // false
        Console.WriteLine(canAccess);      // true
        Console.WriteLine(isNotAdmin);     // true


        // ============================================================
        // 7. SHORT-CIRCUIT EVALUATION
        // ============================================================

        bool loggedIn = false;

        /*
            Because the first condition is false,
            C# doesn't need to evaluate the second condition.

            This is short-circuit evaluation.
        */

        if (loggedIn && CheckPermission())
        {
            Console.WriteLine("Access granted");
        }

        /*
            With ||:

            If the first condition is true,
            C# doesn't evaluate the second condition.
        */

        bool isPublic = true;

        if (isPublic || CheckPermission())
        {
            Console.WriteLine("Accessible");
        }


        // ============================================================
        // 8. if / else
        // ============================================================

        int userAge = 20;

        if (userAge >= 18)
        {
            Console.WriteLine("Adult");
        }
        else
        {
            Console.WriteLine("Minor");
        }


        // ============================================================
        // 9. if / else if / else
        // ============================================================

        int score = 75;

        if (score >= 90)
        {
            Console.WriteLine("A");
        }
        else if (score >= 75)
        {
            Console.WriteLine("B");
        }
        else if (score >= 50)
        {
            Console.WriteLine("C");
        }
        else
        {
            Console.WriteLine("Fail");
        }


        // ============================================================
        // 10. GUARD CLAUSE
        // ============================================================

        int orderAmount = 0;

        if (orderAmount <= 0)
        {
            Console.WriteLine("Invalid order amount");

            // return;
        }

        /*
            Guard clauses are useful because they handle
            invalid cases early.

            Typical method:

                if (invalid)
                    return;

                // main logic
        */


        // ============================================================
        // 11. TERNARY OPERATOR
        // ============================================================

        int customerAge = 25;

        string category = customerAge >= 18
            ? "Adult"
            : "Minor";

        Console.WriteLine(category);

        /*
            Ternary:

                condition ? valueIfTrue : valueIfFalse
        */

        // Use ternary for simple decisions.
        // Avoid deeply nested ternary expressions.


        // ============================================================
        // 12. NULL-COALESCING OPERATOR ??
        // ============================================================

        string? username = null;

        string displayName = username ?? "Guest";

        Console.WriteLine(displayName); // Guest

        /*
            Meaning:

                If username is NOT null
                    use username

                Otherwise
                    use "Guest"
        */


        // ============================================================
        // 13. NULL-COALESCING ASSIGNMENT ??=
        // ============================================================

        string? name = null;

        name ??= "Default User";

        Console.WriteLine(name); // Default User

        /*
            ??=

            Assign only if the current value is null.
        */

        name ??= "Another User";

        Console.WriteLine(name); // Default User

        /*
            Since name is already non-null,
            the second assignment does nothing.
        */


        // ============================================================
        // 14. NULL-CONDITIONAL OPERATOR ?.
        // ============================================================

        User? user = null;

        string? userName = user?.Name;

        Console.WriteLine(userName); // null

        /*
            Without ?. :

                user.Name

            would cause NullReferenceException
            if user is null.

            With ?. :

                user?.Name

            means:

                "Access Name only if user isn't null."
        */


        // ============================================================
        // 15. COMBINING ?. AND ??
        // ============================================================

        User? currentUser = null;

        string currentUserName =
            currentUser?.Name ?? "Guest";

        Console.WriteLine(currentUserName); // Guest

        /*
            Read this as:

                Try to get currentUser.Name.

                If currentUser is null,
                the result is null.

                If the result is null,
                use "Guest".
        */


        // ============================================================
        // 16. switch STATEMENT
        // ============================================================

        int day = 2;

        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;

            case 2:
                Console.WriteLine("Tuesday");
                break;

            case 3:
                Console.WriteLine("Wednesday");
                break;

            default:
                Console.WriteLine("Unknown day");
                break;
        }


        // ============================================================
        // 17. switch EXPRESSION
        // ============================================================

        int dayNumber = 2;

        string dayName = dayNumber switch
        {
            1 => "Monday",
            2 => "Tuesday",
            3 => "Wednesday",
            4 => "Thursday",
            5 => "Friday",
            6 => "Saturday",
            7 => "Sunday",
            _ => "Invalid day"
        };

        Console.WriteLine(dayName);


        // ============================================================
        // 18. switch WITH PATTERN MATCHING
        // ============================================================

        object valueToCheck = 100;

        string description = valueToCheck switch
        {
            int number when number > 0 => "Positive integer",
            int number when number < 0 => "Negative integer",
            int => "Zero",
            string => "String",
            null => "Null",
            _ => "Something else"
        };

        Console.WriteLine(description);


        // ============================================================
        // 19. for LOOP
        // ============================================================

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i);
        }

        /*
            Execution:

                int i = 0
                    ↓
                i < 5 ?
                    ↓
                execute body
                    ↓
                i++
                    ↓
                i < 5 ?
                    ↓
                   ...
        */


        // ============================================================
        // 20. while LOOP
        // ============================================================

        int counter = 0;

        while (counter < 5)
        {
            Console.WriteLine(counter);

            counter++;
        }

        /*
            while checks the condition BEFORE
            every iteration.
        */


        // ============================================================
        // 21. do-while LOOP
        // ============================================================

        int attempts = 0;

        do
        {
            Console.WriteLine("Attempt");

            attempts++;
        }
        while (attempts < 3);

        /*
            do-while executes the body FIRST.

            Therefore it always runs at least once.
        */


        // ============================================================
        // 22. foreach LOOP
        // ============================================================

        int[] numbers =
        {
            10,
            20,
            30,
            40
        };

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        /*
            foreach is used to enumerate a collection.

            This connects directly to:

                IEnumerable<T>
                IEnumerator<T>
                LINQ

            which we'll study later.
        */


        // ============================================================
        // 23. break
        // ============================================================

        for (int i = 0; i < 10; i++)
        {
            if (i == 5)
            {
                break;
            }

            Console.WriteLine(i);
        }

        /*
            Output:

                0
                1
                2
                3
                4

            break completely exits the loop.
        */


        // ============================================================
        // 24. continue
        // ============================================================

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                continue;
            }

            Console.WriteLine(i);
        }

        /*
            Output:

                1
                3
                5
                7
                9

            continue skips the current iteration
            and moves to the next iteration.
        */


        // ============================================================
        // 25. return
        // ============================================================

        int numberToCheck = 10;

        if (numberToCheck < 0)
        {
            Console.WriteLine("Negative");

            // return;
        }

        Console.WriteLine("Continue with normal logic");


        // ============================================================
        // 26. OPERATOR PRECEDENCE
        // ============================================================

        int calculation = 10 + 5 * 2;

        Console.WriteLine(calculation); // 20

        /*
            Multiplication happens before addition:

                5 * 2 = 10

                10 + 10 = 20
        */

        // When in doubt, use parentheses.

        int clearerCalculation = (10 + 5) * 2;

        Console.WriteLine(clearerCalculation); // 30


        // ============================================================
        // 27. DIVISION BY ZERO
        // ============================================================

        int numerator = 10;
        int denominator = 0;

        // int result = numerator / denominator;
        //
        // This causes DivideByZeroException.

        /*
            Always consider whether the denominator
            can be zero before performing integer division.
        */


        // ============================================================
        // 28. FLOATING-POINT COMPARISON
        // ============================================================

        double first = 0.1 + 0.2;
        double second = 0.3;

        Console.WriteLine(first == second);

        /*
            Don't blindly rely on == for floating-point
            calculations because floating-point numbers
            can contain representation/precision differences.

            For financial/business calculations,
            decimal is often more appropriate.
        */


        // ============================================================
        // 29. decimal FOR MONEY
        // ============================================================

        decimal price = 1999.99m;
        decimal tax = 0.18m;

        decimal finalPrice = price + (price * tax);

        Console.WriteLine(finalPrice);


        // ============================================================
        // 30. COMBINING OPERATORS + CONTROL FLOW
        // ============================================================

        decimal orderTotal = 5000m;
        bool isLoggedIn = true;
        bool hasPaymentMethod = true;

        if (isLoggedIn &&
            hasPaymentMethod &&
            orderTotal > 0)
        {
            Console.WriteLine("Order can be placed");
        }
        else
        {
            Console.WriteLine("Order cannot be placed");
        }


        // ============================================================
        // 31. REAL-WORLD GUARD-CLAUSE STYLE
        // ============================================================

        ProcessOrder(5000m, true);
    }


    // ================================================================
    // HELPER METHODS
    // ================================================================

    static bool CheckPermission()
    {
        Console.WriteLine("Checking permission...");

        return true;
    }


    static void ProcessOrder(decimal amount, bool isLoggedIn)
    {
        // Guard clause #1
        if (!isLoggedIn)
        {
            Console.WriteLine("User must be logged in.");
            return;
        }

        // Guard clause #2
        if (amount <= 0)
        {
            Console.WriteLine("Order amount must be positive.");
            return;
        }

        // Main business logic
        Console.WriteLine("Processing order...");
    }
}


// ====================================================================
// SIMPLE CLASS USED FOR NULL-CONDITIONAL EXAMPLES
// ====================================================================

class User
{
    public string Name { get; set; } = "";
}