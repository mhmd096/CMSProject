using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YellowPagesDB;
using YellowPagesServices;
namespace YellowPages.Controllers
{
    public class ItemController : Controller
    {
        public ItemService itemService;
        // GET: Item
        public async Task<ActionResult> Index(long id)
        {
            Session["Catid"] = id;
            IEnumerable<Item> items = null;
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
        //Add
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> create(Item i)
        {
            try
            {
                itemService = new ItemService();
                var response = await itemService.Add(i);
                if (response.Status)
                {
                    return RedirectToAction("Index/" + Session["Catid"]);
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(i);
        }
        //EDIT
        public async Task<ActionResult> Edit(long id)
        {
            Item i = null;
            try
            {
                itemService = new ItemService();
                var response = await itemService.GetbyId(id);
                if (response.Status)
                    i = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(i);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Item i)
        {
            try
            {
                itemService = new ItemService();
                var response = await itemService.Update(i);
                if (response.Status)
                {
                    return RedirectToAction("Index/" + Session["Catid"]);
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(i);
        }
        //Delete
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                itemService = new ItemService();
                var response = await itemService.Delete(id);
                if (response.Status)
                    return RedirectToAction("Index/" + Session["Catid"]);
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index/" + Session["Catid"]);
        }
    }
}