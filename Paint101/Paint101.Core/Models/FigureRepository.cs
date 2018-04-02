using System;
using System.Collections.Generic;

namespace Paint101.Core
{
    public class FigureRepository
    {
        private Dictionary<FigureKey, IFigureDescriptor> _figureTypes;


        public event EventHandler Updated;


        public FigureRepository()
        {
            _figureTypes = new Dictionary<FigureKey, IFigureDescriptor>();
        }


        public void Add(IFigureDescriptor descriptor)
        {
            _figureTypes.Add(descriptor.Key, descriptor);
            Updated?.Invoke(this, EventArgs.Empty);
        }

        public void AddRange(IEnumerable<IFigureDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                _figureTypes.Add(descriptor.Key, descriptor);
            }
            Updated?.Invoke(this, EventArgs.Empty);
        }

        public IFigureDescriptor Get(FigureKey key)
        {
            return _figureTypes.ContainsKey(key) ? _figureTypes[key] : null;
        }
    }
}
