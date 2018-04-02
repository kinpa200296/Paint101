using System.Collections.Generic;

namespace Paint101.Api
{
    public abstract class Figure
    {
        public abstract void Draw(ICanvas canvas);

        //public abstract Parameter[] GetParameters();

        //public abstract void SetParameters(Dictionary<string, object> parameters);
    }
}
