namespace Paint101.Api
{
    public abstract class Figure
    {
        public abstract void RegisterParameters(IParameterCollection parameters);

        public abstract void Draw(ICanvas canvas, IParameterCollection parameters);
    }
}
