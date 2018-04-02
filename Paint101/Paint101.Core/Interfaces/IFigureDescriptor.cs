using Paint101.Api;

namespace Paint101.Core
{
    public interface IFigureDescriptor
    {
        string AssemblyPath { get; }

        string Id { get; }

        FigureKey Key { get; }

        string DisplayName { get; }

        string Description { get; }


        Figure CreateInstance();
    }
}
