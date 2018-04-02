namespace Paint101.Api
{
    /// <summary>
    /// Represents ARGB color
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Alpha channel
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        /// Red channel
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Green channel
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Blue channel
        /// </summary>
        public byte B { get; set; }


        public Color(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }


        public override string ToString()
        {
            return $"Color(A = {A}, R = {R}, G = {G}, B = {B})";
        }
    }
}
