namespace Advanced_C_Sharp;

public class Program
{
    public static void Main(string[] args)
    {
        // Convert string to int using Parse()
        var @bool = sizeof(bool); // return 1
        var @char = sizeof(char); // return 2
        var @int = sizeof(int); // return 4
        var @float = sizeof(float); // return 4
        var @long = sizeof(long); // return 8
        var @double = sizeof(double); // return 8
        var @decimal = sizeof(decimal); // return 
    }

    // size of with Enum
    public struct Point
    {
        public Point(byte tag, double x, double y) => (Tag, X, Y) = (tag, x, y);

        public byte Tag { get; }
        public double X { get; }
        public double Y { get; }
    }

    // int point = sizeof(Point);
}