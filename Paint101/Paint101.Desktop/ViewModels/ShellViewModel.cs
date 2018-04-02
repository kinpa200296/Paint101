using Caliburn.Micro;

namespace Paint101.Desktop.ViewModels
{
    /// <summary>
    /// Aka MainWindowViewModel in Caliburn world
    /// </summary>
    public class ShellViewModel : Screen
    {
        public CanvasViewModel CanvasModel { get; }


        public ShellViewModel()
        {
            DisplayName = "Paint101";

            CanvasModel = new CanvasViewModel();
        }


        public void Draw()
        {
            CanvasModel.Render();
        }
    }
}
