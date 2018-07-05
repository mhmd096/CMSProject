using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YellowPagesDB;
namespace YellowPagesWebApi.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        YellowbookEntities ctx = new YellowbookEntities();

        public IHttpActionResult GetAllCategories()
        {
            IList<Category> cat = null;
            cat = ctx.Categories.ToList<Category>();
            if (cat.Count == 0)
                return NotFound();
            return Ok(cat);
        }
        // category by id
        [Route("{id:long}")]
        public IHttpActionResult GetCategorybyId(long id)
        {
            Category cat = null;
            cat = ctx.Categories.Where(u => u.ID == id).First<Category>();
            if (cat == null)
                return NotFound();
            return Ok(cat);
        }
        //categories in unit id
        [Route("InUnit/{id:long}")]
        public IHttpActionResult GetCategories(long id)
        {
            IList<Category> cat = null;
            cat = ctx.Categories.Where(c => c.UnitID == id).ToList<Category>();
            if (cat.Count==0)
            {
                return NotFound();
            }
            return Ok(cat);
            
        }
        [Route("Top6")]
        public IHttpActionResult Get6Categories()
        {
            IList<Category> cat = null;
            cat = ctx.Categories.Where(c=>c.Active==true).OrderBy(c => c.Order).Take(6).ToList<Category>();
            if (cat.Count == 0)
                return NotFound();
            return Ok(cat);
        }
        //in unit name
        public IHttpActionResult GetCategory(string name)
        {
            IList<Category> cat = null;
            cat = ctx.Categories.Where(c=>c.Active==true).Where(c=>c.Unit.UnitName==name || c.Unit.Keywords.Contains(name)).ToList<Category>();
            if (cat.Count == 0)
                return NotFound();
            return Ok(cat);
        }
        //in location(city)
        public IHttpActionResult Getcat(string location)
        {
            IList<Category> cat = null;
            cat = ctx.Categories.Where(c=>c.Active==true).Where(c => c.Unit.City == location).ToList<Category>();
            if (cat.Count == 0)
                return NotFound();
            return Ok(cat);
        }

        public IHttpActionResult Post(Category c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            c.Timestamp = DateTime.Now;
            ctx.Categories.Add(c);
            ctx.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Put(Category c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var cat = ctx.Categories.Where(e => e.ID == c.ID).FirstOrDefault<Category>();
            if (cat != null)
            {
                cat.CategoryName = c.CategoryName;
                cat.Order = c.Order;
                cat.Active = c.Active;
                cat.Type = c.Type;
                cat.Timestamp = DateTime.Now;
                cat.Keywords = c.Keywords;
                cat.Picturelink = c.Picturelink;
                ctx.SaveChanges();
            }
            else
                return NotFound();
            return Ok();
        }
        [Route("{id:long}")]
        public IHttpActionResult Delete(long id)
        {
            if (id < 0)
                return BadRequest("Invalid data");
            var cat = ctx.Categories.FirstOrDefault(c => c.ID == id);
            IList<Item> items = null;
            items = ctx.Items.Where(i => i.CategoryID == id).ToList<Item>();
            for (int i = 0; i < items.Count; i++)
            {
                ctx.Entry(items[i]).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            ctx.Entry(cat).State = System.Data.Entity.EntityState.Deleted;
            ctx.SaveChanges();
            return Ok();
        }

    }
}
