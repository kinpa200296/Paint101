namespace Shape.Api
{
    public abstract class ShapedFigure
    {
        public abstract void AddParameters(IParameters parameters);

        public abstract void DrawFigure(ICanvas canvas, IParameters parameters);
    }
}
