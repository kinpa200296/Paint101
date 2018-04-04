using Caliburn.Micro;
using Paint101.Core;

namespace Paint101.Desktop
{
    public class ExtensionViewModel : PropertyChangedBase
    {
        public string DisplayName { get; }

        public PluginKey Key { get; }


        public ExtensionViewModel(IExtensionDescriptor descriptor)
        {
            DisplayName = descriptor.Metadata.DisplayName;
            Key = descriptor.Key;
        }

        // dummy extension
        public ExtensionViewModel(string displayName)
        {
            DisplayName = displayName;
            Key = new PluginKey("", "");
        }
    }
}
