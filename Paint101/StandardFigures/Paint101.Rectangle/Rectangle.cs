using Paint101.Api;

namespace Paint101.Rectangle
{
    [Figure("Rectangle")]
    public class Rectangle : Figure
    {
        private Rect _rect;
        private Color _color;


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFilledRectangle(_rect, _color);
        }
    }
}
