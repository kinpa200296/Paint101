﻿using NLog;
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
                using (var file = File.OpenWrite(figuresPath))
                {
                    var serializer = new BinaryFormatter();
                    serializer.Serialize(file, figures);
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
                    using (var file = File.OpenRead(figuresPath))
                    {
                        var serializer = new BinaryFormatter();
                        res = serializer.Deserialize(file) as List<FigureConfig>;
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
