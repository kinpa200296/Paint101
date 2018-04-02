﻿using Paint101.Api;

namespace Paint101.Core.StandardFigures
{
    public class FilledRectangle : Figure
    {
        private Rect _rect;
        private Color _color;


        public FilledRectangle(Rect rect, Color color)
        {
            _rect = rect;
            _color = color;
        }

        public FilledRectangle(Point p1, Point p2, Color color)
        {
            _rect = new Rect(p1, p2);
            _color = color;
        }


        public override void Draw(ICanvas canvas)
        {
            for (var i = _rect.X1; i <= _rect.X2; i++)
                for (var j = _rect.Y1; j <= _rect.Y2; j++)
                {
                    canvas[i, j] = _color;
                }
        }
    }
}