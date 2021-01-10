namespace yungching_Demo.Entity
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(HotelMetadata))]

    public partial class Hotel
    {
        private class HotelMetadata
        {
            public string HotelId { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            [JsonIgnore]
            public virtual City City1 { get; set; }
        }

    }
}
