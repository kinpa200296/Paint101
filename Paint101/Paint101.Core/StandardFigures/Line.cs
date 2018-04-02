﻿using Paint101.Api;

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
            canvas.DrawLine(_p1, _p2, _color);
        }
    }
}
