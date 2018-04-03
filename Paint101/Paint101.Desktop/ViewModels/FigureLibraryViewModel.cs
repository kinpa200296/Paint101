using Caliburn.Micro;
using Paint101.Core;
using System.Collections.ObjectModel;

namespace Paint101.Desktop.ViewModels
{
    public class FigureLibraryViewModel : PropertyChangedBase
    {
        private AppService _appService;


        public ObservableCollection<LibraryFigureViewModel> Figures { get; }


        public FigureLibraryViewModel(AppService appService)
        {
            _appService = appService;

            Figures = new ObservableCollection<LibraryFigureViewModel>();
            foreach (IFigureDescriptor descriptor in _appService.PluginLibrary.GetByType(PluginTypes.Figure))
            {
                Figures.Add(new LibraryFigureViewModel(descriptor));
            }
        }


        public void Add(object o)
        {
            if (o is LibraryFigureViewModel figure)
            {
                _appService.AddFigure(figure.Descriptor);
            }
        }
    }
}
