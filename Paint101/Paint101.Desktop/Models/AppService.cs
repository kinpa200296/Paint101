using Paint101.Api;
using Paint101.Core;
using Paint101.Core.StandardFigures;
using System.IO;

namespace Paint101.Desktop
{
    public class AppService
    {
        public IPluginLibrary PluginLibrary { get; private set; }

        public FigureCollection FigureCollection { get; private set; }


        public AppService()
        {
            CoreLoggerFactory.SetFactoryMethod(name => new NlogLoggerWrapper(name));
            PluginLibrary = new PluginLibrary();
            FigureCollection = new FigureCollection();
            SeedDummyFigures();
        }


        public void LoadPlugins()
        {
            AssemblyLoader.RegisterAssemblyInspector(new Paint101AssemblyInspector());
            AssemblyLoader.LoadPlugins(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"), PluginLibrary);
        }


        private void SeedDummyFigures()
        {
            FigureCollection.AddFigure(new Line(new Point(100, 100), new Point(200, 100), PredefinedColors.Red));
            FigureCollection.AddFigure(new Line(new Point(100, 100), new Point(200, 200), PredefinedColors.Green));
            FigureCollection.AddFigure(new Line(new Point(100, 100), new Point(100, 200), PredefinedColors.Blue));
            FigureCollection.AddFigure(new FrameRectangle(new Rect(100, 300, 200, 400), PredefinedColors.Black));
            FigureCollection.AddFigure(new FilledRectangle(new Rect(300, 300, 400, 400), PredefinedColors.Black));
            FigureCollection.AddFigure(new FrameEllipse(new Point(350, 150), 100, 100, PredefinedColors.Red));
            FigureCollection.AddFigure(new FilledEllipse(new Point(350, 150), 80, 60, PredefinedColors.Green));
            FigureCollection.AddFigure(new FrameTriangle(new Point(250, 250), new Point(300, 200), new Point(300, 300), PredefinedColors.Blue));
            FigureCollection.AddFigure(new FrameTriangle(new Point(250, 250), new Point(200, 200), new Point(200, 300), PredefinedColors.Blue));
        }
    }
}
