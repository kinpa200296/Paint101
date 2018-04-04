using Caliburn.Micro;
using Paint101.Api;

namespace Paint101.Desktop.ViewModels
{
    /// <summary>
    /// Aka MainWindowViewModel in Caliburn world
    /// </summary>
    public class ShellViewModel : Screen
    {
        public AppService AppService { get; }

        public CanvasViewModel CanvasModel { get; }

        public FigureLibraryViewModel FigureLibrary { get; }

        public FigureCollectionViewModel FigureCollection { get; }

        public SettingsViewModel Settings { get; }


        public ShellViewModel()
        {
            DisplayName = "Paint101";

            AppService = new AppService();
            AppService.LoadPlugins();

            CanvasModel = new CanvasViewModel(PredefinedColors.White, 500, 500);
            AppService.SetCanvasRenderer(CanvasModel);

            Settings = new SettingsViewModel(AppService);
            FigureLibrary = new FigureLibraryViewModel(AppService);
            FigureCollection = new FigureCollectionViewModel(AppService);
        }


        protected override void OnViewLoaded(object view)
        {
            AppService.CanvasRenderer.Render(AppService.FigureCollection);
        }
    }
}
