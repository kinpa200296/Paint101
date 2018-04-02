using Paint101.Api;
using System;

namespace Paint101.Core.StandardFigures
{
    public class FrameTriangle : Figure
    {
        private Point _p1;
        private Point _p2;
        private Point _p3;
        private Color _color;


        public FrameTriangle(Point p1, Point p2, Point p3, Color color)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _color = color;
        }


        public override void Draw(ICanvas canvas)
        {
            DrawLine(canvas, _p1, _p2);
            DrawLine(canvas, _p1, _p3);
            DrawLine(canvas, _p2, _p3);
        }


        private void DrawLine(ICanvas canvas, Point p1, Point p2)
        {
            if (p1.Y == p2.Y)
            {
                for (var i = Math.Min(p1.X, p2.X); i <= Math.Max(p1.X, p2.X); i++)
                {
                    canvas[i, p1.Y] = _color;
                }
                return;
            }

            if (p1.X == p2.X)
            {
                for (var j = Math.Min(p1.Y, p2.Y); j <= Math.Max(p1.Y, p2.Y); j++)
                {
                    canvas[p1.X, j] = _color;
                }
                return;
            }

            var k = (1.0 * p2.Y - p1.Y) / (p2.X - p1.X);
            var b = p1.Y - k * p1.X;

            for (var i = Math.Min(p1.X, p2.X); i <= Math.Max(p1.X, p2.X); i++)
            {
                var j = (int)(k * i + b);
                canvas[i, j] = _color;
            }
        }
    }
}
