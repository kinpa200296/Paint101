using Caliburn.Micro;
using Paint101.Core;
using Paint101.Desktop.ViewModels;
using System.IO;

namespace Paint101.Desktop
{
    public class AppService
    {
        public IPluginLibrary PluginLibrary { get; }

        public IFigureCollection FigureCollection { get; }

        public ICanvasRenderer CanvasRenderer { get; private set; }

        public IWindowManager WindowManager { get; }

        public IFigureConfigStorage FigureStorage { get; }

        public SettingsModel Settings { get; }


        public AppService()
        {
            CoreLoggerFactory.SetFactoryMethod(name => new NlogLoggerWrapper(name));
            PluginLibrary = new PluginLibrary();
            FigureCollection = new FigureCollection();
            WindowManager = new WindowManager();
            FigureStorage = new PersistanceModel(this);
            Settings = new SettingsModel();
        }


        public void LoadPlugins()
        {
            AssemblyLoader.RegisterAssemblyInspector(new Paint101AssemblyInspector());
            AssemblyLoader.RegisterAssemblyInspector(new ShapeAssemblyInspector());
            AssemblyLoader.LoadPlugins(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"), PluginLibrary);
        }

        public void SetCanvasRenderer(ICanvasRenderer canvasRenderer)
        {
            CanvasRenderer = canvasRenderer;
        }

        public void AddFigure(IFigureDescriptor descriptor)
        {
            var figureProxy = new FigureProxy(descriptor);
            FigureCollection.AddFigure(figureProxy);
            var figureSetup = new FigureSetupViewModel(this, figureProxy);
            WindowManager.ShowDialog(figureSetup);
        }

        public void AddFigure(IFigureDescriptor descriptor, FigureConfig config)
        {
            var figureProxy = new FigureProxy(descriptor);
            figureProxy.LoadConfig(config);
            FigureCollection.AddFigure(figureProxy);
        }

        public void EditFigure(FigureProxy figureProxy)
        {
            var figureSetup = new FigureSetupViewModel(this, figureProxy);
            WindowManager.ShowDialog(figureSetup);
        }

        public void RemoveFigure(FigureProxy figureProxy)
        {
            FigureCollection.RemoveFigure(figureProxy);
        }
    }
}
