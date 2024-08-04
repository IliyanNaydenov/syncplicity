using System;
using System.Collections.Generic;
using System.IO;

namespace Syncplicity.Utils
{
    public static class PropertiesReader
    {
        private static readonly Dictionary<string, string> properties = new Dictionary<string, string>();
        private static readonly string userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static readonly string propertiesFilePath = "C:\\Users\\inaid\\source\\repos\\Syncplicity\\Config\\app.properties";

        private static string Path(string v)
        {
            throw new NotImplementedException();
        }

        static PropertiesReader()
        {
            if (!File.Exists(propertiesFilePath))
            {
                throw new FileNotFoundException($"The properties file was not found: {propertiesFilePath}");
            }

            foreach (var line in File.ReadAllLines(propertiesFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    var keyValue = line.Split(new[] { '=' }, 2);
                    if (keyValue.Length == 2)
                    {
                        properties[keyValue[0].Trim()] = keyValue[1].Trim();
                    }
                }
            }
        }

        public static string Get(string key)
        {
            return properties.ContainsKey(key) ? properties[key] : null;
        }
    }
}
