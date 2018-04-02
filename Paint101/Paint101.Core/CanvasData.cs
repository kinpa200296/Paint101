using Paint101.Api;
using System;

namespace Paint101.Core
{
    public class CanvasData : ICanvas, ICanvasData
    {
        private Color[,] _canvas;


        public int Width => _canvas.GetLength(1);

        public int Height => _canvas.GetLength(0);

        public Color this[Point p]
        {
            get { return GetPixel(p.X, p.Y); }
            set { SetPixel(p.X, p.Y, value); }
        }

        public Color this[int x, int y]
        {
            get { return GetPixel(x, y); }
            set { SetPixel(x, y, value); }
        }

        public Color[,] Pixels => _canvas;


        public event EventHandler RenderEvent;


        public CanvasData(int width, int height)
        {
            _canvas = new Color[width, height];
        }


        public void FireRenderEvent()
        {
            RenderEvent?.Invoke(this, EventArgs.Empty);
        }

        public void ResetCanvas(Color color)
        {
            for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                {
                    _canvas[i, j] = color;
                }
        }


        private Color GetPixel(int x, int y)
        {
            if (IsInCanvas(x, y))
            {
                return _canvas[y, x];
            }
            return null;
        }

        private void SetPixel(int x, int y, Color color)
        {
            if (IsInCanvas(x, y))
            {
                _canvas[y, x] = color;
            }
        }

        private bool IsInCanvas(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
