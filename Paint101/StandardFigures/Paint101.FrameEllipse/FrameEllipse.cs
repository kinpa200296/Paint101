using Paint101.Api;

namespace Paint101.FrameEllipse
{
    [Figure("Frame Ellipse")]
    public class FrameEllipse : Figure
    {
        public override void RegisterParameters(IParameterCollection parameters)
        {
            parameters.RegisterParameter(ParameterTypes.Point, "Center", new Point(50, 50));
            parameters.RegisterParameter(ParameterTypes.Int32, "Width", 50);
            parameters.RegisterParameter(ParameterTypes.Int32, "Height", 50);
            parameters.RegisterParameter(ParameterTypes.Color, "Color", PredefinedColors.Black);
        }


        public override void Draw(ICanvas canvas, IParameterCollection parameters)
        {
            var center = parameters.GetParameter<Point>("Center");
            var width = parameters.GetParameter<int>("Width");
            var height = parameters.GetParameter<int>("Height");
            var color = parameters.GetParameter<Color>("Color");

            canvas.DrawFrameEllipse(center, width, height, color);
        }
    }
}
