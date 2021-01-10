using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using yungching_Demo.Areas.Hotel.Service;
using yungching_Demo.Areas.Hotel.ViewModels;
using yungching_Demo.Entity;

namespace yungching_Demo.Areas.Hotel.Controllers
{
    [RoutePrefix("api/Search")]
    public class SearchController : ApiController
    {
        private yungching_DemoEntities db = new yungching_DemoEntities();

        // GET: api/Search/TW/TPE/2021-03-01/2
        //[ResponseType(typeof(List<HotelListPrice>))]
        [Route("{countryId}/{cityId}/{date}/{days:int}")]
        public async Task<IHttpActionResult> GetSearchHotelList(string countryId, string cityId, string date, int days)
        {
            var hotels = db.Hotel.Where(hotel => hotel.Country.Equals(countryId, StringComparison.OrdinalIgnoreCase) && hotel.City.Equals(cityId, StringComparison.OrdinalIgnoreCase));

            if (hotels != null && hotels.Count() == 0)
            {
                return NotFound();
            }
            var service = new AgodaHotelService();
            var result = await service.GetHotelListPrice(countryId, cityId, date, days);

            return Ok(result);
        }

        //[ResponseType(typeof(List<HotelPrice>))]
        [Route("{hotelId}/{date}/{days:int}")]
        public async Task<IHttpActionResult> GetSearchHotel(string hotelId, string date, int days)
        {
            Entity.Hotel hotel = await db.Hotel.FindAsync(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            var service = new AgodaHotelService();
            var result = await service.GetHotelPrice(hotelId, date, days);

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
