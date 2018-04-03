using Paint101.Api;

namespace Paint101.FrameRectangle
{
    [Figure("Frame Rectangle")]
    public class FrameRectangle : Figure
    {
        public override void RegisterParameters(IParameterCollection parameters)
        {
            parameters.RegisterParameter(ParameterTypes.Rect, "Rect", new Rect(50, 50, 100, 100));
            parameters.RegisterParameter(ParameterTypes.Color, "Color", PredefinedColors.Black);
        }

        public override void Draw(ICanvas canvas, IParameterCollection parameters)
        {
            var rect = parameters.GetParameter<Rect>("Rect");
            var color = parameters.GetParameter<Color>("Color");

            canvas.DrawFrameRectangle(rect, color);
        }
    }
}
