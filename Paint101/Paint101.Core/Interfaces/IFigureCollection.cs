using Paint101.Api;
using System;
using System.Collections.Generic;

namespace Paint101.Core
{
    public interface IFigureCollection
    {
        IReadOnlyList<FigureProxy> Figures { get; }


        event EventHandler<FigureProxy> Added;

        event EventHandler<FigureProxy> Updated;

        event EventHandler<FigureProxy> Removed;


        void AddFigure(FigureProxy figureProxy);

        void UpdateFigure(FigureProxy figureProxy);

        void RemoveFigure(FigureProxy figureProxy);

        void DrawFigures(ICanvas canvas);
    }
}
