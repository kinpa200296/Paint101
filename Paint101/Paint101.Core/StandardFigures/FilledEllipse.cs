using Paint101.Api;
using System;

namespace Paint101.Core.StandardFigures
{
    public class FilledEllipse : Figure
    {
        private Point _center;
        private int _width;
        private int _height;
        private Color _color;


        public FilledEllipse(Point center, int width, int height, Color color)
        {
            _center = center;
            _width = width;
            _height = height;
            _color = color;
        }

        public FilledEllipse(Rect rect, Color color)
        {
            _center = new Point((rect.X1 + rect.X2) / 2, (rect.Y1 + rect.Y2) / 2);
            _width = rect.X2 - rect.X1;
            _height = rect.Y2 - rect.Y1;
            _color = color;
        }


        public override void Draw(ICanvas canvas)
        {
            var a = _width / 2.0;
            var b = _height / 2.0;
            var h = _center.X;
            var k = _center.Y;

            for (var i = _center.X - _width / 2; i <= _center.X + _width / 2; i++)
            {
                var j1 = (int)(k - Math.Sqrt(b * b - b * b / a / a * (i - h) * (i - h)));
                var j2 = (int)(k + Math.Sqrt(b * b - b * b / a / a * (i - h) * (i - h)));
                for (var j = Math.Min(j1, j2); j <= Math.Max(j1, j2); j++)
                {
                    canvas[i, j] = _color;
                }
            }

            // frame gets fragmented on both sides near end, so lets run code along other axis
            for (var j = _center.Y - _height / 2; j <= _center.Y + _height / 2; j++)
            {
                var i1 = (int)(h - Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                var i2 = (int)(h + Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                for (var i = Math.Min(i1, i2); i <= Math.Max(i1, i2); i++)
                {
                    canvas[i, j] = _color;
                }
            }
        }
    }
}
