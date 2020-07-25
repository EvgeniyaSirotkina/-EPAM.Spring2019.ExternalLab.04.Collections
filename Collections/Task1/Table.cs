using System;

namespace Task1
{
    public static class Table
    {
        public static void Header()
            => Console.WriteLine(string.Format("{0,10}{1,10}{2,10}{3,10}{4,10}", "Name", "Price", "Quantity", "Total", "Discount"));

        public static void Body(Purchase purchase)
            => Console.WriteLine(purchase.ToRowString());
    }
}
