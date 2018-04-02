using Paint101.Api;

namespace Paint101.Core
{
    public class FigureDescriptor : IFigureDescriptor
    {
        public string AssemblyPath { get; }

        public string Id { get; }

        public FigureKey Key { get; }

        public string DisplayName { get; set; }

        public string Description { get; set; }


        public FigureDescriptor(string assemblyPath, string id)
        {
            AssemblyPath = assemblyPath;
            Id = id;
            Key = new FigureKey(assemblyPath, id);
        }


        public Figure CreateInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}
