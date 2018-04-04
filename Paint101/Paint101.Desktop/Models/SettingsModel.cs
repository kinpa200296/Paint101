using NLog;
using Paint101.Core;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Paint101.Desktop
{
    public class SettingsModel
    {
        public const string ConfigDir = "Config";
        public const string SettingsFile = "settings.bin";

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();


        public PluginKey SelectedExtension { get; private set; }


        public event EventHandler Updated;


        public SettingsModel()
        {
            SelectedExtension = new PluginKey("", "");
        }


        public void SetExtension(PluginKey key)
        {
            SelectedExtension = key;
            Updated?.Invoke(this, EventArgs.Empty);
        }

        public void SaveSettings()
        {
            var configDir = Path.Combine(Directory.GetCurrentDirectory(), ConfigDir);
            EnsureDirectory(configDir);
            var settingsPath = Path.Combine(configDir, SettingsFile);

            try
            {
                using (var file = File.OpenWrite(settingsPath))
                {
                    var serializer = new BinaryFormatter();
                    serializer.Serialize(file, SelectedExtension);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to save settings: {ex.ToString()}");
            }
        }

        public void LoadSettings()
        {
            var configDir = Path.Combine(Directory.GetCurrentDirectory(), ConfigDir);
            EnsureDirectory(configDir);
            var settingsPath = Path.Combine(configDir, SettingsFile);

            var res = new PluginKey("", "");

            if (File.Exists(settingsPath))
            {
                try
                {
                    using (var file = File.OpenRead(settingsPath))
                    {
                        var serializer = new BinaryFormatter();
                        res = serializer.Deserialize(file) as PluginKey;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to load settings: {ex.ToString()}");
                }
            }

            SetExtension(res);
        }


        private void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
