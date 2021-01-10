using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using yungching_Demo.Areas.Hotel.Models;
using yungching_Demo.Areas.Hotel.Service;
using yungching_Demo.Entity;

namespace yungching_Demo.Areas.Hotel.Controllers
{
    [RoutePrefix("api/Search")]
    public class SearchController : ApiController
    {
        private yungching_DemoEntities db = new yungching_DemoEntities();

        // GET: api/Search/TW/TPE/2021-03-01/2?supplierName=Agoda
        [Route("{countryId}/{cityId}/{date}/{days:int}")]
        public async Task<IHttpActionResult> GetSearchHotelList(string countryId, string cityId, string date, int days, string supplierName)
        {
            var hotels = db.Hotel.Where(hotel => hotel.Country.Equals(countryId, StringComparison.OrdinalIgnoreCase) && hotel.City.Equals(cityId, StringComparison.OrdinalIgnoreCase));

            if (hotels != null && hotels.Count() == 0)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(supplierName))
            {
                return NotFound();
            }
            var service = (IHotelService)UnityConfig.Container.Resolve(typeof(IHotelService), supplierName);
            var result = await service.GetHotelListPrice(countryId, cityId, date, days);

            return Ok(result);
        }

        //GET: api/Search/TWTPE001/2021-03-01/2?supplierName=Agoda
        [Route("{hotelId}/{date}/{days:int}")]
        public async Task<IHttpActionResult> GetSearchHotel(string hotelId, string date, int days, string supplierName)
        {
            Entity.Hotel hotel = await db.Hotel.FindAsync(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(supplierName))
            {
                return NotFound();
            }

            var service = new SupplierFactory(supplierName).GetService();
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
