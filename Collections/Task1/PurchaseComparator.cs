using System.Collections.Generic;

namespace Task1
{
    public class PurchaseComparator : IComparer<Purchase>
    {
        public int Compare(Purchase x, Purchase y)
        {
            if (x.Name == y.Name)
            {
                if (x.GetType() == y.GetType())
                {
                    return x.GetCost().CompareTo(y.GetCost());
                }

                if (x.GetType() == typeof(PricePurchase))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return (x.Name.CompareTo(y.Name));
            }
        }
    }
}
