using Paint101.Api;

namespace Paint101.FrameEllipse
{
    [Figure("Frame Ellipse")]
    public class FrameEllipse : Figure
    {
        private Point _center;
        private int _width;
        private int _height;
        private Color _color;


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFrameEllipse(_center, _width, _height, _color);
        }
    }
}
