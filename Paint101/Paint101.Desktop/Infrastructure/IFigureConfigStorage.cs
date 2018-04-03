using Paint101.Core;
using System.Collections.Generic;

namespace Paint101.Desktop
{
    public interface IFigureConfigStorage
    {
        void SaveFigures(List<FigureConfig> figures);

        List<FigureConfig> LoadFigures();
    }
}
