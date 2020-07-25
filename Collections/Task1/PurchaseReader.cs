using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    public class PurchaseReader : IEnumerable, IEnumerator
    {
        public readonly List<Purchase> Purchases = new List<Purchase>();

        public PurchaseReader()
        {
            Purchases = default;
        }

        public PurchaseReader(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath + ".csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        Purchases.Add(CreatePurchase(line));
                    }
                    catch (CsvException ex)
                    {
                        Console.Write(ex.CsvString + " - ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                }
            }
        }

        public object Current => Purchases[Position];

        public int Position { get; set; } = -1;

        public Purchase GetElement(int index)
        {
            return Purchases[index];
        }

        public static string FindItemInCollection(Purchase item, List<Purchase> collection)
        {
            int index = collection.BinarySearch(item, new PurchaseComparator());

            if (index >= 0)
            {
                return ($"Purchase {item} find on position {index + 1}.");
            }
            else
            {
                return ($"Purchase {item} not found.");
            }
        }

        public void Insert(int index, Purchase purchase)
        {
            if (index < 0 || index >= Purchases.Count)
            {
                Purchases.Add(purchase);
            }
            else
            {
                Purchases.Insert(index, purchase);
            }
        }

        public int Delete(int index)
        {
            if (index < 0 || index >= Purchases.Count)
            {
                return -1;
            }
            else
            {
                Purchases.RemoveAt(index);
                return index;
            }
        }

        public decimal TotalCost() => Purchases.Sum(purchase => purchase.GetCost());

        public void Sort(IComparer<Purchase> comparer)
        {
            Purchases.Sort(comparer);
        }

        public void Print()
        {
            Table.Header();
            Purchases.ForEach(purchase => Table.Body(purchase));
            Console.WriteLine(string.Format("{0,-10}{1,30:N0}", "Total cost", TotalCost()));
        }

        public IEnumerator GetEnumerator() => this;

        public bool MoveNext()
        {
            if (Position < Purchases.Count - 1)
            {
                Position ++;
                return true;
            }

            Reset();

            return false;
        }

        public void Reset()
        {
            Position = -1;
        }

        private Purchase CreatePurchase(string csvString)
        {
            var data = csvString.Split(';');

            if (string.IsNullOrEmpty(data[0]))
            {
                throw new CsvException(csvString, "The name of purchase can't be empty.");
            }

            try
            {
                switch (data.Length)
                {
                    case (int)NumberOfFields.Purchase:
                        return new Purchase(data[0], int.Parse(data[1]), int.Parse(data[2]));

                    case (int)NumberOfFields.PricePurchase:
                        {
                            int price = int.Parse(data[1]);
                            int discount = int.Parse(data[3]);
                            if (price <= discount)
                            {
                                throw new CsvException(csvString, "Wrong discount.");
                            }

                            return new PricePurchase(data[0], price, int.Parse(data[2]), discount);
                        }

                    default:
                        throw new CsvException(csvString, "The number of parameters is incorrect (must be only 3 or 4 parameters).");
                }
            }
            catch (FormatException)
            {
                throw new CsvException(csvString, "Incorrect string format.");
            }
        }
    }
}
