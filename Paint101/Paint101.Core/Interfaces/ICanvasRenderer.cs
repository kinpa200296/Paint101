using Paint101.Api;

namespace Paint101.Core
{
    public interface ICanvasRenderer
    {
        ICanvas Canvas { get; }

        ICanvasData CanvasData { get; }


        void Render(IFigureCollection figureCollection);
    }
}
