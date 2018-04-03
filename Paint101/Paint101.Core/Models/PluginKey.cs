namespace Paint101.Core
{
    public class PluginKey
    {
        public string AssemblyPath { get; }

        public string DescriptorId { get; }


        public PluginKey(string assemblyPath, string descriptorId)
        {
            AssemblyPath = assemblyPath;
            DescriptorId = descriptorId;
        }


        public override string ToString()
        {
            return $"{DescriptorId};{AssemblyPath}";
        }

        public override bool Equals(object obj)
        {
            var key = obj as PluginKey;
            return key == null ? false : AssemblyPath == key.AssemblyPath && DescriptorId == key.DescriptorId;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
