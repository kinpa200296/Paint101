using Shape.Api;

namespace Shape.ThickRectangleFrame
{
    [Shape("Thick Rectangle Frame")]
    public class ThickRectangleFrame : ShapedFigure
    {
        public override void AddParameters(IParameters parameters)
        {
            parameters.AddParameter("X1", ParamaterTypes.Int32, 50, "X1");
            parameters.AddParameter("Y1", ParamaterTypes.Int32, 50, "Y1");
            parameters.AddParameter("X2", ParamaterTypes.Int32, 100, "X2");
            parameters.AddParameter("Y2", ParamaterTypes.Int32, 100, "Y2");
            parameters.AddParameter("FrameThickness", ParamaterTypes.Int32, 1, "Frame Thickness");
        }

        public override void DrawFigure(ICanvas canvas, IParameters parameters)
        {
            var x1 = (int)parameters.GetParameter("X1");
            var y1 = (int)parameters.GetParameter("Y1");
            var x2 = (int)parameters.GetParameter("X2");
            var y2 = (int)parameters.GetParameter("Y2");
            var frameThickness = (int)parameters.GetParameter("FrameThickness");

            for (var i = 0; i < frameThickness; i++)
            {
                canvas.DrawFrame(x1 + i, y1 + i, x2 + i, y2 + i);
            }
        }

    }
}
