using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yungching_Demo.Areas.Hotel.ViewModels;

namespace yungching_Demo.Areas.Hotel.Service
{
    public interface IHotelService
    {
        Task<List<HotelListPrice>> GetHotelListPrice(string countryId, string cityId, string date, int days);

        Task<List<HotelPrice>> GetHotelPrice(string hotelId, string date, int days);
    }
}
