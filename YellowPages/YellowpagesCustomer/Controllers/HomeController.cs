using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YellowPagesDB;
using YellowPagesServices;
namespace YellowpagesCustomer.Controllers
{
    public class HomeController : Controller
    {
        SearchService searchService;
        CategoryService categoryService;
        UnitService unitService;
        public async Task<ActionResult> Index()
        {
            List<Unit> u = null;
            try
            {
                unitService = new UnitService();
                var response = await unitService.Gets();
                if (response.Status)
                    u = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            Unit def = new Unit();
            def.City = "ALL";
            u.Insert(0,def);
            ViewBag.cities = u;
            List<Category> cat = null;
            try
            {
                categoryService = new CategoryService();
                var response = await categoryService.Get6();
                if (response.Status)
                    cat = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(cat);
        }
        public async Task<ActionResult> SearchbyUnit(string city,string name)
        {
            List<Item> c = null;
            try
            {
                searchService = new SearchService();
                var response = await searchService.SearchbyUnit(city,name);
                if (response.Status)
                    c = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(c);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}