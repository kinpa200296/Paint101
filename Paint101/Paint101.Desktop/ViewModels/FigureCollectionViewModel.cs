using Caliburn.Micro;
using Paint101.Core;
using System.Collections.ObjectModel;
using System.Linq;

namespace Paint101.Desktop.ViewModels
{
    public class FigureCollectionViewModel : PropertyChangedBase
    {
        private AppService _appService;
        private FigureViewModel _selectedFigure;
        private int _selectedFigureIndex;


        public ObservableCollection<FigureViewModel> Figures { get; }

        public FigureViewModel SelectedFigure
        {
            get { return _selectedFigure; }
            set
            {
                if (_selectedFigure == value)
                    return;

                _selectedFigure = value;
                _selectedFigureIndex = Figures.IndexOf(_selectedFigure);
                NotifyOfPropertyChange(nameof(SelectedFigure));
                NotifyOfPropertyChange(nameof(CanEdit));
                NotifyOfPropertyChange(nameof(CanRemove));
                NotifyOfPropertyChange(nameof(CanMoveUp));
                NotifyOfPropertyChange(nameof(CanMoveDown));
            }
        }

        public bool CanRender => Figures.Count > 0;

        public bool CanEdit => SelectedFigure != null;

        public bool CanRemove => SelectedFigure != null;

        public bool CanMoveUp => SelectedFigure != null && _selectedFigureIndex != 0;

        public bool CanMoveDown => SelectedFigure != null && _selectedFigureIndex != Figures.Count - 1;


        public FigureCollectionViewModel(AppService appService)
        {
            _appService = appService;

            _appService.FigureCollection.Added += FigureCollectionOnAdded;
            _appService.FigureCollection.Updated += FigureCollectionOnUpdated;
            _appService.FigureCollection.Removed += FigureCollectionOnRemoved;

            Figures = new ObservableCollection<FigureViewModel>();
            foreach (var figure in _appService.FigureCollection.Figures)
            {
                Figures.Add(new FigureViewModel(figure));
            }
        }


        public void Render()
        {
            _appService.CanvasRenderer.Render(_appService.FigureCollection);
        }

        public void Edit(object o)
        {
            if (o is FigureViewModel figure)
            {
                _appService.EditFigure(figure.Proxy);
            }
        }

        public void Remove(object o)
        {
            if (o is FigureViewModel figure)
            {
                _appService.RemoveFigure(figure.Proxy);
            }
        }

        public void MoveUp()
        {
            var figure = Figures[_selectedFigureIndex - 1];
            Figures.RemoveAt(_selectedFigureIndex - 1);
            Figures.Insert(_selectedFigureIndex, figure);
            _selectedFigureIndex--;
            NotifyOfPropertyChange(nameof(CanMoveUp));
            NotifyOfPropertyChange(nameof(CanMoveDown));
            Render();
        }

        public void MoveDown()
        {
            var figure = Figures[_selectedFigureIndex + 1];
            Figures.RemoveAt(_selectedFigureIndex + 1);
            Figures.Insert(_selectedFigureIndex, figure);
            _selectedFigureIndex++;
            NotifyOfPropertyChange(nameof(CanMoveUp));
            NotifyOfPropertyChange(nameof(CanMoveDown));
            Render();
        }


        private void FigureCollectionOnAdded(object sender, FigureProxy e)
        {
            Figures.Add(new FigureViewModel(e));
            Render();
            NotifyOfPropertyChange(nameof(CanRender));
        }

        private void FigureCollectionOnUpdated(object sender, FigureProxy e)
        {
            Render();
        }

        private void FigureCollectionOnRemoved(object sender, FigureProxy e)
        {
            var figureVM = Figures.FirstOrDefault(f => f.Proxy == e);
            if (figureVM != null)
            {
                Figures.Remove(figureVM);
            }
            Render();
            NotifyOfPropertyChange(nameof(CanRender));
        }
    }
}
