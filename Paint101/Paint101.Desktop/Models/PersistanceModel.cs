using NLog;
using Paint101.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Paint101.Desktop
{
    public class PersistanceModel : IFigureConfigStorage
    {
        public const string ConfigDir = "Config";
        public const string FiguresFile = "figures.bin";

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();


        private AppService _appService;


        public PersistanceModel(AppService appService)
        {
            _appService = appService;
        }


        public void SaveFigures(List<FigureConfig> figures)
        {
            var configDir = Path.Combine(Directory.GetCurrentDirectory(), ConfigDir);
            EnsureDirectory(configDir);
            var figuresPath = Path.Combine(configDir, FiguresFile);

            try
            {
                byte[] bytes;
                using (var stream = new MemoryStream())
                {
                    var serializer = new BinaryFormatter();
                    serializer.Serialize(stream, figures);
                    bytes = stream.ToArray();
                }

                if (!string.IsNullOrWhiteSpace(_appService.Settings.SelectedExtension.AssemblyPath))
                {
                    var descriptor = (IExtensionDescriptor)_appService.PluginLibrary.Get(_appService.Settings.SelectedExtension);
                    var extension = new ExtensionProxy(descriptor);
                    using (var input = new MemoryStream(bytes))
                    {
                        var output = extension.OnSerialized(input);
                        if (output != null)
                        {
                            using (output)
                            {
                                bytes = new byte[output.Length];
                                output.Seek(0, SeekOrigin.Begin);
                                output.Read(bytes, 0, (int)output.Length);
                            }
                        }
                    }
                }

                using (var file = File.Create(figuresPath))
                {
                    file.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to save persistance model: {ex.ToString()}");
            }
        }

        public List<FigureConfig> LoadFigures()
        {
            var configDir = Path.Combine(Directory.GetCurrentDirectory(), ConfigDir);
            EnsureDirectory(configDir);
            var figuresPath = Path.Combine(configDir, FiguresFile);

            var res = new List<FigureConfig>();

            if (File.Exists(figuresPath))
            {
                try
                {
                    var bytes = File.ReadAllBytes(figuresPath);

                    if (!string.IsNullOrWhiteSpace(_appService.Settings.SelectedExtension.AssemblyPath))
                    {
                        var descriptor = (IExtensionDescriptor)_appService.PluginLibrary.Get(_appService.Settings.SelectedExtension);
                        var extension = new ExtensionProxy(descriptor);
                        using (var input = new MemoryStream(bytes))
                        {
                            var output = extension.OnDeserializing(input);
                            if (output != null)
                            {
                                using (output)
                                {
                                    bytes = new byte[output.Length];
                                    output.Seek(0, SeekOrigin.Begin);
                                    output.Read(bytes, 0, (int)output.Length);
                                }
                            }
                        }
                    }

                    using (var stream = new MemoryStream(bytes))
                    {
                        var serializer = new BinaryFormatter();
                        res = serializer.Deserialize(stream) as List<FigureConfig>;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to load persistance model: {ex.ToString()}");
                }
            }

            return res;
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
