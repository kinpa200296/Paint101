using Paint101.Api;

namespace Paint101.Line
{
    [Figure("Line")]
    public class Line : Figure
    {
        private Point _p1;
        private Point _p2;
        private Color _color;


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawLine(_p1, _p2, _color);
        }
    }
}
