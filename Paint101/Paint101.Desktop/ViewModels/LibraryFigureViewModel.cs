using Caliburn.Micro;
using Paint101.Core;

namespace Paint101.Desktop.ViewModels
{
    public class LibraryFigureViewModel : PropertyChangedBase
    {
        public IFigureDescriptor Descriptor { get; }

        public string DisplayName => Descriptor.Metadata.DisplayName;

        public string Desctiption => Descriptor.Metadata.Description;


        public LibraryFigureViewModel(IFigureDescriptor figureDescriptor)
        {
            Descriptor = figureDescriptor;
        }
    }
}
