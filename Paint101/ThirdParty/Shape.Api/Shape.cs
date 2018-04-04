namespace Shape.Api
{
    public abstract class ShapedFigure
    {
        public abstract void AddParameters(IParameters parameters);

        public abstract void DrawFigure(ISimpleCanvas canvas, IParameters parameters);
    }
}
