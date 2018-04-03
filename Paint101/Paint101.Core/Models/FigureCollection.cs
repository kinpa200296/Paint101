using Paint101.Api;
using System;
using System.Collections.Generic;

namespace Paint101.Core
{
    public class FigureCollection : IFigureCollection
    {
        private List<FigureProxy> _figureProxies;


        public IReadOnlyList<FigureProxy> Figures => _figureProxies;


        public event EventHandler<FigureProxy> Added;

        public event EventHandler<FigureProxy> Updated;

        public event EventHandler<FigureProxy> Removed;


        public FigureCollection()
        {
            _figureProxies = new List<FigureProxy>();
        }


        public void AddFigure(FigureProxy figureProxy)
        {
            _figureProxies.Add(figureProxy);
            Added?.Invoke(this, figureProxy);
        }

        public void UpdateFigure(FigureProxy figureProxy)
        {
            if (_figureProxies.IndexOf(figureProxy) != -1)
            {
                Updated?.Invoke(this, figureProxy);
            }

        }

        public void RemoveFigure(FigureProxy figureProxy)
        {
            _figureProxies.Remove(figureProxy);
            Removed?.Invoke(this, figureProxy);
        }

        public void DrawFigures(ICanvas canvas)
        {
            foreach (var figureProxy in _figureProxies)
            {
                figureProxy.Draw(canvas);
            }
        }
    }
}
