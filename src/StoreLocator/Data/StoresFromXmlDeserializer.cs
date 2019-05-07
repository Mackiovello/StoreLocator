using System;
using System.IO;
using System.Xml.Serialization;
using StoreLocator.Models.Xml;

namespace StoreLocator.Data
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

            // The code can explode here if the file at the
            // path doesn't follow the schema. I've decided
            // to ignore this since it's only deserialized
            // when we need to create a database, and thus,
            // it's easy to track down anyway.
            using var streamReader = new StreamReader(_path);
            return (Stores)serializer.Deserialize(streamReader);
        }
    }
}
