using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yungching_Demo.Areas.Hotel.ViewModels
{
    public class HotelListPrice
    {
        public Entity.Hotel Hotel { get; set; }
        public Price Price { get; set; }
    }

    public class HotelPrice
    {
        public Entity.Hotel Hotel { get; set; }
        public List<Product> Products { get; set; }
    }
}