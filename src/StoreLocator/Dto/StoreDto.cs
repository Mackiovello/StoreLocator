using System;

namespace StoreLocator.Dto
{
    public class StoreDto
    {
        public StoreDto(
            int id,
            string name, 
            string latitude, 
            string longitude)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Latitude = latitude ?? throw new ArgumentNullException(nameof(latitude));
            Longitude = longitude ?? throw new ArgumentNullException(nameof(longitude));
        }

        public int Id { get; }
        public string Name { get; }
        public string Latitude { get; }
        public string Longitude { get; }
    }
}
