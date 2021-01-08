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
    public class CitiesController : ApiController
    {
        private yungching_DemoEntities db = new yungching_DemoEntities();

        // GET: api/Cities
        public IQueryable<City> GetCity()
        {
            return db.City;
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> GetCity(string id)
        {
            City city = await db.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCity(string id, City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.CityId)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.City.Add(city);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CityExists(city.CityId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = city.CityId }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> DeleteCity(string id)
        {
            City city = await db.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            db.City.Remove(city);
            await db.SaveChangesAsync();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(string id)
        {
            return db.City.Count(e => e.CityId == id) > 0;
        }
    }
}