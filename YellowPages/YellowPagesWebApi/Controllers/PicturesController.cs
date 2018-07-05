using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YellowPagesDB;
namespace YellowPagesWebApi.Controllers
{
    [RoutePrefix("api/Pictures")]
    public class PicturesController : ApiController
    {
        YellowbookEntities ctx = new YellowbookEntities();

        //all pictures of one item
        [Route("InItem/{id:long}")]
        public IHttpActionResult GetPictures(long id)
        {
            IList<Picture> pics = null;
            pics = ctx.Pictures.Where(p => p.ItemID == id && p.Active==true).ToList<Picture>();
            if (pics.Count == 0)
                return NotFound();
            return Ok(pics);
        }
        [Route("{id:long}")]
        public IHttpActionResult GetPicturebyID(long id)
        {
            Picture p = null;
            p = ctx.Pictures.Where(r => r.ID == id).First<Picture>();
            if (p == null)
                return NotFound();
            return Ok(p);
        }
        //id of item
        public IHttpActionResult Post(Picture p)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            p.Timestamp = DateTime.Now;
            ctx.Pictures.Add(p);
            ctx.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Put(Picture p)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var pic = ctx.Pictures.Where(i => i.ID ==p.ID).FirstOrDefault<Picture>();
            if (pic != null)
            {
                pic.Picturelink = p.Picturelink;
                pic.Active = p.Active;
                pic.isMain = p.isMain;
                pic.Notes = p.Notes;
                pic.Order = p.Order;
                pic.ThumbLink = p.ThumbLink;
                pic.Timestamp = DateTime.Now;
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
            var pic = ctx.Pictures.FirstOrDefault(p => p.ID == id);
            ctx.Entry(pic).State = System.Data.Entity.EntityState.Deleted;
            ctx.SaveChanges();
            return Ok();
        }
    }
}
