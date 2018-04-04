using Paint101.Api;
using Shape.Api;

namespace Paint101.Core
{
    public class ShapeAdapter : Figure
    {
        private ShapedFigure _shape;


        public ShapeAdapter(ShapedFigure shape)
        {
            _shape = shape;
        }


        public override void Draw(ICanvas canvas, IParameterCollection parameters)
        {
            _shape.DrawFigure(new ShapeCanvasAdapter(canvas), new ShapeParametersAdapter(parameters));
        }

        public override void RegisterParameters(IParameterCollection parameters)
        {
            _shape.AddParameters(new ShapeParametersAdapter(parameters));
        }
    }
}
