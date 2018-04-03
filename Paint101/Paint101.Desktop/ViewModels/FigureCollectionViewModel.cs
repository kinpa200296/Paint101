using Caliburn.Micro;
using NLog;
using Paint101.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Paint101.Desktop.ViewModels
{
    public class FigureCollectionViewModel : PropertyChangedBase
    {
        private readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();

        private AppService _appService;
        private FigureViewModel _selectedFigure;
        private int _selectedFigureIndex;
        private bool _disabledSaving;


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

            LoadFigures();
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
            FiguresUpdated();
        }

        public void MoveDown()
        {
            var figure = Figures[_selectedFigureIndex + 1];
            Figures.RemoveAt(_selectedFigureIndex + 1);
            Figures.Insert(_selectedFigureIndex, figure);
            _selectedFigureIndex++;
            NotifyOfPropertyChange(nameof(CanMoveUp));
            NotifyOfPropertyChange(nameof(CanMoveDown));
            FiguresUpdated();
        }


        private void FigureCollectionOnAdded(object sender, FigureProxy e)
        {
            Figures.Add(new FigureViewModel(e));
            FiguresUpdated();
            NotifyOfPropertyChange(nameof(CanRender));
        }

        private void FigureCollectionOnUpdated(object sender, FigureProxy e)
        {
            FiguresUpdated();
        }

        private void FigureCollectionOnRemoved(object sender, FigureProxy e)
        {
            var figureVM = Figures.FirstOrDefault(f => f.Proxy == e);
            if (figureVM != null)
            {
                Figures.Remove(figureVM);
            }
            FiguresUpdated();
            NotifyOfPropertyChange(nameof(CanRender));
        }

        private void FiguresUpdated()
        {
            Render();
            SaveFigures();
        }

        private void LoadFigures()
        {
            _disabledSaving = true;

            try
            {
                var figures = _appService.FigureStorage.LoadFigures();
                foreach (var figure in figures)
                {
                    var descriptor = (IFigureDescriptor)_appService.PluginLibrary.Get(figure.Key);
                    if (descriptor == null)
                    {
                        _logger.Error($"Plugin '{figure.Key}' can't be found");
                        continue;
                    }
                    _appService.AddFigure(descriptor, figure);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to load figures: {ex.ToString()}");
            }


            _disabledSaving = false;
        }

        private void SaveFigures()
        {
            if (_disabledSaving)
                return;

            try
            {
                _appService.FigureStorage.SaveFigures(Figures.Select(f => f.Proxy.SaveConfig()).ToList());
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to save figures: {ex.ToString()}");
            }
        }
    }
}
