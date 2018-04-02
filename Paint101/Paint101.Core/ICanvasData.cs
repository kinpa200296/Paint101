using Paint101.Api;
using System;

namespace Paint101.Core
{
    public interface ICanvasData
    {
        int Width { get; }

        int Height { get; }

        Color[,] Pixels { get; }


        event EventHandler RenderEvent;
    }
}
