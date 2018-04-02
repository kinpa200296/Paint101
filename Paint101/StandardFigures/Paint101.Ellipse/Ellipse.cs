using Paint101.Api;

namespace Paint101.Ellipse
{
    [Figure("Ellipse")]
    public class Ellipse : Figure
    {
        private Point _center;
        private int _width;
        private int _height;
        private Color _color;


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFilledEllipse(_center, _width, _height, _color);
        }
    }
}
