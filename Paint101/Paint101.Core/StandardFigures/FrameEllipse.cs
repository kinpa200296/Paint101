using Paint101.Api;
using System;

namespace Paint101.Core.StandardFigures
{
    public class FrameEllipse : Figure
    {
        private Point _center;
        private int _width;
        private int _height;
        private Color _color;


        public FrameEllipse(Point center, int width, int height, Color color)
        {
            _center = center;
            _width = width;
            _height = height;
            _color = color;
        }

        public FrameEllipse(Rect rect, Color color)
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
                canvas[i, j1] = _color;
                canvas[i, j2] = _color;
            }

            // frame fragmented holes on both side near end, so lets run code along other axis
            for (var j = _center.Y - _height / 2; j <= _center.Y + _height / 2; j++)
            {
                var i1 = (int)(h - Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                var i2 = (int)(h + Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                canvas[i1, j] = _color;
                canvas[i2, j] = _color;
            }
        }
    }
}
