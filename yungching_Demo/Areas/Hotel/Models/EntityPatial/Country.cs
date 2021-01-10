namespace yungching_Demo.Entity
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CountryMetadata))]

    public partial class Country
    {
        private class CountryMetadata
        {
            public string CountryId { get; set; }
            public string CountryName { get; set; }
            [JsonIgnore]
            public virtual ICollection<City> City { get; set; }
        }
    }
}
