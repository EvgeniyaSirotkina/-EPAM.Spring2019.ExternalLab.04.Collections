namespace Task2
{
    public class Point
    {
        public Point()
        {
            X = default;
            Y = default;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString() => $"({X};{Y})";
    }
}
