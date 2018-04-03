using Caliburn.Micro;
using Paint101.Core;

namespace Paint101.Desktop.ViewModels
{
    public class FigureViewModel : PropertyChangedBase
    {
        public FigureProxy Proxy { get; }

        public string DisplayName => Proxy.Metadata.DisplayName;


        public FigureViewModel(FigureProxy figure)
        {
            Proxy = figure;
        }
    }
}
