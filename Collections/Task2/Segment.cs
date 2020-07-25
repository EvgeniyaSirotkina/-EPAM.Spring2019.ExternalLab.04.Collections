using System;
using System.Collections.Generic;

namespace Task2
{
    public class Segment : IComparable<Segment>, IComparer<Segment>
    {
        public Segment() 
        {
            Len = default;
            Num = default;
        }

        public Segment(int len)
        {
            Len = len;
            Num = 1;
        }

        public Segment(int len, int num)
        {
            Len = len;
            Num = num;
        }

        public int Len { get; set; }

        public int Num { get; set; }

        public int CompareTo(Segment other)
        {
            if (Len == other.Len)
            {
                return 0;
            }
            else if (Len > other.Len)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int Compare(Segment x, Segment y)
        {
            return -(x.Num.CompareTo(y.Num));
        }

        public override string ToString() => $"{Len};{Num}";
    }
}
