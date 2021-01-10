using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yungching_Demo.Areas.Hotel.ViewModels;

namespace yungching_Demo.Areas.Hotel.Service
{
    public interface ISupplierService
    {
        List<HotelListPrice> GetSupplierHotelList(string countryId, string cityId, string date, int days);
        List<HotelPrice> GetSupplierHotel(string hotel, string date, int days);
    }
}
