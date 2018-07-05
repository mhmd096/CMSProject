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
    public class UnitController : Controller
    {
        public UnitService unitService;
        // GET: Unit
        public async Task<ActionResult> Index()
        {
            List<Unit> units = null;
            try
            {
                unitService = new UnitService();
                var response = await unitService.Gets();
                if (response.Status)
                    units = response.Data;
                else
                    ModelState.AddModelError(string.Empty,response.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(units);
        }
        //Add
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> create(Unit u)
        {
            try
            {
                unitService = new UnitService();
                var response = await unitService.Add(u);
                if (response.Status)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(u);
        }
        //Edit
        public async Task<ActionResult> Edit(long id)
        {
            Unit u = null;
            try
            {
                unitService = new UnitService();
                var response = await unitService.Getbyid(id);
                if (response.Status)
                    u = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(u);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Unit u)
        {
            try
            {
                unitService = new UnitService();
                var response = await unitService.Update(u);
                if (response.Status)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(u);
        }
        //Delete
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                unitService = new UnitService();
                var response = await unitService.Delete(id);
                if(response.Status)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index");
        }
       
    }
}