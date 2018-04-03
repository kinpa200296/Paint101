using Caliburn.Micro;
using Paint101.Core;
using System.Collections.ObjectModel;

namespace Paint101.Desktop.ViewModels
{
    public class FigureLibraryViewModel : PropertyChangedBase
    {
        private IPluginLibrary _pluginLibrary;


        public ObservableCollection<LibraryFigureViewModel> Figures { get; }


        public FigureLibraryViewModel(IPluginLibrary pluginLibrary)
        {
            _pluginLibrary = pluginLibrary;

            Figures = new ObservableCollection<LibraryFigureViewModel>();
            foreach (IFigureDescriptor descriptor in _pluginLibrary.GetByType(PluginTypes.Figure))
            {
                Figures.Add(new LibraryFigureViewModel(descriptor));
            }
        }


        public void Add(object o)
        {
            var a = 5;
        }
    }
}
