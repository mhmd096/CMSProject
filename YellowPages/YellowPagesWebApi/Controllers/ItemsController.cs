using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YellowPagesDB;
namespace YellowPagesWebApi.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        YellowbookEntities ctx = new YellowbookEntities();

        public IHttpActionResult GetAllItems()
        {
            IList<Item> items = null;
            items = ctx.Items.OrderBy(i=>i.Order).ToList<Item>();
            if (items.Count == 0)
                return NotFound();
            return Ok(items);
        }
        [Route("{id:long}")]
        public IHttpActionResult GetItembyId(long id)
        {
            Item i = null;
            i = ctx.Items.Where(u => u.ID == id).First<Item>();
            if (i == null)
                return NotFound();
            return Ok(i);
        }
        //id of category
        [Route("InCategory/{id:long}")]
        public IHttpActionResult GetItems(long id)
        {
            IList<Item> items = null;
            items = ctx.Items.Where(u=>u.CategoryID==id).ToList<Item>();
            if (items.Count == 0)
                return NotFound();
            return Ok(items);
        }
        public IHttpActionResult GetItem(string name)
        {
            IList<Item> item = null;
            item = ctx.Items.Where(u => u.ItemName == name).ToList<Item>();
            if (item.Count == 0)
                return NotFound();
            return Ok(item);
        }
        
        public IHttpActionResult Post(Item i)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            i.Timestamp = DateTime.Now;
            ctx.Items.Add(i);
            ctx.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Put(Item i)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var item = ctx.Items.Where(t => t.ID == i.ID).FirstOrDefault<Item>();
            if (item != null)
            {
                item.ItemName = i.ItemName;
                item.Order = i.Order;
                item.PhoneNumber = i.PhoneNumber;
                item.Price = i.Price;
                item.Subject = i.Subject;
                item.Body = i.Body;
                item.Notes = i.Notes;
                item.Keywords = i.Keywords;
                item.FacebookLink = i.FacebookLink;
                item.InstagramLink = i.InstagramLink;
                item.isBanner = i.isBanner;
                item.OtherLinks = i.OtherLinks;
                item.Website = i.Website;
                item.Email = i.Email;
                item.Timestamp = DateTime.Now;
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
            var item = ctx.Items.FirstOrDefault(i => i.ID == id);
            IList<Picture> pics = null;
            pics = ctx.Pictures.Where(p => p.ItemID == id).ToList<Picture>();
            for (int i = 0; i < pics.Count; i++)
            {
                ctx.Entry(pics[i]).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            ctx.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            ctx.SaveChanges();
            return Ok();
        }

    }
}
