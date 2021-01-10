using System.Collections.Generic;
using System.Threading.Tasks;
using yungching_Demo.Areas.Hotel.ViewModels;

namespace yungching_Demo.Areas.Hotel.Service
{
    public class ExpediaHotelService : IHotelService, ISupplierService
    {
        public async Task<List<HotelListPrice>> GetHotelListPrice(string countryId, string cityId, string date, int days)
        {
            List<HotelListPrice> listPrices = new List<HotelListPrice>();

            //呼叫供應商取得對應國家城市房價
            await Task.Run(() =>
            {
                listPrices = GetSupplierHotelList(countryId, cityId, date, days);
            });

            return listPrices;
        }

        public async Task<List<HotelPrice>> GetHotelPrice(string hotel, string date, int days)
        {
            List<HotelPrice> hotelPrices = new List<HotelPrice>();
            //呼叫供應商取得單一旅館產品房價
            await Task.Run(() =>
            {
                hotelPrices = GetSupplierHotel(hotel, date, days);
            });
            return hotelPrices;
        }


        /// <summary>
        /// 查詢供應商對應城市旅館列表
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="cityId"></param>
        /// <param name="date"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<HotelListPrice> GetSupplierHotelList(string countryId, string cityId, string date, int days)
        {
            //呼叫供應商並取得查詢結果
            return new List<HotelListPrice>();
        }

        /// <summary>
        /// 查詢供應商旅館產品列表
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="date"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<HotelPrice> GetSupplierHotel(string hotel, string date, int days)
        {
            //呼叫供應商並取得查詢結果
            return new List<HotelPrice>();
        }
    }
}