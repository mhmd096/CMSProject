using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YellowPagesDB;

namespace YellowPagesWebApi.Controllers
{
    public class UnitsController : ApiController
    {
        YellowbookEntities ctx = new YellowbookEntities();

        public IHttpActionResult GetAllUnits()
        {
            IList<Unit> units = null;
            units = ctx.Units.ToList<Unit>();
            if (units.Count == 0)
                return NotFound();
            return Ok(units);
        }
        public IHttpActionResult GetUnit(long id)
        {
            Unit u = null;
            u = ctx.Units.First(e => e.ID == id);
            if (u == null)
                return NotFound();
            return Ok(u);
        }
        public IHttpActionResult GetUnitbylocation(string location)
        {
            IList<Unit> units = null;
            units = ctx.Units.Where(u => u.City == location).ToList<Unit>();
            if (units.Count == 0)
                return NotFound();
            return Ok(units);
        }
        public IHttpActionResult GetU(string name)
        {
            IList<Unit> units = null;
            units = ctx.Units.Where(u =>u.UnitName == name || u.Keywords.Contains(name)).ToList<Unit>();
            if (units.Count == 0)
                return NotFound();
            return Ok(units);
        }
        public IHttpActionResult Post(Unit u)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            u.Timestamp = DateTime.Now;
            ctx.Units.Add(u);
            ctx.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Put(Unit u)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var unit = ctx.Units.Where(e => e.ID == u.ID).FirstOrDefault<Unit>();
            if (unit != null)
            {
                unit.Keywords = u.Keywords;
                unit.Notes = u.Notes;
                unit.Country = u.Country;
                unit.City = u.City;
                unit.Address = u.Address;
                unit.RegionName = u.RegionName;
                unit.Timestamp = DateTime.Now;
                unit.UnitName = u.UnitName;
                ctx.SaveChanges();
            }
            else
                return NotFound();
            return Ok();
        }
        public IHttpActionResult Delete(long id)
        {
            if (id < 0)
                return BadRequest("Invalid data");
            var unit = ctx.Units.FirstOrDefault(u => u.ID == id);
            IList<Category> categories = null;
            categories = ctx.Categories.Where(c => c.UnitID == id).ToList<Category>();
            for(int i = 0; i < categories.Count; i++)
            {
                ctx.Entry(categories[i]).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            ctx.Entry(unit).State = System.Data.Entity.EntityState.Deleted;
            ctx.SaveChanges();
            return Ok();

        }

    }
}
