using Paint101.Core;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Paint101.Desktop
{
    public class PersistanceModel : IFigureConfigStorage
    {
        public const string ConfigDir = "Config";
        public const string FiguresFile = "figures.bin";


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

            using (var file = File.OpenWrite(figuresPath))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(file, figures);
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
                using (var file = File.OpenRead(figuresPath))
                {
                    var serializer = new BinaryFormatter();
                    res = serializer.Deserialize(file) as List<FigureConfig>;
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
