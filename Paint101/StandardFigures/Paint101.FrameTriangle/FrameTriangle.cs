﻿using Paint101.Api;

namespace Paint101.FrameTriangle
{
    [Figure("Frame Triangle")]
    public class FrameTriangle : Figure
    {
        public override void RegisterParameters(IParameterCollection parameters)
        {
            parameters.RegisterParameter(ParameterTypes.Point, "P1", new Point(50, 50), "Point 1");
            parameters.RegisterParameter(ParameterTypes.Point, "P2", new Point(100, 50), "Point 2");
            parameters.RegisterParameter(ParameterTypes.Point, "P3", new Point(100, 100), "Point 3");
            parameters.RegisterParameter(ParameterTypes.Color, "Color", PredefinedColors.Black);
        }


        public override void Draw(ICanvas canvas, IParameterCollection parameters)
        {
            var p1 = parameters.GetParameter<Point>("P1");
            var p2 = parameters.GetParameter<Point>("P2");
            var p3 = parameters.GetParameter<Point>("P3");
            var color = parameters.GetParameter<Color>("Color");

            canvas.DrawLine(p1, p2, color);
            canvas.DrawLine(p1, p3, color);
            canvas.DrawLine(p2, p3, color);
        }
    }
}
