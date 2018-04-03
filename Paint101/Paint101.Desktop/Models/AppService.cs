using Paint101.Core;
using System.IO;

namespace Paint101.Desktop
{
    public class AppService
    {
        public IPluginLibrary PluginLibrary { get; }

        public IFigureCollection FigureCollection { get; }

        public ICanvasRenderer CanvasRenderer { get; private set; }


        public AppService()
        {
            CoreLoggerFactory.SetFactoryMethod(name => new NlogLoggerWrapper(name));
            PluginLibrary = new PluginLibrary();
            FigureCollection = new FigureCollection();
        }


        public void LoadPlugins()
        {
            AssemblyLoader.RegisterAssemblyInspector(new Paint101AssemblyInspector());
            AssemblyLoader.LoadPlugins(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"), PluginLibrary);
        }

        public void SetCanvasRenderer(ICanvasRenderer canvasRenderer)
        {
            CanvasRenderer = canvasRenderer;
        }

        public void AddFigure(IFigureDescriptor descriptor)
        {
            var figureProxy = new FigureProxy(descriptor);
            // configure
            FigureCollection.AddFigure(figureProxy);
        }

        public void EditFigure(FigureProxy figureProxy)
        {
            // configure
            FigureCollection.UpdateFigure(figureProxy);
        }

        public void RemoveFigure(FigureProxy figureProxy)
        {
            FigureCollection.RemoveFigure(figureProxy);
        }
    }
}
