using Paint101.Api;

namespace Paint101.FrameTriangle
{
    [Figure("Frame Triangle")]
    public class FrameTriangle : Figure
    {
        private Point _p1;
        private Point _p2;
        private Point _p3;
        private Color _color;


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawLine(_p1, _p2, _color);
            canvas.DrawLine(_p1, _p3, _color);
            canvas.DrawLine(_p2, _p3, _color);
        }
    }
}
