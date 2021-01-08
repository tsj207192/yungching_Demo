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
    public class CountriesController : ApiController
    {
        private yungching_DemoEntities db = new yungching_DemoEntities();

        // GET: api/Countries
        public IQueryable<Country> GetCountry()
        {
            return db.Country;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public async Task<IHttpActionResult> GetCountry(string id)
        {
            Country country = await db.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCountry(string id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.CountryId)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        [ResponseType(typeof(Country))]
        public async Task<IHttpActionResult> PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Country.Add(country);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CountryExists(country.CountryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = country.CountryId }, country);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Country))]
        public async Task<IHttpActionResult> DeleteCountry(string id)
        {
            Country country = await db.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Country.Remove(country);
            await db.SaveChangesAsync();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(string id)
        {
            return db.Country.Count(e => e.CountryId == id) > 0;
        }
    }
}