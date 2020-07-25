using System;
using System.IO;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                PurchaseReader collection = new PurchaseReader(args[0]);
                Console.WriteLine("\nin.csv:");
                collection.Print();

                PurchaseReader collection2 = new PurchaseReader(args[1]);
                Console.WriteLine("\naddon.csv:");
                collection2.Print();

                // insert the last item of the second collection at position 0 of the first collection
                collection.Insert(0, collection2.GetElement(collection2.Purchases.Count - 1));

                // insert the first item of the second collection at position 1000 of the first collection
                collection.Insert(1000, collection2.GetElement(0));

                // insert item with position 2 from the second collection to position 2 of the first collection
                collection.Insert(2, collection2.GetElement(2));

                // sequentially delete elements with indices 3, 10 and -5
                collection.Delete(3);
                collection.Delete(10);
                collection.Delete(-5);

                Console.WriteLine();
                collection.Sort(new PurchaseComparator());
                Console.WriteLine("After sort:");
                collection.Print();

                Console.WriteLine();
                Console.WriteLine("Result:");
                Console.WriteLine(PurchaseReader.FindItemInCollection(collection2.GetElement(1), collection.Purchases));
                Console.WriteLine(PurchaseReader.FindItemInCollection(collection2.GetElement(3), collection.Purchases));
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
