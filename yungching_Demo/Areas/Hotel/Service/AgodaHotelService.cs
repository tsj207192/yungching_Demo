using System.Collections.Generic;
using System.Threading.Tasks;
using yungching_Demo.Areas.Hotel.ViewModels;

namespace yungching_Demo.Areas.Hotel.Service
{
    public class AgodaHotelService : IHotelService, ISupplierService
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
            return new List<HotelListPrice>()
            {
                new HotelListPrice
                {
                    Hotel = new Entity.Hotel()
                    {
                        HotelId = "TWTPE001",
                        Name = "君悅飯店",
                        Country = "TW",
                        City = "TPE",
                        Address = "台北市信義路",
                        Phone = string.Empty
                    },
                    Price = new Price()
                    {
                        Amount = 3450.00M,
                        Curr = "NTD"
                    }
                }
            };
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
            return new List<HotelPrice>()
            {
              new HotelPrice
              {
                    Hotel = new Entity.Hotel()
                    {
                        HotelId = "TWTPE001",
                        Name = "君悅飯店",
                        Country = "TW",
                        City = "TPE",
                        Address = "台北市信義路",
                        Phone = string.Empty
                    },
                    Products = new List<Product>()
                    {
                        new Product
                        {
                            Project = new Project
                            {
                                ProjectId = "S0117",
                                ProjectName = "優惠專案",
                                ProjectDesc = "<p>2人份早餐</p> <p>到店付款</p>"
                            },
                            Room = new Room
                            {
                                RoomId = "3",
                                RoomName = "Grand Twin Room",
                                RoomDesc = "<p>2張單人床</p>"
                            },
                            Price = new Price
                            {
                                Amount = 3450.00M,
                                Curr = "NTD"
                            }
                        }
                    }
              }
            };
        }
    }
}