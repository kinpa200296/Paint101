namespace Paint101.Api
{
    /// <summary>
    /// In memory representation of pixels
    /// </summary>
    public interface ICanvas
    {
        /// <summary>
        /// Canvas width. Can change between draw calls
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Canvas height. Can change between draw calls
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Get/set color of pixel at specified point
        /// </summary>
        Color this[int x, int y] { get; set; }

        /// <summary>
        /// Get/set color of pixel at specified point
        /// </summary>
        Color this[Point p] { get; set; }

        /// <summary>
        /// Draw pixel wide line between 2 points
        /// </summary>
        void DrawLine(Point p1, Point p2, Color color);

        /// <summary>
        /// Draw pixel wide rectangle frame
        /// </summary>
        void DrawFrameRectangle(Rect rect, Color color);

        /// <summary>
        /// Draw filled rectangle
        /// </summary>
        /// <param name="rect"></param>
        void DrawFilledRectangle(Rect rect, Color color);

        /// <summary>
        /// Draw pixel wide ellipse frame
        /// </summary>
        /// <param name="center">Center of ellipse</param>
        /// <param name="width">Width of rectangle ellipse should fit in</param>
        /// <param name="height">Height of rectangle ellipse should fit in</param>
        void DrawFrameEllipse(Point center, int width, int height, Color color);

        /// <summary>
        /// Draw filled ellipse
        /// </summary>
        /// <param name="center">Center of ellipse</param>
        /// <param name="width">Width of rectangle ellipse should fit in</param>
        /// <param name="height">Height of rectangle ellipse should fit in</param>
        void DrawFilledEllipse(Point center, int width, int height, Color color);
    }
}
