using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using yungching_Demo.Entity;

namespace yungching_Demo.Areas.Hotel.Controllers
{
    public class HotelsController : ApiController
    {
        private yungching_DemoEntities db = new yungching_DemoEntities();

        // GET: api/Hotels
        public IQueryable<Entity.Hotel> GetHotel()
        {
            return db.Hotel;
        }

        // GET: api/Hotels/5
        [ResponseType(typeof(Entity.Hotel))]
        public async Task<IHttpActionResult> GetHotel(string id)
        {
            Entity.Hotel hotel = await db.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHotel(string id, Entity.Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel.HotelId)
            {
                return BadRequest();
            }

            db.Entry(hotel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Hotels
        [ResponseType(typeof(Entity.Hotel))]
        public async Task<IHttpActionResult> PostHotel(Entity.Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hotel.Add(hotel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelExists(hotel.HotelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hotel.HotelId }, hotel);
        }

        // DELETE: api/Hotels/5
        [ResponseType(typeof(Entity.Hotel))]
        public async Task<IHttpActionResult> DeleteHotel(string id)
        {
            Entity.Hotel hotel = await db.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            db.Hotel.Remove(hotel);
            await db.SaveChangesAsync();

            return Ok(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelExists(string id)
        {
            return db.Hotel.Count(e => e.HotelId == id) > 0;
        }
    }
}