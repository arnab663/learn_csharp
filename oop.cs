class Order
{
    public long Id;
    public decimal Total;
    public string Status;

    public Order(long id, decimal total)
    {
        Id = id;
        Total = total;
        Status = "Pending";
    }

    public void MarkAsPaid()
    {
        Status = "Paid";
    }

    public void MarkAsShipped()
    {
        Status = "Shipped";
    }
}




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