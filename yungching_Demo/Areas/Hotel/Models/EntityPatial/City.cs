namespace yungching_Demo.Entity
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CityMetadata))]
    public partial class City
    {

        private class CityMetadata
        {
            public string CityId { get; set; }
            public string CountryId { get; set; }
            public string CityName { get; set; }
            [JsonIgnore]
            public virtual Country Country { get; set; }
            [JsonIgnore]
            public virtual ICollection<Hotel> Hotel { get; set; }
        }

    }
}
