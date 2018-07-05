using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YellowPagesDB;
namespace YellowPagesWebApi.Controllers
{
    public class SearchController : ApiController
    {
        public IHttpActionResult Get(string cityID,string name)
        {
            YellowbookEntities ctx = new YellowbookEntities();
            List<Item> result;
            if (cityID == 0 + "")
            {
                result = ctx.Items.Where(i => i.Category.Active == true && (i.ItemName == name || i.Keywords.Contains(name))).OrderBy(i => i.Order).ToList<Item>();
            }
            else
            {
                result = ctx.Items.Where(i => i.Category.Active == true && i.Category.UnitID + "" == cityID && (i.ItemName == name || i.Keywords.Contains(name))).OrderBy(i => i.Order).ToList<Item>();
            }
            if (result.Count > 0)
                return Ok(result);
            return NotFound();
        }
    }
}
