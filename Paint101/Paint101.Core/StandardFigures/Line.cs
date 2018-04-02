using Paint101.Api;
using System;

namespace Paint101.Core.StandardFigures
{
    public class Line : Figure
    {
        private Point _p1;
        private Point _p2;
        private Color _color;


        public Line(Point p1, Point p2, Color color)
        {
            _p1 = p1;
            _p2 = p2;
            _color = color;
        }


        public override void Draw(ICanvas canvas)
        {
            if (_p1.Y == _p2.Y)
            {
                for (var i = Math.Min(_p1.X, _p2.X); i <= Math.Max(_p1.X, _p2.X); i++)
                {
                    canvas[i, _p1.Y] = _color;
                }
                return;
            }

            if (_p1.X == _p2.X)
            {
                for (var j = Math.Min(_p1.Y, _p2.Y); j <= Math.Max(_p1.Y, _p2.Y); j++)
                {
                    canvas[_p1.X, j] = _color;
                }
                return;
            }

            var k = (1.0 * _p2.Y - _p1.Y) / (_p2.X - _p1.X);
            var b = _p1.Y - k * _p1.X;

            for (var i = Math.Min(_p1.X, _p2.X); i <= Math.Max(_p1.X, _p2.X); i++)
            {
                var j = (int)(k * i + b);
                canvas[i, j] = _color;
            }
        }
    }
}
