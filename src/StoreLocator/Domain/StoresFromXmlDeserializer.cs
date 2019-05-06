using System;
using System.IO;
using System.Xml.Serialization;
using StoreLocator.Models;

namespace StoreLocator.Domain
{
    public class StoresFromXmlDeserializer : IStoresDeserializer
    {
        private readonly string _path;

        public StoresFromXmlDeserializer(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                throw new ArgumentException("The path has to point to a valid file", nameof(pathToFile));
            }

            _path = pathToFile;
        }

        public Stores Deserialize()
        {
            var serializer = new XmlSerializer(typeof(Stores));

            using var streamReader = new StreamReader(_path);
            return (Stores)serializer.Deserialize(streamReader);
        }
    }
}
