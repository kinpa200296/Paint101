using Caliburn.Micro;
using Paint101.Core;
using System.Collections.ObjectModel;
using System.Linq;

namespace Paint101.Desktop.ViewModels
{
    public class SettingsViewModel : PropertyChangedBase
    {
        private AppService _appService;
        private ExtensionViewModel _selectedExtension;


        public ObservableCollection<ExtensionViewModel> Extensions { get; }

        public ExtensionViewModel SelectedExtension
        {
            get { return _selectedExtension; }
            set
            {
                if (_selectedExtension == value)
                    return;

                _selectedExtension = value;
                NotifyOfPropertyChange(nameof(SelectedExtension));
                _appService.Settings.SetExtension(_selectedExtension.Key);
                _appService.Settings.SaveSettings();
            }
        }

        public SettingsViewModel(AppService appService)
        {
            _appService = appService;

            Extensions = new ObservableCollection<ExtensionViewModel>();
            Extensions.Add(new ExtensionViewModel("None"));
            foreach (IExtensionDescriptor descriptor in _appService.PluginLibrary.GetByType(PluginTypes.Extension))
            {
                Extensions.Add(new ExtensionViewModel(descriptor));
            }

            _appService.Settings.LoadSettings();
            _selectedExtension = Extensions.FirstOrDefault(e => e.Key.Equals(_appService.Settings.SelectedExtension));

            appService.Settings.Updated += SettingsOnUpdated;
        }


        private void SettingsOnUpdated(object sender, System.EventArgs args)
        {
            _selectedExtension = Extensions.FirstOrDefault(e => e.Key == _appService.Settings.SelectedExtension);
            NotifyOfPropertyChange(nameof(SelectedExtension));
        }
    }
}
