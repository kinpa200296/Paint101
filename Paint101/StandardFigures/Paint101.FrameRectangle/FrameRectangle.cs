using Paint101.Api;

namespace Paint101.FrameRectangle
{
    [Figure("Frame Rectangle")]
    public class FrameRectangle : Figure
    {
        private Rect _rect;
        private Color _color;


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFrameRectangle(_rect, _color);
        }
    }
}
