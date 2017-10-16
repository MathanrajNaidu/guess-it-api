using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GuessItApi.Models;

namespace GuessItApi.Controllers
{
    public class HallOfFamesController : ApiController
    {
        private GuessItApiContext db = new GuessItApiContext();

        // GET: api/HallOfFames
        public IQueryable<HallOfFame> GetHallOfFames()
        {
            return db.HallOfFames.OrderBy(x=>x.NumberOfAttempts).Take(20);
        }

        // GET: api/HallOfFames/5
        [ResponseType(typeof(HallOfFame))]
        public async Task<IHttpActionResult> GetHallOfFame(int id)
        {
            HallOfFame hallOfFame = await db.HallOfFames.FindAsync(id);
            if (hallOfFame == null)
            {
                return NotFound();
            }

            return Ok(hallOfFame);
        }

        // PUT: api/HallOfFames/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHallOfFame(int id, HallOfFame hallOfFame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hallOfFame.Id)
            {
                return BadRequest();
            }

            db.Entry(hallOfFame).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HallOfFameExists(id))
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

        // POST: api/HallOfFames
        [ResponseType(typeof(HallOfFame))]
        public async Task<IHttpActionResult> PostHallOfFame(HallOfFame hallOfFame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HallOfFames.Add(hallOfFame);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hallOfFame.Id }, hallOfFame);
        }

        // DELETE: api/HallOfFames/5
        [ResponseType(typeof(HallOfFame))]
        public async Task<IHttpActionResult> DeleteHallOfFame(int id)
        {
            HallOfFame hallOfFame = await db.HallOfFames.FindAsync(id);
            if (hallOfFame == null)
            {
                return NotFound();
            }

            db.HallOfFames.Remove(hallOfFame);
            await db.SaveChangesAsync();

            return Ok(hallOfFame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HallOfFameExists(int id)
        {
            return db.HallOfFames.Count(e => e.Id == id) > 0;
        }
    }
}