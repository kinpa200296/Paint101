using System;

namespace Paint101.Api
{
    /// <summary>
    /// Simple rectangle based on 2 points
    /// </summary>
    [Serializable]
    public class Rect
    {
        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }


        public Rect(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Rect(Point p1, Point p2)
        {
            X1 = p1.X;
            Y1 = p1.Y;
            X2 = p2.X;
            Y2 = p2.Y;
        }


        public override string ToString()
        {
            return $"Rect(({X1}, {Y1}); ({X2}, {Y2}))";
        }
    }
}
