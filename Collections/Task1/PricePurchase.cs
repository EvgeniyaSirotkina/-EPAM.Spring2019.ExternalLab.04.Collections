using System;

namespace Task1
{
    public class PricePurchase : Purchase
    {
        public PricePurchase()
        {
            Discount = default;
        }

        public PricePurchase(string name, int price, int quantity, int discount)
            : base(name, price, quantity)
        {
            Discount = discount;
        }

        public int Discount { get; set; }

        public override decimal GetCost()
        {
            if (Discount < 0)
            {
                throw new ArgumentOutOfRangeException("Discount can't be negative.");
            }

            if (Discount > Price)
            {
                throw new ArgumentException("Discount cannot be greater than price.");
            }

            if (Discount == 0)
            {
                return base.GetCost();
            }

            return (Price - Discount) * Quantity;
        }

        public override string ToRowString() => base.ToRowString() + string.Format("{0,10:N0}", Discount);

        public override string ToString() => $"{base.ToString()};{Quantity}";
    }
}
