// without LINQ
List<Product> products = new()
{
    new Product { Id = 1, Name = "Laptop", Price = 900m },
    new Product { Id = 2, Name = "Mouse", Price = 25m },
    new Product { Id = 3, Name = "Monitor", Price = 300m }
};

foreach (Product product in products)
{
    if (product.Price > 100m)
    {
        expensiveProducts.Add(product);
    }
}

// with LINQ
IEnumerable<Product> expensiveProducts = products.Where(product => product.Price > 100m);

/*
- Where is an extension method supplied by the System.Linq.Enumerable class for enumerable sequences.
a simplified version of its signature looks like:
public static IEnumerable<TSource> Where<TSource>(
    this IEnumerable<TSource> source,
    Func<TSource, bool> predicate);
so, this is conceptually calling a static method with the list as its source argument.

- Consider the lambda expression: product => product.Price > 100m
This is a predicate function that takes a Product and returns true if its Price is greater than 100m. 
The Where method uses this predicate to filter the products.
The corresponding delegate type is:
Func<Product, bool>
You can express the same idea using a named method:
static bool IsExpensive(Product product)
{
    return product.Price > 100m;
}
Then pass the method to LINQ:
IEnumerable<Product> expensiveProducts =
    products.Where(IsExpensive);

- LINQ works with the interface, not just a list
The important design is that Where accepts IEnumerable<TSource>, not specifically List<TSource>.

 */


// most important LINQ operations
// Where
var expensive = products.Where(p => p.Price > 100m);

// select
var names = products.Select(p => p.Name); // This projects each Product into a string. The result is conceptually an IEnumerable<string>, containing the product names.

// orderby
var ordered = products.OrderBy(p => p.Price); // This orders the products by their Price in ascending order. The result is an IEnumerable<Product>.


/* 
deferred execution:
var expensive = products.Where(p => p.Price > 100m);
Does this immediately loop over all products and store the matching items in a new list?
Usually, no.The LINQ Where operator for IEnumerable<T> uses deferred execution. It creates a query sequence that evaluates the predicate as the sequence is enumerated.
eg. 
var expensive = products.Where(p => p.Price > 100m);

Console.WriteLine("Query created");

foreach (Product product in expensive)
{
    Console.WriteLine(product.Name);
}

The query is created first. The filtering occurs when the foreach enumerates it.
*/

