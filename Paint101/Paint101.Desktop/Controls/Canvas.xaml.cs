using Paint101.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Paint101.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for Canvas.xaml
    /// </summary>
    public partial class Canvas : UserControl
    {
        public static DependencyProperty CanvasDataProperty = DependencyProperty.Register(
            nameof(CanvasData), typeof(ICanvasData), typeof(Canvas), new PropertyMetadata(null, OnCanvasDataChanged));


        public ICanvasData CanvasData
        {
            get { return (ICanvasData)GetValue(CanvasDataProperty); }
            set { SetValue(CanvasDataProperty, value); }
        }


        public Canvas()
        {
            InitializeComponent();
        }


        private static void OnCanvasDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var canvas = d as Canvas;
            var oldValue = e.OldValue as ICanvasData;
            var newValue = e.NewValue as ICanvasData;

            if (canvas != null)
            {
                if (oldValue != null)
                {
                    oldValue.RenderEvent -= canvas.OnRenderEvent;
                }

                if (newValue != null)
                {
                    newValue.RenderEvent += canvas.OnRenderEvent;
                }
            }
        }


        private void OnRenderEvent(object sender, EventArgs e)
        {
            var wb = new WriteableBitmap(CanvasData.Width, CanvasData.Height, 96, 96, PixelFormats.Bgra32, null);

            var width = CanvasData.Width;
            var height = CanvasData.Height;
            var pixelSize = 4;
            var pixels = new byte[pixelSize * width * height];
            for(var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                {
                    pixels[pixelSize * (width * i + j) + 0] = CanvasData.Pixels[i, j].B;
                    pixels[pixelSize * (width * i + j) + 1] = CanvasData.Pixels[i, j].G;
                    pixels[pixelSize * (width * i + j) + 2] = CanvasData.Pixels[i, j].R;
                    pixels[pixelSize * (width * i + j) + 3] = CanvasData.Pixels[i, j].A;
                }

            wb.WritePixels(new Int32Rect(0, 0, width, height), pixels, pixelSize * width, 0);

            ImageCanvas.Source = wb;
        }
    }
}
