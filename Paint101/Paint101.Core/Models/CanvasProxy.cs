using Paint101.Api;
using System;

namespace Paint101.Core
{
    public class CanvasProxy : ICanvas, ICanvasData
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


        public CanvasProxy(int width, int height)
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


        #region ICanvas draw helpers

        void ICanvas.DrawLine(Point p1, Point p2, Color color)
        {
            var x1 = Math.Min(p1.X, p2.X);
            var x2 = Math.Max(p1.X, p2.X);
            var y1 = Math.Min(p1.Y, p2.Y);
            var y2 = Math.Max(p1.Y, p2.Y);

            if (y1 == y2)
            {
                for (var i = x1; i <= x2; i++)
                {
                    this[i, y1] = color;
                }
                return;
            }

            if (x1 == x2)
            {
                for (var j = y1; j <= y2; j++)
                {
                    this[x1, j] = color;
                }
                return;
            }

            var k = (1.0 * p2.Y - p1.Y) / (p2.X - p1.X);
            var b = p1.Y - k * p1.X;

            for (var i = x1; i <= x2; i++)
            {
                var j = (int)(k * i + b);
                this[i, j] = color;
            }

            // line gets fragmented with low number of values on one axis, so lets run code along other axis
            for (var j = y1; j <= y2; j++)
            {
                var i = (int)((j - b) / k);
                this[i, j] = color;
            }
        }

        void ICanvas.DrawFrameRectangle(Rect rect, Color color)
        {
            var x1 = Math.Min(rect.X1, rect.X2);
            var x2 = Math.Max(rect.X1, rect.X2);
            var y1 = Math.Min(rect.Y1, rect.Y2);
            var y2 = Math.Max(rect.Y1, rect.Y2);

            for (var i = x1; i <= x2; i++)
            {
                this[i, y1] = color;
                this[i, y2] = color;
            }

            for (var j = y1; j <= y2; j++)
            {
                this[x1, j] = color;
                this[x2, j] = color;
            }
        }

        void ICanvas.DrawFilledRectangle(Rect rect, Color color)
        {
            var x1 = Math.Min(rect.X1, rect.X2);
            var x2 = Math.Max(rect.X1, rect.X2);
            var y1 = Math.Min(rect.Y1, rect.Y2);
            var y2 = Math.Max(rect.Y1, rect.Y2);

            for (var i = x1; i <= x2; i++)
                for (var j = y1; j <= y2; j++)
                {
                    this[i, j] = color;
                }
        }

        void ICanvas.DrawFrameEllipse(Point center, int width, int height, Color color)
        {
            var a = width / 2.0;
            var b = height / 2.0;
            var h = center.X;
            var k = center.Y;

            for (var i = h - width / 2; i <= h + width / 2; i++)
            {
                var j1 = (int)(k - Math.Sqrt(b * b - b * b / a / a * (i - h) * (i - h)));
                var j2 = (int)(k + Math.Sqrt(b * b - b * b / a / a * (i - h) * (i - h)));
                this[i, j1] = color;
                this[i, j2] = color;
            }

            // frame fragmented holes on both side near end, so lets run code along other axis
            for (var j = k - height / 2; j <= k + height / 2; j++)
            {
                var i1 = (int)(h - Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                var i2 = (int)(h + Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                this[i1, j] = color;
                this[i2, j] = color;
            }
        }

        void ICanvas.DrawFilledEllipse(Point center, int width, int height, Color color)
        {
            var a = width / 2.0;
            var b = height / 2.0;
            var h = center.X;
            var k = center.Y;

            for (var i = h - width / 2; i <= h + width / 2; i++)
            {
                var j1 = (int)(k - Math.Sqrt(b * b - b * b / a / a * (i - h) * (i - h)));
                var j2 = (int)(k + Math.Sqrt(b * b - b * b / a / a * (i - h) * (i - h)));
                for (var j = Math.Min(j1, j2); j <= Math.Max(j1, j2); j++)
                {
                    this[i, j] = color;
                }
            }

            // frame gets fragmented on both sides near end, so lets run code along other axis
            for (var j = k - height / 2; j <= k + height / 2; j++)
            {
                var i1 = (int)(h - Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                var i2 = (int)(h + Math.Sqrt(a * a - a * a / b / b * (j - k) * (j - k)));
                for (var i = Math.Min(i1, i2); i <= Math.Max(i1, i2); i++)
                {
                    this[i, j] = color;
                }
            }
        }

        #endregion
    }
}
