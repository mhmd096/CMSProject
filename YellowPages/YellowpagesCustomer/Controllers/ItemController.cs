using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YellowPagesDB;
using YellowPagesServices;

namespace YellowpagesCustomer.Controllers
{
    public class ItemController : Controller
    {
        ItemService itemService;
        // GET: Item
        public async Task<ActionResult> Index(long id)
        {
            List<Item> items = null;
            try
            {
                itemService = new ItemService();
                var response = await itemService.Gets(id);
                if (response.Status)
                    items = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(items);
        }
        
    }
}