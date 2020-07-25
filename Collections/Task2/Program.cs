using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    string s;
                    Point point1, point2;
                    int len, index;
                    List<Segment> list = new List<Segment>();
                    Segment segment;
                    string[] numbers;

                    while ((s = sr.ReadLine()) != null)
                    {
                        numbers = Regex.Split(s, @"\s*\(\s*|\s*;\s*|\s*\)\s*");

                        point1 = new Point(double.Parse(numbers[1]), double.Parse(numbers[2]));
                        point2 = new Point(double.Parse(numbers[4]), double.Parse(numbers[5]));
                        len = (int)(Math.Round(Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2)), MidpointRounding.AwayFromZero));
                        
                        segment = new Segment(len);

                        index = list.BinarySearch(segment);
                        if (index < 0)
                        {
                            list.Insert(~index, segment);
                        }
                        else
                        {
                            list[index].Num++;
                        }
                    }

                    list.Sort(new Segment());

                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
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
