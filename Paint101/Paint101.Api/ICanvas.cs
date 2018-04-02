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
    }
}
