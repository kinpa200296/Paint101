using Paint101.Api;
using System.Collections.Generic;

namespace Paint101.Core
{
    public class FigureCollection
    {
        private List<Figure> _figures;


        public IReadOnlyList<Figure> Figures => _figures;


        public FigureCollection()
        {
            _figures = new List<Figure>();
        }


        public void AddFigure(Figure figure)
        {
            _figures.Add(figure);
        }

        public void RemoveFigure(Figure figure)
        {
            _figures.Remove(figure);
        }

        public void DrawFigures(ICanvas canvas)
        {
            foreach (var figure in _figures)
            {
                figure.Draw(canvas);
            }
        }
    }
}
